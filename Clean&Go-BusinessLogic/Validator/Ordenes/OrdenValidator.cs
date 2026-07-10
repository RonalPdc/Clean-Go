using System;
using System.Collections.Generic;
using Clean_Go_Entities.Ordenes;
using Clean_Go_BusinessLogic.Validator.Ordenes.Estado;

namespace Clean_Go_BusinessLogic.Validator.Ordenes
{
    public class OrdenValidator
    {
        public void ValidarNuevaOrden(Orden orden, List<DetalleOrden> detalles)
        {
            if (orden == null)
                throw new ArgumentNullException(nameof(orden), "La orden no puede ser nula.");

            if (detalles == null || detalles.Count == 0)
                throw new ArgumentException("La orden debe contener al menos una prenda y servicio.");

            if (orden.ClienteId <= 0)
                throw new ArgumentException("Debe asociar la orden a un cliente válido.");

            if (string.IsNullOrWhiteSpace(orden.NumeroOrden))
                throw new ArgumentException("El número de orden es obligatorio.");

            if (orden.UsuarioRegistroId <= 0)
                throw new ArgumentException("El ID del usuario registrador es obligatorio.");

            foreach (var det in detalles)
            {
                if (det.TipoPrendaId <= 0)
                    throw new ArgumentException("Debe seleccionar un tipo de prenda válido.");

                if (det.ServicioId <= 0)
                    throw new ArgumentException("Debe seleccionar un servicio válido.");

                if (det.Cantidad <= 0)
                    throw new ArgumentException("La cantidad debe ser mayor a cero.");

                if (det.Precio < 0)
                    throw new ArgumentException("El precio no puede ser negativo.");
            }
        }

        public void ValidarCambioEstado(int estadoActualId, int nuevoEstadoId)
        {
            IEstadoOrden estadoActual = EstadoOrdenHelper.ObtenerEstado(estadoActualId);
            
            if (!estadoActual.PuedeCambiarA(nuevoEstadoId))
            {
                IEstadoOrden estadoNuevo = EstadoOrdenHelper.ObtenerEstado(nuevoEstadoId);
                throw new InvalidOperationException($"No se permite cambiar el estado de la orden desde '{estadoActual.Nombre}' hacia '{estadoNuevo.Nombre}'.");
            }
        }
    }
}
