using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go.BusinessLogic;
using Clean_Go_BusinessLogic.Service.Ordenes;

namespace Clean_Go.BusinessLogic.Reportes
{
    public partial class FrmReporteOrdenes : Form
    {
        private readonly OrdenesBLL _ordenesBLL = new OrdenesBLL();

        public FrmReporteOrdenes()
        {
            InitializeComponent();

            DisenoHelper.StyleButton(btnFiltrar, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnLimpiar, Color.FromArgb(71, 85, 105), Color.White);
        }

        private void FrmReporteOrdenes_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvOrdenes);
            CargarEstados();
            CargarOrdenes();

            cmbEstado.Width = 90;

            Button btnImprimir = new Button();
            btnImprimir.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnImprimir.BackColor = Color.FromArgb(8, 145, 178);
            btnImprimir.Cursor = Cursors.Hand;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(550, 15);
            btnImprimir.Size = new Size(110, 30);
            btnImprimir.Text = "Imprimir / PDF";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;

            this.Controls.Add(btnImprimir);
            btnImprimir.BringToFront();
        }

        private void CargarEstados()
        {
            try
            {
                cmbEstado.Items.Clear();
                cmbEstado.Items.Add("Todos");

                List<string> estados = _ordenesBLL.ObtenerTodosEstados();
                foreach (var est in estados)
                {
                    cmbEstado.Items.Add(est);
                }

                cmbEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estados:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarOrdenes()
        {
            try
            {
                DateTime? desde = dtpDesde.Checked ? (DateTime?)dtpDesde.Value.Date : null;
                DateTime? hasta = dtpHasta.Checked ? (DateTime?)dtpHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59) : null;
                string estado = cmbEstado.SelectedIndex > 0 ? cmbEstado.SelectedItem.ToString() : "Todos";

                DataTable tabla = _ordenesBLL.ObtenerReporteOrdenes(desde, hasta, estado);
                dgvOrdenes.DataSource = tabla;

                if (dgvOrdenes.Columns.Contains("OrdenId"))
                    dgvOrdenes.Columns["OrdenId"].HeaderText = "ID";
                if (dgvOrdenes.Columns.Contains("NumeroOrden"))
                    dgvOrdenes.Columns["NumeroOrden"].HeaderText = "Número Orden";
                if (dgvOrdenes.Columns.Contains("FechaRecepcion"))
                    dgvOrdenes.Columns["FechaRecepcion"].HeaderText = "Fecha Recepción";
                if (dgvOrdenes.Columns.Contains("FechaEntregaEstimada"))
                    dgvOrdenes.Columns["FechaEntregaEstimada"].HeaderText = "Entrega Estimada";

                lblTotalOrdenes.Text = "Total de órdenes: " + tabla.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar órdenes:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
            cmbEstado.SelectedIndex = 0;
            CargarOrdenes();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable tabla = dgvOrdenes.DataSource as DataTable;
            if (tabla == null || tabla.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmVisualizadorReporte frm = new FrmVisualizadorReporte(tabla);
            frm.ShowDialog();
        }
    }
}
