namespace Clean_Go_BusinessLogic.Service.Pagos
{
    public class PagoEfectivoHandler : ManejadorPagoBase
    {
        public override bool ProcesarPago(string metodo, decimal monto)
        {
            if (metodo == "Efectivo")
            {
                return true;
            }
            return base.ProcesarPago(metodo, monto);
        }
    }
}
