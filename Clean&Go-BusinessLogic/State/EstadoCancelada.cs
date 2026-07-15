namespace Clean_Go_BusinessLogic.Validator.Ordenes.Estado
{
    public class EstadoCancelada : IEstadoOrden
    {
        public int EstadoId { get { return 5; } }
        public string Nombre { get { return "Cancelada"; } }

        public bool PuedeCambiarA(int nuevoEstadoId)
        {
            return false;
        }
    }
}
