using System.Drawing;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic.Clientes
{
    partial class FrmClienteEditar
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblCedula;
        private TextBox txtCedula;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Label lblTelegramChatId;
        private TextBox txtTelegramChatId;
        private CheckBox chkEstado;
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelegramChatId = new System.Windows.Forms.Label();
            this.txtTelegramChatId = new System.Windows.Forms.TextBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(147, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle del Cliente";

            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNombre.Location = new System.Drawing.Point(20, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";

            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtNombre.Location = new System.Drawing.Point(130, 57);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 24);
            this.txtNombre.TabIndex = 0;

            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblApellido.Location = new System.Drawing.Point(20, 95);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(59, 17);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido:";

            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtApellido.Location = new System.Drawing.Point(130, 92);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 24);
            this.txtApellido.TabIndex = 1;

            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCedula.Location = new System.Drawing.Point(20, 130);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(51, 17);
            this.lblCedula.TabIndex = 5;
            this.lblCedula.Text = "Cedula:";

            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCedula.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCedula.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtCedula.Location = new System.Drawing.Point(130, 127);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(200, 24);
            this.txtCedula.TabIndex = 2;

            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTelefono.Location = new System.Drawing.Point(20, 165);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 17);
            this.lblTelefono.TabIndex = 7;
            this.lblTelefono.Text = "Telefono:";

            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefono.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtTelefono.Location = new System.Drawing.Point(130, 162);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 24);
            this.txtTelefono.TabIndex = 3;

            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCorreo.Location = new System.Drawing.Point(20, 200);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(52, 17);
            this.lblCorreo.TabIndex = 9;
            this.lblCorreo.Text = "Correo:";

            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtCorreo.Location = new System.Drawing.Point(130, 197);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(200, 24);
            this.txtCorreo.TabIndex = 4;

            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDireccion.Location = new System.Drawing.Point(20, 235);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 17);
            this.lblDireccion.TabIndex = 11;
            this.lblDireccion.Text = "Direccion:";

            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccion.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtDireccion.Location = new System.Drawing.Point(130, 232);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 24);
            this.txtDireccion.TabIndex = 5;

            this.lblTelegramChatId.AutoSize = true;
            this.lblTelegramChatId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTelegramChatId.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTelegramChatId.Location = new System.Drawing.Point(20, 270);
            this.lblTelegramChatId.Name = "lblTelegramChatId";
            this.lblTelegramChatId.Size = new System.Drawing.Size(107, 17);
            this.lblTelegramChatId.TabIndex = 13;
            this.lblTelegramChatId.Text = "Telegram ChatID:";

            this.txtTelegramChatId.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtTelegramChatId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelegramChatId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelegramChatId.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtTelegramChatId.Location = new System.Drawing.Point(130, 267);
            this.txtTelegramChatId.Name = "txtTelegramChatId";
            this.txtTelegramChatId.Size = new System.Drawing.Size(200, 24);
            this.txtTelegramChatId.TabIndex = 6;

            this.chkEstado.AutoSize = true;
            this.chkEstado.Checked = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkEstado.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.chkEstado.Location = new System.Drawing.Point(130, 305);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(61, 21);
            this.chkEstado.TabIndex = 7;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(130, 345);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 33);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(235, 345);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 33);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 410);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.txtTelegramChatId);
            this.Controls.Add(this.lblTelegramChatId);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClienteEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
