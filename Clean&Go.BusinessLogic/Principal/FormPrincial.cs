using System;
using System.Windows.Forms;
using Clean_Go_Entities.Usuarios;
using Clean_Go.BusinessLogic.Usuarios;
using Clean_Go.BusinessLogic.Patterns.Factory;
using Clean_Go.BusinessLogic.Reportes;

namespace Clean_Go.BusinessLogic
{
    public partial class FormPrincial : Form
    {
        private readonly Usuario _usuarioLogueado;

        public FormPrincial()
        {
            InitializeComponent();
        }

        public FormPrincial(Usuario usuario) : this()
        {
            _usuarioLogueado = usuario;
            if (_usuarioLogueado != null)
            {
                lblUserStatus.Text = "Usuario: " + _usuarioLogueado.Nombre + " " + _usuarioLogueado.Apellido;
            }
            
            menuItemClientes.Click += MenuClientes_Click;
            menuItemServicios.Click += MenuServicios_Click;
            menuItemTiposPrenda.Click += MenuTiposPrenda_Click;
            menuItemOrdenes.Click += MenuOrdenes_Click;
            menuItemReporteOrdenes.Click += MenuReporteOrdenes_Click;
            menuItemReporteClientes.Click += MenuReporteHistorial_Click;
            menuItemReporteServicios.Click += MenuReporteAuditoria_Click;
        }

        private void FormPrincial_Load(object sender, EventArgs e)
        {
            ActualizarHora();

            if (_usuarioLogueado != null)
            {
                lblUserStatus.Text = $"Usuario: {_usuarioLogueado.Nombre} {_usuarioLogueado.Apellido} ({_usuarioLogueado.Rol})";
            }
            else
            {
                lblUserStatus.Text = "Usuario: Admin (Desarrollo)";
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            ActualizarHora();
        }

        private void ActualizarHora()
        {
            statusLblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea salir de la aplicación?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuItemCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar la sesión actual?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void menuItemCambiarContra_Click(object sender, EventArgs e)
        {
            if (_usuarioLogueado == null)
            {
                MessageBox.Show("No hay ninguna sesión de usuario activa para cambiar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (Login.FrmCambiarPassword frm = new Login.FrmCambiarPassword(_usuarioLogueado))
            {
                frm.ShowDialog();
            }
        }
        private void AbrirFormularioHijo(Form formHijo)
        {
            if (pnlContent.Controls.Count > 0)
            {
                foreach (Control control in pnlContent.Controls)
                {
                    control.Dispose();
                }
                pnlContent.Controls.Clear();
            }

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(formHijo);
            pnlContent.Tag = formHijo;
            formHijo.Show();
        }

        private void menuItemUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Usuarios, _usuarioLogueado));
        }

        private void MenuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Clientes, _usuarioLogueado));
        }

        private void MenuServicios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Servicios, _usuarioLogueado));
        }

        private void MenuTiposPrenda_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Prendas, _usuarioLogueado));
        }

        private void MenuOrdenes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Ordenes, _usuarioLogueado));
        }

        private void MenuReporteOrdenes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmReporteOrdenes());
        }

        private void MenuReporteHistorial_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmReporteHistorialOrden());
        }

        private void MenuReporteAuditoria_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmReporteAuditoria());
        }
    }
}
