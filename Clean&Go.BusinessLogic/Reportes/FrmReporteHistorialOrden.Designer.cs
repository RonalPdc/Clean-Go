using System.Drawing;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic.Reportes
{
    partial class FrmReporteHistorialOrden
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelSuperior;
        private Label lblTitulo;
        private Label lblNumero;
        private TextBox txtNumeroOrden;
        private Button btnBuscar;
        private Label lblOrdenInfo;
        private Label lblHistorialTitulo;
        private DataGridView dgvHistorial;
        private Label lblDetalleTitulo;
        private DataGridView dgvDetalle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumeroOrden = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblOrdenInfo = new System.Windows.Forms.Label();
            this.lblHistorialTitulo = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblDetalleTitulo = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();

            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(14, 116, 144);
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(900, 50);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Historial de Orden";

            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNumero.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNumero.Location = new System.Drawing.Point(15, 65);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Text = "N\u00famero de Orden:";

            this.txtNumeroOrden.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtNumeroOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroOrden.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNumeroOrden.Location = new System.Drawing.Point(135, 62);
            this.txtNumeroOrden.Name = "txtNumeroOrden";
            this.txtNumeroOrden.Size = new System.Drawing.Size(180, 24);
            this.txtNumeroOrden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroOrden_KeyDown);

            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(14, 116, 144);
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(325, 60);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.lblOrdenInfo.AutoSize = false;
            this.lblOrdenInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOrdenInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblOrdenInfo.Location = new System.Drawing.Point(15, 100);
            this.lblOrdenInfo.Name = "lblOrdenInfo";
            this.lblOrdenInfo.Size = new System.Drawing.Size(870, 20);
            this.lblOrdenInfo.Text = "";

            this.lblDetalleTitulo.AutoSize = true;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalleTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblDetalleTitulo.Location = new System.Drawing.Point(15, 125);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Text = "Detalle de la Orden:";

            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(14, 116, 144);
            this.dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDetalle.Location = new System.Drawing.Point(15, 145);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(870, 150);

            this.lblHistorialTitulo.AutoSize = true;
            this.lblHistorialTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistorialTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblHistorialTitulo.Location = new System.Drawing.Point(15, 310);
            this.lblHistorialTitulo.Name = "lblHistorialTitulo";
            this.lblHistorialTitulo.Text = "Historial de Cambios de Estado:";

            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvHistorial.Location = new System.Drawing.Point(15, 330);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(870, 180);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 530);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.lblHistorialTitulo);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblDetalleTitulo);
            this.Controls.Add(this.lblOrdenInfo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNumeroOrden);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.panelSuperior);
            this.Load += new System.EventHandler(this.FrmReporteHistorialOrden_Load);
            this.Name = "FrmReporteHistorialOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de Orden";
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
