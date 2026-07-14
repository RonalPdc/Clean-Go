using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Ordenes;
using Clean_Go_Entities.Ordenes;
using Clean_Go_Entities.Usuarios;
using Clean_Go.BusinessLogic;

namespace Clean_Go.BusinessLogic.Ordenes
{
    public partial class FrmOrdenes : Form
    {
        private readonly OrdenesBLL _ordenesBLL = new OrdenesBLL();
        private readonly Usuario _usuarioLogueado;

        public FrmOrdenes(Usuario usuarioLogueado)
        {
            InitializeComponent();
            _usuarioLogueado = usuarioLogueado;
            ConfigurarEventos();

            // Estilos Premium
            DisenoHelper.StyleButton(btnNuevo, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnCambiarEstado, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnBuscar, Color.FromArgb(71, 85, 105), Color.White);
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmOrdenes_Load;
            btnNuevo.Click += BtnNuevo_Click;
            btnCambiarEstado.Click += BtnCambiarEstado_Click;
            btnBuscar.Click += BtnBuscar_Click;
            txtBuscar.KeyDown += TxtBuscar_KeyDown;
            
            OrdenesBLL.AlCambiarOrdenes += CargarOrdenes;
            this.FormClosed += (s, e) => OrdenesBLL.AlCambiarOrdenes -= CargarOrdenes;
        }

        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvOrdenes);
            CargarOrdenes();
        }

        private void CargarOrdenes()
        {
            try
            {
                var ordenes = _ordenesBLL.ObtenerTodos();
                string filtro = txtBuscar.Text.Trim().ToLower();

                if (!string.IsNullOrEmpty(filtro))
                {
                    ordenes = ordenes.FindAll(o =>
                        (o.NumeroOrden != null && o.NumeroOrden.ToLower().Contains(filtro)) ||
                        o.ClienteId.ToString() == filtro ||
                        o.OrdenId.ToString() == filtro
                    );
                }

                dgvOrdenes.DataSource = ordenes;

                if (dgvOrdenes.Columns.Contains("OrdenId")) dgvOrdenes.Columns["OrdenId"].HeaderText = "ID";
                if (dgvOrdenes.Columns.Contains("NumeroOrden")) dgvOrdenes.Columns["NumeroOrden"].HeaderText = "Numero Orden";
                if (dgvOrdenes.Columns.Contains("ClienteId")) dgvOrdenes.Columns["ClienteId"].HeaderText = "Cliente ID";
                if (dgvOrdenes.Columns.Contains("FechaRecepcion")) dgvOrdenes.Columns["FechaRecepcion"].HeaderText = "Fecha Recepcion";
                if (dgvOrdenes.Columns.Contains("FechaEntregaEstimada")) dgvOrdenes.Columns["FechaEntregaEstimada"].HeaderText = "Entrega Estimada";
                if (dgvOrdenes.Columns.Contains("Total")) dgvOrdenes.Columns["Total"].HeaderText = "Total ($)";
                if (dgvOrdenes.Columns.Contains("EstadoId")) dgvOrdenes.Columns["EstadoId"].HeaderText = "Estado ID";
                if (dgvOrdenes.Columns.Contains("Observaciones")) dgvOrdenes.Columns["Observaciones"].HeaderText = "Observaciones";
                if (dgvOrdenes.Columns.Contains("UsuarioRegistroId")) dgvOrdenes.Columns["UsuarioRegistroId"].HeaderText = "Registrado Por (ID)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ordenes:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarOrdenes();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmOrdenesNuevo frm = new FrmOrdenesNuevo(_usuarioLogueado))
            {
                frm.ShowDialog();
            }
        }

        private void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una orden para cambiar de estado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Orden ordenSeleccionada = (Orden)dgvOrdenes.CurrentRow.DataBoundItem;
            using (FrmOrdenesCambiarEstado frm = new FrmOrdenesCambiarEstado(ordenSeleccionada, _usuarioLogueado))
            {
                frm.ShowDialog();
            }
        }
    }
}
