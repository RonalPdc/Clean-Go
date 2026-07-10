namespace Clean_Go_BusinessLogic.Validator.Ordenes.Estado
{
    public class EstadoRecibida : IEstadoOrden
    {
        public int EstadoId { get { return 1; } }
        public string Nombre { get { return "Recibida"; } }

        public bool PuedeCambiarA(int nuevoEstadoId)
        {
            return nuevoEstadoId == 2 || nuevoEstadoId == 5;
        }
    }
}
