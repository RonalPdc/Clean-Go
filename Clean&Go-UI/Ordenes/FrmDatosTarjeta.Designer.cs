using System.Drawing;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic.Ordenes
{
    partial class FrmDatosTarjeta
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblNumeroTarjeta;
        private TextBox txtNumeroTarjeta;
        private Label lblExpiracion;
        private TextBox txtExpiracion;
        private Label lblCvv;
        private TextBox txtCvv;
        private Button btnConfirmar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNumeroTarjeta = new System.Windows.Forms.Label();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.lblExpiracion = new System.Windows.Forms.Label();
            this.txtExpiracion = new System.Windows.Forms.TextBox();
            this.lblCvv = new System.Windows.Forms.Label();
            this.txtCvv = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(166, 21);
            this.lblTitulo.Text = "Procesar Pago Tarjeta";
            // 
            // lblNumeroTarjeta
            // 
            this.lblNumeroTarjeta.AutoSize = true;
            this.lblNumeroTarjeta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNumeroTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNumeroTarjeta.Location = new System.Drawing.Point(20, 55);
            this.lblNumeroTarjeta.Name = "lblNumeroTarjeta";
            this.lblNumeroTarjeta.Size = new System.Drawing.Size(123, 17);
            this.lblNumeroTarjeta.Text = "Numero de Tarjeta:";
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtNumeroTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroTarjeta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNumeroTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(20, 77);
            this.txtNumeroTarjeta.MaxLength = 16;
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(260, 24);
            // 
            // lblExpiracion
            // 
            this.lblExpiracion.AutoSize = true;
            this.lblExpiracion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblExpiracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblExpiracion.Location = new System.Drawing.Point(20, 115);
            this.lblExpiracion.Name = "lblExpiracion";
            this.lblExpiracion.Size = new System.Drawing.Size(130, 17);
            this.lblExpiracion.Text = "Vencimiento (MM/AA):";
            // 
            // txtExpiracion
            // 
            this.txtExpiracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtExpiracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpiracion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtExpiracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtExpiracion.Location = new System.Drawing.Point(20, 137);
            this.txtExpiracion.MaxLength = 5;
            this.txtExpiracion.Name = "txtExpiracion";
            this.txtExpiracion.Size = new System.Drawing.Size(120, 24);
            // 
            // lblCvv
            // 
            this.lblCvv.AutoSize = true;
            this.lblCvv.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCvv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCvv.Location = new System.Drawing.Point(160, 115);
            this.lblCvv.Name = "lblCvv";
            this.lblCvv.Size = new System.Drawing.Size(35, 17);
            this.lblCvv.Text = "CVV:";
            // 
            // txtCvv
            // 
            this.txtCvv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtCvv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCvv.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCvv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtCvv.Location = new System.Drawing.Point(160, 137);
            this.txtCvv.MaxLength = 3;
            this.txtCvv.Name = "txtCvv";
            this.txtCvv.Size = new System.Drawing.Size(120, 24);
            this.txtCvv.UseSystemPasswordChar = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(20, 190);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(120, 32);
            this.btnConfirmar.Text = "Confirmar Pago";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(160, 190);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FrmDatosTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(305, 245);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtCvv);
            this.Controls.Add(this.lblCvv);
            this.Controls.Add(this.txtExpiracion);
            this.Controls.Add(this.lblExpiracion);
            this.Controls.Add(this.txtNumeroTarjeta);
            this.Controls.Add(this.lblNumeroTarjeta);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDatosTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos de Pago";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
