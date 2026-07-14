using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go_Entities.Usuarios;
using Clean_Go.BusinessLogic.Usuarios;
using Clean_Go.BusinessLogic.Patterns.Factory;
using Clean_Go.BusinessLogic.Reportes;
using Clean_Go_BusinessLogic.Service.Ordenes;
using Clean_Go_Entities.Ordenes;

namespace Clean_Go.BusinessLogic
{
    public partial class FormPrincial : Form
    {
        private readonly Usuario _usuarioLogueado;
        private readonly OrdenesBLL _ordenesBLL = new OrdenesBLL();
        private Button _botonActivo = null;

        public FormPrincial()
        {
            InitializeComponent();
        }

        public FormPrincial(Usuario usuario) : this()
        {
            _usuarioLogueado = usuario;
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            this.Load += FormPrincial_Load;
            timerClock.Tick += timerClock_Tick;

            btnMenuDashboard.Click += BtnMenuDashboard_Click;
            btnMenuClientes.Click += BtnMenuClientes_Click;
            btnMenuServicios.Click += BtnMenuServicios_Click;
            btnMenuPrendas.Click += BtnMenuPrendas_Click;
            btnMenuOrdenes.Click += BtnMenuOrdenes_Click;
            btnMenuReportes.Click += BtnMenuReportes_Click;
            btnMenuUsuarios.Click += BtnMenuUsuarios_Click;
            btnMenuSalir.Click += BtnMenuSalir_Click;
            btnSalirApp.Click += BtnSalirApp_Click;

            // Lógica de sincronización si cambian las órdenes en el sistema
            OrdenesBLL.AlCambiarOrdenes += ActualizarDashboard;
        }

        private void FormPrincial_Load(object sender, EventArgs e)
        {
            timerClock.Start();
            ActualizarHora();

            if (_usuarioLogueado != null)
            {
                lblUserStatus.Text = $"Usuario: {_usuarioLogueado.Nombre} {_usuarioLogueado.Apellido} ({_usuarioLogueado.Rol})";
                
                // Restricción básica por rol
                if (_usuarioLogueado.Rol.ToLower() != "administrador")
                {
                    btnMenuUsuarios.Visible = false;
                }
            }
            else
            {
                lblUserStatus.Text = "Usuario: Admin (Desarrollo)";
            }

            // Activar botón Dashboard por defecto al iniciar
            SeleccionarBoton(btnMenuDashboard);
            ActualizarDashboard();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            ActualizarHora();
        }

        private void ActualizarHora()
        {
            statusLblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void SeleccionarBoton(Button boton)
        {
            // Restablecer el diseño del botón activo anterior
            if (_botonActivo != null)
            {
                _botonActivo.BackColor = Color.White;
                _botonActivo.ForeColor = Color.FromArgb(71, 85, 105);
            }

            // Aplicar estilo activo al botón actual (azul Clean&Go corporativo)
            _botonActivo = boton;
            _botonActivo.BackColor = Color.FromArgb(8, 145, 178);
            _botonActivo.ForeColor = Color.White;
        }

        private void ActualizarDashboard()
        {
            try
            {
                // 1. Obtener conteos de la base de datos
                var conteos = _ordenesBLL.ObtenerConteosPorEstado();
                
                lblKpiPendientesValor.Text = conteos.ContainsKey(1) ? conteos[1].ToString() : "0";
                lblKpiProcesoValor.Text = conteos.ContainsKey(2) ? conteos[2].ToString() : "0";
                lblKpiListoValor.Text = conteos.ContainsKey(3) ? conteos[3].ToString() : "0";
                lblKpiEntregadoValor.Text = conteos.ContainsKey(4) ? conteos[4].ToString() : "0";

                // 2. Cargar órdenes de hoy / recientes en la grilla
                var listaOrdenes = _ordenesBLL.ObtenerTodos();
                
                // Mapeo simple a una estructura ligera para que se vea elegante en la tabla de control
                var vistaSimplificada = new List<object>();
                foreach (var o in listaOrdenes)
                {
                    string estadoStr = "Recibida";
                    if (o.EstadoId == 2) estadoStr = "En Proceso";
                    else if (o.EstadoId == 3) estadoStr = "Lista para Entrega";
                    else if (o.EstadoId == 4) estadoStr = "Entregada";
                    else if (o.EstadoId == 5) estadoStr = "Cancelada";

                    vistaSimplificada.Add(new
                    {
                        Orden = o.NumeroOrden,
                        Fecha = o.FechaRecepcion.ToString("dd/MM/yyyy hh:mm tt"),
                        Entrega = o.FechaEntregaEstimada.ToString("dd/MM/yyyy"),
                        Total = "$" + o.Total.ToString("0.00"),
                        Estado = estadoStr
                    });
                }

                dgvEntregasHoy.DataSource = null;
                dgvEntregasHoy.DataSource = vistaSimplificada;

                // Estilizar la tabla del Dashboard
                if (dgvEntregasHoy.Columns.Contains("Orden")) dgvEntregasHoy.Columns["Orden"].HeaderText = "N° Orden";
                if (dgvEntregasHoy.Columns.Contains("Fecha")) dgvEntregasHoy.Columns["Fecha"].HeaderText = "Fecha Ingreso";
                if (dgvEntregasHoy.Columns.Contains("Entrega")) dgvEntregasHoy.Columns["Entrega"].HeaderText = "F. Estimada Entrega";
                if (dgvEntregasHoy.Columns.Contains("Total")) dgvEntregasHoy.Columns["Total"].HeaderText = "Total";
                if (dgvEntregasHoy.Columns.Contains("Estado")) dgvEntregasHoy.Columns["Estado"].HeaderText = "Estado Actual";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al actualizar dashboard: " + ex.Message);
            }
        }

        private void AbrirFormularioHijo(Form formHijo, string titulo)
        {
            lblHeaderTitle.Text = titulo;

            // Limpiar y preparar panel de contenido
            pnlContent.Controls.Clear();

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(formHijo);
            pnlContent.Tag = formHijo;
            formHijo.Show();
        }

        private void BtnMenuDashboard_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMenuDashboard);
            lblHeaderTitle.Text = "Panel de Control";

            // Limpiar panel y volver a colocar el Dashboard
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(pnlDashboard);
            ActualizarDashboard();
        }

        private void BtnMenuClientes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMenuClientes);
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Clientes, _usuarioLogueado), "Administración de Clientes");
        }

        private void BtnMenuServicios_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMenuServicios);
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Servicios, _usuarioLogueado), "Servicios Ofertados");
        }

        private void BtnMenuPrendas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMenuPrendas);
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Prendas, _usuarioLogueado), "Catálogo de Prendas");
        }

        private void BtnMenuOrdenes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMenuOrdenes);
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Ordenes, _usuarioLogueado), "Órdenes de Trabajo");
        }

        private void BtnMenuReportes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMenuReportes);

            // Crear un menú contextual para elegir el reporte
            ContextMenuStrip menuReportes = new ContextMenuStrip();
            ToolStripMenuItem item1 = new ToolStripMenuItem("Reporte de Órdenes");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Historial de Orden");
            ToolStripMenuItem item3 = new ToolStripMenuItem("Auditoría del Sistema");

            item1.Click += (s, ev) => AbrirFormularioHijo(new FrmReporteOrdenes(), "Reporte de Órdenes");
            item2.Click += (s, ev) => AbrirFormularioHijo(new FrmReporteHistorialOrden(), "Historial de Orden");
            item3.Click += (s, ev) => AbrirFormularioHijo(new FrmReporteAuditoria(), "Auditoría de Acciones");

            menuReportes.Items.AddRange(new ToolStripItem[] { item1, item2, item3 });
            menuReportes.Show(btnMenuReportes, new Point(btnMenuReportes.Width, 0));
        }

        private void BtnMenuUsuarios_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMenuUsuarios);
            AbrirFormularioHijo(FormFactory.Crear(TipoModulo.Usuarios, _usuarioLogueado), "Seguridad y Usuarios");
        }

        private void BtnMenuSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar la sesión actual?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void BtnSalirApp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea salir de la aplicación?", "Salir del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
