namespace Clean_Go_BusinessLogic.Validator.Ordenes.Estado
{
    public class EstadoListaParaEntrega : IEstadoOrden
    {
        public int EstadoId { get { return 3; } }
        public string Nombre { get { return "Lista para Entrega"; } }

        public bool PuedeCambiarA(int nuevoEstadoId)
        {
            return nuevoEstadoId == 4 || nuevoEstadoId == 5;
        }
    }
}
