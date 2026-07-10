namespace Clean_Go_Entities.Ordenes
{
    public class DetalleOrden
    {
        public int DetalleId { get; set; }
        public int OrdenId { get; set; }
        public int TipoPrendaId { get; set; }
        public int ServicioId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Observaciones { get; set; }
    }
}
