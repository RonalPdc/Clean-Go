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

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;

                        if (dtpDesde.Checked)
                        {
                            sql += " AND o.FechaRecepcion >= @Desde";
                            cmd.Parameters.Add("@Desde", SqlDbType.DateTime).Value = dtpDesde.Value.Date;
                        }

                        if (dtpHasta.Checked)
                        {
                            sql += " AND o.FechaRecepcion <= @Hasta";
                            cmd.Parameters.Add("@Hasta", SqlDbType.DateTime).Value = dtpHasta.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                        }

                        if (cmbEstado.SelectedIndex > 0)
                        {
                            sql += " AND e.Nombre = @Estado";
                            cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = cmbEstado.SelectedItem.ToString();
                        }

                        sql += " ORDER BY o.FechaRecepcion DESC";
                        cmd.CommandText = sql;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tabla);
                    }
                }

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
    }
}
