using System.Drawing;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic.Ordenes
{
    partial class FrmOrdenesCambiarEstado
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblEstadoActual;
        private TextBox txtEstadoActual;
        private Label lblNuevoEstado;
        private ComboBox cmbNuevoEstado;
        private Label lblComentario;
        private TextBox txtComentario;
        private Button btnGuardar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.txtEstadoActual = new System.Windows.Forms.TextBox();
            this.lblNuevoEstado = new System.Windows.Forms.Label();
            this.cmbNuevoEstado = new System.Windows.Forms.ComboBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cambiar Estado de la Orden";

            this.lblEstadoActual.AutoSize = true;
            this.lblEstadoActual.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEstadoActual.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblEstadoActual.Location = new System.Drawing.Point(20, 60);
            this.lblEstadoActual.Name = "lblEstadoActual";
            this.lblEstadoActual.Size = new System.Drawing.Size(88, 17);
            this.lblEstadoActual.TabIndex = 1;
            this.lblEstadoActual.Text = "Estado Actual:";

            this.txtEstadoActual.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtEstadoActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstadoActual.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEstadoActual.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtEstadoActual.Location = new System.Drawing.Point(120, 57);
            this.txtEstadoActual.Name = "txtEstadoActual";
            this.txtEstadoActual.ReadOnly = true;
            this.txtEstadoActual.Size = new System.Drawing.Size(200, 24);
            this.txtEstadoActual.TabIndex = 2;

            this.lblNuevoEstado.AutoSize = true;
            this.lblNuevoEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNuevoEstado.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNuevoEstado.Location = new System.Drawing.Point(20, 95);
            this.lblNuevoEstado.Name = "lblNuevoEstado";
            this.lblNuevoEstado.Size = new System.Drawing.Size(92, 17);
            this.lblNuevoEstado.TabIndex = 3;
            this.lblNuevoEstado.Text = "Nuevo Estado:";

            this.cmbNuevoEstado.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.cmbNuevoEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNuevoEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNuevoEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbNuevoEstado.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.cmbNuevoEstado.FormattingEnabled = true;
            this.cmbNuevoEstado.Location = new System.Drawing.Point(120, 92);
            this.cmbNuevoEstado.Name = "cmbNuevoEstado";
            this.cmbNuevoEstado.Size = new System.Drawing.Size(200, 25);
            this.cmbNuevoEstado.TabIndex = 0;

            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblComentario.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblComentario.Location = new System.Drawing.Point(20, 130);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(78, 17);
            this.lblComentario.TabIndex = 5;
            this.lblComentario.Text = "Comentario:";

            this.txtComentario.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtComentario.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtComentario.Location = new System.Drawing.Point(120, 127);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(200, 80);
            this.txtComentario.TabIndex = 1;

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(120, 225);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 33);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Confirmar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(225, 225);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 33);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 280);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.cmbNuevoEstado);
            this.Controls.Add(this.lblNuevoEstado);
            this.Controls.Add(this.txtEstadoActual);
            this.Controls.Add(this.lblEstadoActual);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOrdenesCambiarEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambiar Estado";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
