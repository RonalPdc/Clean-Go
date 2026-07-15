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

                        DisenoHelper.StyleButton(btnSalirApp, Color.FromArgb(239, 68, 68), Color.White);         }

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
            btnMenuPassword.Click += BtnMenuPassword_Click;
            btnMenuSalir.Click += BtnMenuSalir_Click;
            btnSalirApp.Click += BtnSalirApp_Click;

                        OrdenesBLL.AlCambiarOrdenes += ActualizarDashboard;
        }

        private void FormPrincial_Load(object sender, EventArgs e)
        {
            timerClock.Start();
            ActualizarHora();

                        TableLayoutPanel tblKpis = new TableLayoutPanel();
            tblKpis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tblKpis.Height = 95;
            tblKpis.Width = pnlDashboard.Width - 30;             tblKpis.Location = new Point(15, 20);
            tblKpis.ColumnCount = 4;
            tblKpis.RowCount = 1;
            
            tblKpis.ColumnStyles.Clear();
            tblKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblKpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            
            tblKpis.RowStyles.Clear();
            tblKpis.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            pnlDashboard.Controls.Remove(pnlKpiPendientes);
            pnlDashboard.Controls.Remove(pnlKpiProceso);
            pnlDashboard.Controls.Remove(pnlKpiListo);
            pnlDashboard.Controls.Remove(pnlKpiEntregado);

            pnlKpiPendientes.Dock = DockStyle.Fill;
            pnlKpiPendientes.Margin = new Padding(5, 0, 5, 0);
            pnlKpiProceso.Dock = DockStyle.Fill;
            pnlKpiProceso.Margin = new Padding(5, 0, 5, 0);
            pnlKpiListo.Dock = DockStyle.Fill;
            pnlKpiListo.Margin = new Padding(5, 0, 5, 0);
            pnlKpiEntregado.Dock = DockStyle.Fill;
            pnlKpiEntregado.Margin = new Padding(5, 0, 5, 0);

            tblKpis.Controls.Add(pnlKpiPendientes, 0, 0);
            tblKpis.Controls.Add(pnlKpiProceso, 1, 0);
            tblKpis.Controls.Add(pnlKpiListo, 2, 0);
            tblKpis.Controls.Add(pnlKpiEntregado, 3, 0);

            pnlDashboard.Controls.Add(tblKpis);

                        DisenoHelper.StyleGrid(dgvEntregasHoy);

            if (_usuarioLogueado != null)
            {
                lblUserStatus.Text = $"Usuario: {_usuarioLogueado.Nombre} {_usuarioLogueado.Apellido} ({_usuarioLogueado.Rol})";
                
                                if (_usuarioLogueado.Rol.ToLower() != "administrador")
                {
                    btnMenuUsuarios.Visible = false;
                }
            }
            else
            {
                lblUserStatus.Text = "Usuario: Admin (Desarrollo)";
            }

            SeleccionarBoton(btnMenuDashboard);
            ActualizarDashboard();

            DisenoHelper.StyleButton(btnMenuPassword, Color.White, Color.FromArgb(71, 85, 105));
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
                        if (_botonActivo != null)
            {
                _botonActivo.BackColor = Color.White;
                _botonActivo.ForeColor = Color.FromArgb(71, 85, 105);
            }

                        _botonActivo = boton;
            _botonActivo.BackColor = Color.FromArgb(8, 145, 178);
            _botonActivo.ForeColor = Color.White;
        }

        private void ActualizarDashboard()
        {
            try
            {
                                var conteos = _ordenesBLL.ObtenerConteosPorEstado();
                
                lblKpiPendientesValor.Text = conteos.ContainsKey(1) ? conteos[1].ToString() : "0";
                lblKpiProcesoValor.Text = conteos.ContainsKey(2) ? conteos[2].ToString() : "0";
                lblKpiListoValor.Text = conteos.ContainsKey(3) ? conteos[3].ToString() : "0";
                lblKpiEntregadoValor.Text = conteos.ContainsKey(4) ? conteos[4].ToString() : "0";

                                var listaOrdenes = _ordenesBLL.ObtenerTodos();
                
                System.Data.DataTable tabla = new System.Data.DataTable();
                tabla.Columns.Add("Orden");
                tabla.Columns.Add("Fecha");
                tabla.Columns.Add("Entrega");
                tabla.Columns.Add("Total");
                tabla.Columns.Add("Estado");

                foreach (var o in listaOrdenes)
                {
                    string estadoStr = "Recibida";
                    if (o.EstadoId == 2) estadoStr = "En Proceso";
                    else if (o.EstadoId == 3) estadoStr = "Lista para Entrega";
                    else if (o.EstadoId == 4) estadoStr = "Entregada";
                    else if (o.EstadoId == 5) estadoStr = "Cancelada";

                    tabla.Rows.Add(
                        o.NumeroOrden,
                        o.FechaRecepcion.ToString("dd/MM/yyyy hh:mm tt"),
                        o.FechaEntregaEstimada.ToString("dd/MM/yyyy"),
                        "$" + o.Total.ToString("0.00"),
                        estadoStr
                    );
                }

                dgvEntregasHoy.DataSource = null;
                dgvEntregasHoy.DataSource = tabla;

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

                        ContextMenuStrip menuReportes = new ContextMenuStrip();
            ToolStripMenuItem item1 = new ToolStripMenuItem("Reporte de Órdenes");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Historial de Orden");

            item1.Click += (s, ev) => AbrirFormularioHijo(new FrmReporteOrdenes(), "Reporte de Órdenes");
            item2.Click += (s, ev) => AbrirFormularioHijo(new FrmReporteHistorialOrden(), "Historial de Orden");

            menuReportes.Items.AddRange(new ToolStripItem[] { item1, item2 });
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

        private void BtnMenuPassword_Click(object sender, EventArgs e)
        {
            if (_usuarioLogueado == null)
            {
                MessageBox.Show("No hay un usuario activo registrado en la sesión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FrmUsuarioCambiarPassword frm = new FrmUsuarioCambiarPassword(_usuarioLogueado))
            {
                frm.ShowDialog();
            }
        }
    }

    public static class DisenoHelper
    {
        public static void StyleGrid(DataGridView dgv)
        {
            if (dgv == null) return;

                        var dgvType = dgv.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi?.SetValue(dgv, true, null);

                        dgv.BackgroundColor = Color.FromArgb(248, 250, 252);             dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(226, 232, 240); 
                        dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(8, 145, 178);             dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 38;

                        dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);             dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);             dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);             dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);             dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

                        dgv.RowTemplate.Height = 35;
            dgv.RowHeadersVisible = false;
            
                        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ReadOnly = true;
        }

        public static void StyleButton(Button btn, Color backColor, Color foreColor)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.UseVisualStyleBackColor = false;

                        btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(
                    Math.Max(0, backColor.R - 20),
                    Math.Max(0, backColor.G - 20),
                    Math.Max(0, backColor.B - 20)
                );
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = backColor;
            };
        }
    }
}
