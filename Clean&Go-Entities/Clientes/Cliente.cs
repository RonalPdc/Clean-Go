using System;

namespace Clean_Go_Entities.Clientes
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string TelegramChatId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        public string NombreCompletoConCedula
        {
            get { return Nombre + " " + Apellido + " (" + Cedula + ")"; }
        }
    }
}
