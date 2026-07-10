using System;
using System.Collections.Generic;
using Clean_Go_DataAccess.Repositories.Ordenes;
using Clean_Go_DataAccess.Repositories.Clientes;
using Clean_Go_DataAccess.Repositories.Notificaciones;
using Clean_Go_Entities.Ordenes;
using Clean_Go_Entities.Clientes;
using Clean_Go_BusinessLogic.Validator.Ordenes;
using Clean_Go_BusinessLogic.Validator.Ordenes.Estado;

namespace Clean_Go_BusinessLogic.Service.Ordenes
{
    public class OrdenesBLL
    {
        private readonly OrdenDAL _ordenDAL = new OrdenDAL();
        private readonly ClienteDAL _clienteDAL = new ClienteDAL();
        private readonly HistorialEstadoDAL _historialDAL = new HistorialEstadoDAL();
        private readonly ColaNotificacionDAL _notificacionDAL = new ColaNotificacionDAL();
        private readonly OrdenValidator _validator = new OrdenValidator();

        public static event Action AlCambiarOrdenes;

        public List<Orden> ObtenerTodos()
        {
            return _ordenDAL.ObtenerTodos();
        }

        public Orden ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de orden inválido.");

            return _ordenDAL.ObtenerPorId(id);
        }

        public bool CrearOrden(Orden orden, List<DetalleOrden> detalles)
        {
            _validator.ValidarNuevaOrden(orden, detalles);

            Cliente cliente = _clienteDAL.ObtenerPorId(orden.ClienteId);
            if (cliente == null)
                throw new InvalidOperationException("El cliente asociado no existe.");
            if (!cliente.Estado)
                throw new InvalidOperationException("No se pueden crear órdenes para clientes inactivos.");

            bool guardadoExitoso = _ordenDAL.CrearOrden(orden, detalles);

            if (guardadoExitoso)
            {
                string mensajeNotificacion = $"Hola {cliente.Nombre}, su orden número {orden.NumeroOrden} ha sido recibida con éxito en Clean&Go.";
                _notificacionDAL.RegistrarNotificacion(orden.OrdenId, orden.ClienteId, mensajeNotificacion);

                AlCambiarOrdenes?.Invoke();
            }

            return guardadoExitoso;
        }

        public bool CambiarEstado(int ordenId, int nuevoEstadoId, int usuarioId, string comentario)
        {
            if (ordenId <= 0)
                throw new ArgumentException("ID de orden inválido.");

            Orden orden = _ordenDAL.ObtenerPorId(ordenId);
            if (orden == null)
                throw new InvalidOperationException("La orden especificada no existe.");

            _validator.ValidarCambioEstado(orden.EstadoId, nuevoEstadoId);

            bool estadoActualizado = _ordenDAL.ActualizarEstado(ordenId, nuevoEstadoId);

            if (estadoActualizado)
            {
                _historialDAL.RegistrarCambio(ordenId, orden.EstadoId, nuevoEstadoId, usuarioId, comentario);

                Cliente cliente = _clienteDAL.ObtenerPorId(orden.ClienteId);
                if (cliente != null && !string.IsNullOrWhiteSpace(cliente.TelegramChatId))
                {
                    IEstadoOrden estadoNuevo = EstadoOrdenHelper.ObtenerEstado(nuevoEstadoId);
                    string mensajeTelegram = $"Hola {cliente.Nombre}, el estado de su orden {orden.NumeroOrden} ha cambiado a: '{estadoNuevo.Nombre}'.";
                    _notificacionDAL.RegistrarNotificacion(ordenId, orden.ClienteId, mensajeTelegram);
                }

                AlCambiarOrdenes?.Invoke();
            }

            return estadoActualizado;
        }
    }
}
