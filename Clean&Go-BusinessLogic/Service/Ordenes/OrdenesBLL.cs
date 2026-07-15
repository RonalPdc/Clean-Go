using System;
using System.Collections.Generic;
using System.Data;
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

                if (AlCambiarOrdenes != null)
                {
                    AlCambiarOrdenes();
                }
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

            bool estadoActualizado = _ordenDAL.ActualizarEstado(ordenId, nuevoEstadoId, usuarioId, comentario);

            if (estadoActualizado)
            {
                try
                {
                    Cliente cliente = _clienteDAL.ObtenerPorId(orden.ClienteId);
                    if (cliente != null)
                    {
                        IEstadoOrden estadoNuevo = EstadoOrdenHelper.ObtenerEstado(nuevoEstadoId);
                        string mensajeNotificacion = $"Hola {cliente.Nombre}, el estado de su orden número {orden.NumeroOrden} ha cambiado a: {estadoNuevo.Nombre}.";
                        _notificacionDAL.RegistrarNotificacion(ordenId, orden.ClienteId, mensajeNotificacion);
                    }
                }
                catch (Exception)
                {
                }

                if (AlCambiarOrdenes != null)
                {
                    AlCambiarOrdenes();
                }
            }

            return estadoActualizado;
        }

        public Dictionary<int, int> ObtenerConteosPorEstado()
        {
            return _ordenDAL.ObtenerConteosPorEstado();
        }

        public DataTable ObtenerReporteOrdenes(DateTime? desde, DateTime? hasta, string estado)
        {
            return _ordenDAL.ObtenerReporteOrdenes(desde, hasta, estado);
        }

        public List<string> ObtenerTodosEstados()
        {
            return _ordenDAL.ObtenerTodosEstados();
        }

        public DataTable ObtenerComboList()
        {
            return _ordenDAL.ObtenerComboList();
        }

        public DataTable ObtenerPorNumero(string numeroOrden)
        {
            return _ordenDAL.ObtenerPorNumero(numeroOrden);
        }

        public DataTable ObtenerHistorialEstados(int ordenId)
        {
            return _ordenDAL.ObtenerHistorialEstados(ordenId);
        }

        public DataTable ObtenerDetalle(int ordenId)
        {
            return _ordenDAL.ObtenerDetalle(ordenId);
        }
    }
}
