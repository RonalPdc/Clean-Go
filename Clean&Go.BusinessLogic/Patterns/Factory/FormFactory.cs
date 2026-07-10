using System;
using System.Windows.Forms;
using Clean_Go.BusinessLogic.Usuarios;
using Clean_Go.BusinessLogic.Clientes;
using Clean_Go.BusinessLogic.Servicios;
using Clean_Go.BusinessLogic.Prendas;
using Clean_Go.BusinessLogic.Ordenes;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go.BusinessLogic.Patterns.Factory
{
    public enum TipoModulo
    {
        Usuarios,
        Clientes,
        Servicios,
        Prendas,
        Ordenes
    }

    public static class FormFactory
    {
        public static Form Crear(TipoModulo modulo, Usuario usuarioLogueado)
        {
            switch (modulo)
            {
                case TipoModulo.Usuarios:
                    return new FrmUsuarios();
                case TipoModulo.Clientes:
                    return new FrmClientes();
                case TipoModulo.Servicios:
                    return new FrmServicios();
                case TipoModulo.Prendas:
                    return new FrmPrendas();
                case TipoModulo.Ordenes:
                    return new FrmOrdenes(usuarioLogueado);
                default:
                    throw new ArgumentException("Modulo no soportado.");
            }
        }
    }
}
