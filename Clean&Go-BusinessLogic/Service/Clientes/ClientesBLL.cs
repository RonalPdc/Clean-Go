using System;
using System.Collections.Generic;
using Clean_Go_DataAccess.Repositories.Clientes;
using Clean_Go_Entities.Clientes;
using Clean_Go_BusinessLogic.Validator;
using Clean_Go_BusinessLogic.Validator.Clientes;

namespace Clean_Go_BusinessLogic.Service.Clientes
{
    public class ClientesBLL
    {
        private readonly ClienteDAL _clienteDAL = new ClienteDAL();
        private readonly IValidator<Cliente> _validator = new ClienteValidator();

        public List<Cliente> ObtenerTodos()
        {
            return _clienteDAL.ObtenerTodos();
        }

        public Cliente ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Cliente inválido.");

            return _clienteDAL.ObtenerPorId(id);
        }

        public bool Crear(Cliente cliente)
        {
            ValidarCliente(cliente);

            return _clienteDAL.Crear(cliente);
        }

        public bool Actualizar(Cliente cliente)
        {
            if (cliente.ClienteId <= 0)
                throw new ArgumentException("Cliente inválido.");

            ValidarCliente(cliente);

            return _clienteDAL.Actualizar(cliente);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Cliente inválido.");

            return _clienteDAL.Eliminar(id);
        }

        private void ValidarCliente(Cliente cliente)
        {
            _validator.Validate(cliente);
        }
    }
}