using System;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go_BusinessLogic.Validator.Usuarios
{
    public class UsuarioValidator : IValidator<Usuario>
    {
        public void Validate(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                throw new ArgumentException("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Correo))
                throw new ArgumentException("El correo es obligatorio.");
        }
    }
}
