using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go.BusinessLogic;
using Clean_Go_BusinessLogic.Service.Ordenes;

namespace Clean_Go.BusinessLogic.Reportes
{
    public partial class FrmReporteHistorialOrden : Form
    {
        private readonly OrdenesBLL _ordenesBLL = new OrdenesBLL();

        public FrmReporteHistorialOrden()
        {
            InitializeComponent();

            DisenoHelper.StyleButton(btnBuscar, Color.FromArgb(8, 145, 178), Color.White);
        }

        private void FrmReporteHistorialOrden_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvDetalle);
            DisenoHelper.StyleGrid(dgvHistorial);

            txtNumeroOrden.DropDownStyle = ComboBoxStyle.DropDown;
            txtNumeroOrden.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNumeroOrden.AutoCompleteSource = AutoCompleteSource.ListItems;

            CargarComboOrdenes();
        }

        private void CargarComboOrdenes()
        {
            try
            {
                DataTable tablaCombo = _ordenesBLL.ObtenerComboList();

                txtNumeroOrden.DisplayMember = "DisplayLabel";
                txtNumeroOrden.ValueMember = "NumeroOrden";
                txtNumeroOrden.DataSource = tablaCombo;
                txtNumeroOrden.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar listado de órdenes:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNumeroOrden.SelectedValue != null && txtNumeroOrden.Focused)
            {
                string numeroOrden = txtNumeroOrden.SelectedValue.ToString();
                CargarHistorial(numeroOrden);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNumeroOrden.Text == "")
            {
                MessageBox.Show("Seleccione una orden de la lista para ver su historial.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string numeroOrden = txtNumeroOrden.Text;
            CargarHistorial(numeroOrden);
        }

        private void CargarHistorial(string numeroOrden)
        {
            try
            {
                DataTable tablaOrden = _ordenesBLL.ObtenerPorNumero(numeroOrden);

                if (tablaOrden.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro ninguna orden con el numero: " + numeroOrden, "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int ordenId = Convert.ToInt32(tablaOrden.Rows[0]["OrdenId"]);
                DataTable tablaHistorial = _ordenesBLL.ObtenerHistorialEstados(ordenId);
                DataTable tablaDetalle = _ordenesBLL.ObtenerDetalle(ordenId);

                DataRow fila = tablaOrden.Rows[0];
                lblOrdenInfo.Text = "Orden: " + fila["NumeroOrden"].ToString() + "  |  Cliente: " + fila["Cliente"].ToString() + "  |  Estado: " + fila["Estado"].ToString() + "  |  Total: $" + fila["Total"].ToString();

                dgvHistorial.DataSource = tablaHistorial;
                dgvDetalle.DataSource = tablaDetalle;

                if (dgvHistorial.Columns.Contains("HistorialId"))
                    dgvHistorial.Columns["HistorialId"].Visible = false;
                if (dgvHistorial.Columns.Contains("EstadoAnterior"))
                    dgvHistorial.Columns["EstadoAnterior"].HeaderText = "Estado Anterior";
                if (dgvHistorial.Columns.Contains("EstadoNuevo"))
                    dgvHistorial.Columns["EstadoNuevo"].HeaderText = "Estado Nuevo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
