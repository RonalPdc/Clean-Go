using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Clean_Go.BusinessLogic.Reportes
{
    public partial class FrmVisualizadorReporte : Form
    {
        private DataTable _tablaDatos;

        public FrmVisualizadorReporte(DataTable tablaDatos)
        {
            InitializeComponent();
            _tablaDatos = tablaDatos;
            this.Load += FrmVisualizadorReporte_Load;
        }

        private void FrmVisualizadorReporte_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportPath = "Reportes/ReporteOrdenes.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("dsOrdenes", _tablaDatos);
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar visor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
