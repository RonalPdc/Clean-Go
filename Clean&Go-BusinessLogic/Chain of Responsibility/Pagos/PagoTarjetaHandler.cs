namespace Clean_Go_BusinessLogic.Service.Pagos
{
    public class PagoTarjetaHandler : ManejadorPagoBase
    {
        public override bool ProcesarPago(string metodo, decimal monto)
        {
            if (metodo == "Tarjeta de Crédito")
            {
                return true;
            }
            return base.ProcesarPago(metodo, monto);
        }
    }
}
