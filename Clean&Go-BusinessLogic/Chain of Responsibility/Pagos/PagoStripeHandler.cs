namespace Clean_Go_BusinessLogic.Service.Pagos
{
    public class PagoStripeHandler : ManejadorPagoBase
    {
        public override bool ProcesarPago(string metodo, decimal monto)
        {
            if (metodo == "Stripe")
            {
                return true;
            }
            return base.ProcesarPago(metodo, monto);
        }
    }
}
