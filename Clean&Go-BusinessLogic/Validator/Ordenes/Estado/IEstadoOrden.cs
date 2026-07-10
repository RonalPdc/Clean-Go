namespace Clean_Go_BusinessLogic.Validator.Ordenes.Estado
{
    public interface IEstadoOrden
    {
        int EstadoId { get; }
        string Nombre { get; }
        bool PuedeCambiarA(int nuevoEstadoId);
    }
}
