using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
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
        private readonly TelegramBotClient _botClient;
        private int _lastUpdateId = 0;

        public TelegramBotProcessor()
        {
            string botToken = ConfigurationManager.AppSettings["TelegramBotToken"];
            _botClient = new TelegramBotClient(botToken);
        }

        public void IniciarChatBot(CancellationToken cancellationToken)
        {
            var receiverOptions = new Telegram.Bot.Polling.ReceiverOptions
            {
                AllowedUpdates = Array.Empty<Telegram.Bot.Types.Enums.UpdateType>(),
                DropPendingUpdates = true
            };

            _botClient.ReceiveAsync(
                updateHandler: async (bot, update, ct) =>
                {
                    if (update.Message != null && !string.IsNullOrWhiteSpace(update.Message.Text))
                    {
                        string chatId = update.Message.Chat.Id.ToString();
                        string text = update.Message.Text;
                        ResponderConsulta(chatId, text);
                    }
                },
                errorHandler: (bot, ex, ct) =>
                {
                    return System.Threading.Tasks.Task.CompletedTask;
                },
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken
            );
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
                var updates = _botClient.GetUpdates(offset: _lastUpdateId).GetAwaiter().GetResult();
                foreach (var update in updates)
                {
                    _lastUpdateId = update.Id + 1;

                    if (update.Message != null && !string.IsNullOrWhiteSpace(update.Message.Text))
                    {
                        string chatId = update.Message.Chat.Id.ToString();
                        string text = update.Message.Text;
                        ResponderConsulta(chatId, text);
                    }
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
                _botClient.SendMessage(chatId, mensaje).GetAwaiter().GetResult();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
