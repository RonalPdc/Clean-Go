namespace Clean_Go_BusinessLogic.Service.Pagos
{
    public interface IManejadorPago
    {
        void ConfigurarSiguiente(IManejadorPago siguiente);
        bool ProcesarPago(string metodo, decimal monto);
    }
}
