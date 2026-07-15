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

            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;

            CargarOrdenes();
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
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                string estado = "";
                if (cmbEstado.SelectedIndex > 0)
                {
                    estado = cmbEstado.SelectedItem.ToString();
                }
                else
                {
                    estado = "Todos";
                }

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
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;
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
