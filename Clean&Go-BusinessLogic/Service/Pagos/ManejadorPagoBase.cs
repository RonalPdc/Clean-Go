namespace Clean_Go_BusinessLogic.Service.Pagos
{
    public abstract class ManejadorPagoBase : IManejadorPago
    {
        protected IManejadorPago _siguiente;

        public void ConfigurarSiguiente(IManejadorPago siguiente)
        {
            _siguiente = siguiente;
        }

        public virtual bool ProcesarPago(string metodo, decimal monto)
        {
            if (_siguiente != null)
            {
                return _siguiente.ProcesarPago(metodo, monto);
            }
            return false;
        }
    }
}
