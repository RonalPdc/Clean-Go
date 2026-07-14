using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go.BusinessLogic;

namespace Clean_Go.BusinessLogic.Reportes
{
    public partial class FrmReporteHistorialOrden : Form
    {
        public FrmReporteHistorialOrden()
        {
            InitializeComponent();

            // Estilos Premium
            DisenoHelper.StyleButton(btnBuscar, Color.FromArgb(8, 145, 178), Color.White);
        }

        private void FrmReporteHistorialOrden_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvDetalle);
            DisenoHelper.StyleGrid(dgvHistorial);
            CargarComboOrdenes();
        }

        private void CargarComboOrdenes()
        {
            try
            {
                DataTable tablaCombo = new DataTable();
                using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string sql = "SELECT o.NumeroOrden, o.NumeroOrden + ' - ' + c.Nombre + ' ' + c.Apellido + ' ($' + CAST(o.Total AS VARCHAR) + ')' AS DisplayLabel FROM Ordenes o INNER JOIN Clientes c ON o.ClienteId = c.ClienteId ORDER BY o.OrdenId DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                    adapter.Fill(tablaCombo);
                }

                txtNumeroOrden.DisplayMember = "DisplayLabel";
                txtNumeroOrden.ValueMember = "NumeroOrden";
                txtNumeroOrden.DataSource = tablaCombo;
                txtNumeroOrden.SelectedIndex = -1; // Iniciar sin selección
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
            if (txtNumeroOrden.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una orden de la lista para ver su historial.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string numeroOrden = txtNumeroOrden.SelectedValue.ToString();
            CargarHistorial(numeroOrden);
        }

        private void CargarHistorial(string numeroOrden)
        {
            try
            {
                DataTable tablaOrden = new DataTable();
                DataTable tablaHistorial = new DataTable();
                DataTable tablaDetalle = new DataTable();

                using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string sqlOrden = "SELECT o.OrdenId, o.NumeroOrden, c.Nombre + ' ' + c.Apellido AS Cliente, e.Nombre AS Estado, o.FechaRecepcion, o.FechaEntregaEstimada, o.Total, o.Observaciones FROM Ordenes o INNER JOIN Clientes c ON o.ClienteId = c.ClienteId INNER JOIN EstadosOrden e ON o.EstadoId = e.EstadoId WHERE o.NumeroOrden = '" + numeroOrden + "'";
                    SqlDataAdapter adapterOrden = new SqlDataAdapter(sqlOrden, cn);
                    adapterOrden.Fill(tablaOrden);

                    if (tablaOrden.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontro ninguna orden con el numero: " + numeroOrden, "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int ordenId = Convert.ToInt32(tablaOrden.Rows[0]["OrdenId"]);

                    string sqlHistorial = "SELECT h.HistorialId, ea.Nombre AS EstadoAnterior, en.Nombre AS EstadoNuevo, u.Nombre + ' ' + u.Apellido AS Usuario, h.Fecha, h.Comentario FROM HistorialEstados h LEFT JOIN EstadosOrden ea ON h.EstadoAnteriorId = ea.EstadoId INNER JOIN EstadosOrden en ON h.EstadoNuevoId = en.EstadoId INNER JOIN Usuarios u ON h.UsuarioId = u.UsuarioId WHERE h.OrdenId = " + ordenId + " ORDER BY h.Fecha";
                    SqlDataAdapter adapterHistorial = new SqlDataAdapter(sqlHistorial, cn);
                    adapterHistorial.Fill(tablaHistorial);

                    string sqlDetalle = "SELECT tp.Nombre AS Prenda, s.Nombre AS Servicio, d.Cantidad, d.Precio, (d.Cantidad * d.Precio) AS SubTotal, d.Observaciones FROM DetalleOrden d INNER JOIN TiposPrenda tp ON d.TipoPrendaId = tp.TipoPrendaId INNER JOIN Servicios s ON d.ServicioId = s.ServicioId WHERE d.OrdenId = " + ordenId;
                    SqlDataAdapter adapterDetalle = new SqlDataAdapter(sqlDetalle, cn);
                    adapterDetalle.Fill(tablaDetalle);
                }

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
