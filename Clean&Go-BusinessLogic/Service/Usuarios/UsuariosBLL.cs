using System;
using System.Collections.Generic;
using Clean_Go_DataAccess.Repositories.Usuarios;
using Clean_Go_Entities.Usuarios;
using Clean_Go_BusinessLogic.Validator;
using Clean_Go_BusinessLogic.Validator.Usuarios;

namespace Clean_Go_BusinessLogic.Service.Usuarios
{
    public class UsuariosBLL
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();
        private readonly IValidator<Usuario> _validator = new UsuarioValidator();

        public static event Action AlCambiarUsuarios;

        public bool Crear(Usuario usuario)
        {
            _validator.Validate(usuario);

            if (string.IsNullOrWhiteSpace(usuario.PasswordHash))
                throw new ArgumentException("La contraseña es obligatoria.");

            bool resultado = _usuarioDAL.Crear(usuario);
            if (resultado)
                AlCambiarUsuarios?.Invoke();
            return resultado;
        }

        public bool Actualizar(Usuario usuario)
        {
            if (usuario.UsuarioId <= 0)
                throw new ArgumentException("Usuario inválido.");

            _validator.Validate(usuario);

            bool resultado = _usuarioDAL.Actualizar(usuario);
            if (resultado)
                AlCambiarUsuarios?.Invoke();
            return resultado;
        }
        public bool Eliminar(int usuarioId)
        {
            if (usuarioId <= 0)
                throw new ArgumentException("Usuario inválido.");

            bool resultado = _usuarioDAL.Eliminar(usuarioId);
            if (resultado)
                AlCambiarUsuarios?.Invoke();
            return resultado;
        }
        public Usuario Login(string nombreUsuario, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es requerido.");

            if (string.IsNullOrWhiteSpace(contraseña))
                throw new ArgumentException("La contraseña es requerida.");

            return _usuarioDAL.Login(nombreUsuario, contraseña);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _usuarioDAL.ObtenerTodos();
        }

        public Usuario ObtenerPorId(int usuarioId)
        {
            return _usuarioDAL.ObtenerPorId(usuarioId);
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

        public bool ActualizarPassword(int usuarioId, string passwordActual, string nuevoPassword)
        {
            if (string.IsNullOrWhiteSpace(passwordActual))
                throw new ArgumentException("La contraseña actual es obligatoria.");

            if (string.IsNullOrWhiteSpace(nuevoPassword))
                throw new ArgumentException("La nueva contraseña es obligatoria.");

            Usuario usuario = _usuarioDAL.ObtenerPorId(usuarioId);
            if (usuario == null)
                throw new InvalidOperationException("El usuario no existe.");

            if (usuario.PasswordHash != passwordActual)
                throw new ArgumentException("La contraseña actual es incorrecta.");

            bool resultado = _usuarioDAL.ActualizarPassword(usuarioId, nuevoPassword);
            if (resultado)
                AlCambiarUsuarios?.Invoke();
            return resultado;
        }
    }
}
