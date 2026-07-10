using System;

namespace Clean_Go_Entities.Ordenes
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public string NumeroOrden { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEntregaEstimada { get; set; }
        public string Observaciones { get; set; }
        public decimal Total { get; set; }
        public int EstadoId { get; set; }
        public int UsuarioRegistroId { get; set; }
    }
}
