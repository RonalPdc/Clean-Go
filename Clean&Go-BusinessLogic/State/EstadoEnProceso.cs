namespace Clean_Go_BusinessLogic.Validator.Ordenes.Estado
{
    public class EstadoEnProceso : IEstadoOrden
    {
        public int EstadoId { get { return 2; } }
        public string Nombre { get { return "En Proceso"; } }

        public bool PuedeCambiarA(int nuevoEstadoId)
        {
            return nuevoEstadoId == 3 || nuevoEstadoId == 5;
        }
    }
}
