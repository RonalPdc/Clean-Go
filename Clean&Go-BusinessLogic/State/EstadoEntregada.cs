namespace Clean_Go_BusinessLogic.Validator.Ordenes.Estado
{
    public class EstadoEntregada : IEstadoOrden
    {
        public int EstadoId { get { return 4; } }
        public string Nombre { get { return "Entregada"; } }

        public bool PuedeCambiarA(int nuevoEstadoId)
        {
            return false;
        }
    }
}
