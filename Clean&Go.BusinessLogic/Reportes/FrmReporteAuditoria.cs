using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Clean_Go_DataAccess.ConexionBD;

namespace Clean_Go.BusinessLogic.Reportes
{
    public partial class FrmReporteAuditoria : Form
    {
        public FrmReporteAuditoria()
        {
            InitializeComponent();
        }

        private void FrmReporteAuditoria_Load(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        private void CargarAuditoria()
        {
            try
            {
                DataTable tabla = new DataTable();

                using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string sql = "SELECT a.AuditoriaId, u.Nombre + ' ' + u.Apellido AS Usuario, a.Accion, a.TablaAfectada, a.RegistroId, a.Fecha, a.Descripcion FROM Auditoria a INNER JOIN Usuarios u ON a.UsuarioId = u.UsuarioId WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                        sql += " AND (u.Nombre LIKE '%" + txtBuscar.Text.Trim() + "%' OR u.Apellido LIKE '%" + txtBuscar.Text.Trim() + "%' OR a.Accion LIKE '%" + txtBuscar.Text.Trim() + "%')";

                    if (dtpDesde.Checked)
                        sql += " AND a.Fecha >= '" + dtpDesde.Value.ToString("yyyy-MM-dd") + "'";

                    if (dtpHasta.Checked)
                        sql += " AND a.Fecha <= '" + dtpHasta.Value.ToString("yyyy-MM-dd") + " 23:59:59'";

                    sql += " ORDER BY a.Fecha DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                    adapter.Fill(tabla);
                }

                dgvAuditoria.DataSource = tabla;

                if (dgvAuditoria.Columns.Contains("AuditoriaId"))
                    dgvAuditoria.Columns["AuditoriaId"].HeaderText = "ID";
                if (dgvAuditoria.Columns.Contains("TablaAfectada"))
                    dgvAuditoria.Columns["TablaAfectada"].HeaderText = "Tabla";
                if (dgvAuditoria.Columns.Contains("RegistroId"))
                    dgvAuditoria.Columns["RegistroId"].HeaderText = "ID Registro";

                lblTotal.Text = "Total de registros: " + tabla.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar auditoria:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
            CargarAuditoria();
        }
    }
}
