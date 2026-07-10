using System;

namespace Clean_Go_Entities.Notificaciones
{
    public class ColaNotificacion
    {
        public int NotificacionId { get; set; }
        public int OrdenId { get; set; }
        public int ClienteId { get; set; }
        public string TelegramChatId { get; set; }
        public string Mensaje { get; set; }
        public string Estado { get; set; }
        public int Intentos { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
