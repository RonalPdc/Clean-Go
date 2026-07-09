using System;

namespace Clean_Go_Entities.Usuarios
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public int RolId { get; set; }
        public string Rol { get; set; }
        public string PasswordHash { get; set; }
    }
}
