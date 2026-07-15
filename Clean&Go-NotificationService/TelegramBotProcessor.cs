using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using Clean_Go_DataAccess.Repositories.Notificaciones;
using Clean_Go_DataAccess.Repositories.Ordenes;
using Clean_Go_DataAccess.Repositories.Clientes;
using Clean_Go_Entities.Notificaciones;
using Clean_Go_Entities.Ordenes;
using Clean_Go_Entities.Clientes;
using Clean_Go_BusinessLogic.Validator.Ordenes.Estado;

namespace Clean_Go_NotificationService
{
    public class TelegramBotProcessor
    {
        private readonly ColaNotificacionDAL _notificacionDAL = new ColaNotificacionDAL();
        private readonly OrdenDAL _ordenDAL = new OrdenDAL();
        private readonly ClienteDAL _clienteDAL = new ClienteDAL();
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string _botToken;
        private int _lastUpdateId = 0;

        public TelegramBotProcessor()
        {
            _botToken = ConfigurationManager.AppSettings["TelegramBotToken"];
        }

        public void ProcesarNotificacionesPendientes()
        {
            try
            {
                List<ColaNotificacion> pendientes = _notificacionDAL.ObtenerPendientes();
                foreach (var notif in pendientes)
                {
                    if (string.IsNullOrWhiteSpace(notif.TelegramChatId))
                    {
                        _notificacionDAL.AumentarIntento(notif.NotificacionId);
                        continue;
                    }

                    bool enviado = EnviarMensajeTelegram(notif.TelegramChatId, notif.Mensaje);
                    if (enviado)
                    {
                        _notificacionDAL.MarcarComoEnviada(notif.NotificacionId);
                    }
                    else
                    {
                        _notificacionDAL.AumentarIntento(notif.NotificacionId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error notificaciones: " + ex.Message);
            }
        }

        public void ProcesarConsultasChatBot()
        {
            try
            {
                string url = "https://api.telegram.org/bot" + _botToken + "/getUpdates?offset=" + _lastUpdateId;
                HttpResponseMessage response = _httpClient.GetAsync(url).Result;
                if (!response.IsSuccessStatusCode) return;

                string json = response.Content.ReadAsStringAsync().Result;
                int index = 0;

                while (true)
                {
                    index = json.IndexOf("\"update_id\":", index);
                    if (index == -1) break;

                    index += 12;
                    int endUpdateId = json.IndexOf(",", index);
                    if (endUpdateId == -1) break;

                    string updateIdStr = json.Substring(index, endUpdateId - index).Trim();
                    int updateId = int.Parse(updateIdStr);
                    _lastUpdateId = updateId + 1;

                    int chatIndex = json.IndexOf("\"chat\":", index);
                    if (chatIndex == -1) continue;

                    int idIndex = json.IndexOf("\"id\":", chatIndex);
                    if (idIndex == -1) continue;

                    idIndex += 5;
                    int endChatId = json.IndexOf(",", idIndex);
                    if (endChatId == -1) continue;

                    string chatId = json.Substring(idIndex, endChatId - idIndex).Trim();

                    int textIndex = json.IndexOf("\"text\":\"", idIndex);
                    if (textIndex == -1) continue;

                    textIndex += 8;
                    int endText = json.IndexOf("\"", textIndex);
                    if (endText == -1) continue;

                    string text = json.Substring(textIndex, endText - textIndex).Trim();
                    
                    ResponderConsulta(chatId, text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error chatbot: " + ex.Message);
            }
        }

        private void ResponderConsulta(string chatId, string text)
        {
            string cleanText = text.ToUpper().Trim();

            if (cleanText == "/START" || cleanText == "/AYUDA" || cleanText == "HOLA")
            {
                string bienvenida = "Bienvenido al ChatBot de Clean&Go. Consulte el estado de su orden enviando el número de orden (ej: ORD-001) o su número de cédula.";
                EnviarMensajeTelegram(chatId, bienvenida);
                return;
            }

            Orden ordenEncontrada = null;

            if (cleanText.StartsWith("ORD-"))
            {
                List<Orden> ordenes = _ordenDAL.ObtenerTodos();
                foreach (var o in ordenes)
                {
                    if (o.NumeroOrden.ToUpper().Trim() == cleanText)
                    {
                        ordenEncontrada = o;
                        break;
                    }
                }
            }
            else
            {
                List<Cliente> clientes = _clienteDAL.ObtenerTodos();
                Cliente clienteEncontrado = null;
                foreach (var c in clientes)
                {
                    if (c.Cedula.Trim() == cleanText)
                    {
                        clienteEncontrado = c;
                        break;
                    }
                }

                if (clienteEncontrado != null)
                {
                    List<Orden> ordenes = _ordenDAL.ObtenerTodos();
                    foreach (var o in ordenes)
                    {
                        if (o.ClienteId == clienteEncontrado.ClienteId)
                        {
                            ordenEncontrada = o;
                            break;
                        }
                    }
                }
            }

            if (ordenEncontrada != null)
            {
                IEstadoOrden estado = EstadoOrdenHelper.ObtenerEstado(ordenEncontrada.EstadoId);
                string respuesta = "Orden: " + ordenEncontrada.NumeroOrden + "\nEstado actual: " + estado.Nombre + "\nTotal a pagar: $" + ordenEncontrada.Total + "\nFecha de recepcion: " + ordenEncontrada.FechaRecepcion.ToString("dd/MM/yyyy");
                EnviarMensajeTelegram(chatId, respuesta);
            }
            else
            {
                string noEncontrado = "No encontramos ninguna orden asociada a su busqueda. Verifique el numero de orden o cedula.";
                EnviarMensajeTelegram(chatId, noEncontrado);
            }
        }

        private bool EnviarMensajeTelegram(string chatId, string mensaje)
        {
            try
            {
                string url = "https://api.telegram.org/bot" + _botToken + "/sendMessage";
                var values = new Dictionary<string, string>
                {
                    { "chat_id", chatId },
                    { "text", mensaje }
                };

                var content = new FormUrlEncodedContent(values);
                HttpResponseMessage response = _httpClient.PostAsync(url, content).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
