using System;
using Clean_Go_Entities.Clientes;

namespace Clean_Go_BusinessLogic.Validator.Clientes
{
    public class ClienteValidator : IValidator<Cliente>
    {
        public void Validate(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
                throw new ArgumentException("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Cedula))
                throw new ArgumentException("La cédula es obligatoria.");

            if (string.IsNullOrWhiteSpace(cliente.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (!string.IsNullOrWhiteSpace(cliente.Correo) && !cliente.Correo.Contains("@"))
            {
                throw new ArgumentException("El correo electrónico no es válido.");
            }
        }
    }
}
