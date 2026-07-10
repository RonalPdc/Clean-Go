using System;

namespace Clean_Go_BusinessLogic.Validator.Ordenes.Estado
{
    public static class EstadoOrdenHelper
    {
        public static IEstadoOrden ObtenerEstado(int estadoId)
        {
            switch (estadoId)
            {
                case 1: return new EstadoRecibida();
                case 2: return new EstadoEnProceso();
                case 3: return new EstadoListaParaEntrega();
                case 4: return new EstadoEntregada();
                case 5: return new EstadoCancelada();
                default:
                    throw new ArgumentException("ID de estado de orden no válido.");
            }
        }
    }
}
