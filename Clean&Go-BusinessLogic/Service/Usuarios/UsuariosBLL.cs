using System;
using System.Collections.Generic;
using Clean_Go_DataAccess.Repositories.Usuarios;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go_BusinessLogic.Service.Usuarios
{
    public class UsuariosBLL
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        public Usuario Login(string nombreUsuario, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es requerido.");

            if (string.IsNullOrWhiteSpace(contraseña))
                throw new ArgumentException("La contraseña es requerida.");

            return _usuarioDAL.Login(nombreUsuario, contraseña);
        }

        public string RecuperarPassword(string nombreUsuario, string correo)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es requerido.");

            if (string.IsNullOrWhiteSpace(correo))
                throw new ArgumentException("El correo electrónico es requerido.");

            List<Usuario> usuarios = _usuarioDAL.ObtenerTodos();
            Usuario usuarioEncontrado = null;

            foreach (var u in usuarios)
            {
                if (string.Equals(u.NombreUsuario, nombreUsuario, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(u.Correo, correo, StringComparison.OrdinalIgnoreCase))
                {
                    usuarioEncontrado = u;
                    break;
                }
            }

            if (usuarioEncontrado == null)
                throw new InvalidOperationException("No se encontró ningún usuario con esos datos.");

            Usuario detalleUsuario = _usuarioDAL.ObtenerPorId(usuarioEncontrado.UsuarioId);

            if (detalleUsuario == null)
                throw new InvalidOperationException("Error al recuperar los detalles del usuario.");

            return detalleUsuario.PasswordHash;
        }
    }
}
