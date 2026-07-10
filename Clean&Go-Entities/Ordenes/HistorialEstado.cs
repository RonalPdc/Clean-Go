using System;

namespace Clean_Go_Entities.Ordenes
{
    public class HistorialEstado
    {
        public int HistorialId { get; set; }
        public int OrdenId { get; set; }
        public int EstadoAnteriorId { get; set; }
        public int EstadoNuevoId { get; set; }
        public DateTime FechaHora { get; set; }
        public int UsuarioId { get; set; }
    }
}
