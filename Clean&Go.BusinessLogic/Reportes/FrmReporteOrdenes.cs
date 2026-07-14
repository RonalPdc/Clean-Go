using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go_DataAccess.ConexionBD;
using Clean_Go.BusinessLogic;

namespace Clean_Go.BusinessLogic.Reportes
{
    public partial class FrmReporteOrdenes : Form
    {
        public FrmReporteOrdenes()
        {
            InitializeComponent();

            // Estilos Premium
            DisenoHelper.StyleButton(btnFiltrar, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnLimpiar, Color.FromArgb(71, 85, 105), Color.White);
        }

        private void FrmReporteOrdenes_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvOrdenes);
            CargarEstados();
            CargarOrdenes();
        }

        private void CargarEstados()
        {
            try
            {
                cmbEstado.Items.Clear();
                cmbEstado.Items.Add("Todos");

                using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("EstadosOrden_GetAll", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                cmbEstado.Items.Add(dr["Nombre"].ToString());
                            }
                        }
                    }
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
                DataTable tabla = new DataTable();

                using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string sql = "SELECT o.OrdenId, o.NumeroOrden, c.Nombre + ' ' + c.Apellido AS Cliente, e.Nombre AS Estado, o.FechaRecepcion, o.FechaEntregaEstimada, o.Total FROM Ordenes o INNER JOIN Clientes c ON o.ClienteId = c.ClienteId INNER JOIN EstadosOrden e ON o.EstadoId = e.EstadoId WHERE 1=1";

                    if (dtpDesde.Checked)
                        sql += " AND o.FechaRecepcion >= '" + dtpDesde.Value.ToString("yyyy-MM-dd") + "'";

                    if (dtpHasta.Checked)
                        sql += " AND o.FechaRecepcion <= '" + dtpHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";

                    if (cmbEstado.SelectedIndex > 0)
                        sql += " AND e.Nombre = '" + cmbEstado.SelectedItem.ToString() + "'";

                    sql += " ORDER BY o.FechaRecepcion DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                    adapter.Fill(tabla);
                }

                dgvOrdenes.DataSource = tabla;

                if (dgvOrdenes.Columns.Contains("OrdenId"))
                    dgvOrdenes.Columns["OrdenId"].HeaderText = "ID";
                if (dgvOrdenes.Columns.Contains("NumeroOrden"))
                    dgvOrdenes.Columns["NumeroOrden"].HeaderText = "N\u00famero Orden";
                if (dgvOrdenes.Columns.Contains("FechaRecepcion"))
                    dgvOrdenes.Columns["FechaRecepcion"].HeaderText = "Fecha Recepci\u00f3n";
                if (dgvOrdenes.Columns.Contains("FechaEntregaEstimada"))
                    dgvOrdenes.Columns["FechaEntregaEstimada"].HeaderText = "Entrega Estimada";

                lblTotalOrdenes.Text = "Total de \u00f3rdenes: " + tabla.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar \u00f3rdenes:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
