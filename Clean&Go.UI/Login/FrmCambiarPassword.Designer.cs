namespace Clean_Go.BusinessLogic.Login
{
    partial class FrmCambiarPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelSeparatorHeader = new System.Windows.Forms.Panel();
            this.lblPasswordActual = new System.Windows.Forms.Label();
            this.txtPasswordActual = new System.Windows.Forms.TextBox();
            this.lblPasswordNuevo = new System.Windows.Forms.Label();
            this.txtPasswordNuevo = new System.Windows.Forms.TextBox();
            this.lblPasswordConfirmar = new System.Windows.Forms.Label();
            this.txtPasswordConfirmar = new System.Windows.Forms.TextBox();
            this.panelSeparatorFooter = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkMostrarPassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(182, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cambiar Contraseña";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitulo.Location = new System.Drawing.Point(21, 37);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(236, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Complete los campos para actualizar su clave.";
            // 
            // panelSeparatorHeader
            // 
            this.panelSeparatorHeader.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.panelSeparatorHeader.Location = new System.Drawing.Point(0, 60);
            this.panelSeparatorHeader.Name = "panelSeparatorHeader";
            this.panelSeparatorHeader.Size = new System.Drawing.Size(350, 1);
            this.panelSeparatorHeader.TabIndex = 2;
            // 
            // lblPasswordActual
            // 
            this.lblPasswordActual.AutoSize = true;
            this.lblPasswordActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordActual.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPasswordActual.Location = new System.Drawing.Point(25, 75);
            this.lblPasswordActual.Name = "lblPasswordActual";
            this.lblPasswordActual.Size = new System.Drawing.Size(111, 15);
            this.lblPasswordActual.TabIndex = 3;
            this.lblPasswordActual.Text = "Contraseña Actual:";
            // 
            // txtPasswordActual
            // 
            this.txtPasswordActual.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtPasswordActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordActual.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPasswordActual.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtPasswordActual.Location = new System.Drawing.Point(25, 95);
            this.txtPasswordActual.Name = "txtPasswordActual";
            this.txtPasswordActual.Size = new System.Drawing.Size(300, 25);
            this.txtPasswordActual.TabIndex = 4;
            this.txtPasswordActual.UseSystemPasswordChar = true;
            // 
            // lblPasswordNuevo
            // 
            this.lblPasswordNuevo.AutoSize = true;
            this.lblPasswordNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordNuevo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPasswordNuevo.Location = new System.Drawing.Point(25, 135);
            this.lblPasswordNuevo.Name = "lblPasswordNuevo";
            this.lblPasswordNuevo.Size = new System.Drawing.Size(110, 15);
            this.lblPasswordNuevo.TabIndex = 5;
            this.lblPasswordNuevo.Text = "Nueva Contraseña:";
            // 
            // txtPasswordNuevo
            // 
            this.txtPasswordNuevo.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtPasswordNuevo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordNuevo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPasswordNuevo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtPasswordNuevo.Location = new System.Drawing.Point(25, 155);
            this.txtPasswordNuevo.Name = "txtPasswordNuevo";
            this.txtPasswordNuevo.Size = new System.Drawing.Size(300, 25);
            this.txtPasswordNuevo.TabIndex = 6;
            this.txtPasswordNuevo.UseSystemPasswordChar = true;
            // 
            // lblPasswordConfirmar
            // 
            this.lblPasswordConfirmar.AutoSize = true;
            this.lblPasswordConfirmar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordConfirmar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPasswordConfirmar.Location = new System.Drawing.Point(25, 195);
            this.lblPasswordConfirmar.Name = "lblPasswordConfirmar";
            this.lblPasswordConfirmar.Size = new System.Drawing.Size(127, 15);
            this.lblPasswordConfirmar.TabIndex = 7;
            this.lblPasswordConfirmar.Text = "Confirmar Contraseña:";
            // 
            // txtPasswordConfirmar
            // 
            this.txtPasswordConfirmar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtPasswordConfirmar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordConfirmar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPasswordConfirmar.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtPasswordConfirmar.Location = new System.Drawing.Point(25, 215);
            this.txtPasswordConfirmar.Name = "txtPasswordConfirmar";
            this.txtPasswordConfirmar.Size = new System.Drawing.Size(300, 25);
            this.txtPasswordConfirmar.TabIndex = 8;
            this.txtPasswordConfirmar.UseSystemPasswordChar = true;
            // 
            // panelSeparatorFooter
            // 
            this.panelSeparatorFooter.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.panelSeparatorFooter.Location = new System.Drawing.Point(0, 275);
            this.panelSeparatorFooter.Name = "panelSeparatorFooter";
            this.panelSeparatorFooter.Size = new System.Drawing.Size(350, 1);
            this.panelSeparatorFooter.TabIndex = 10;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(125, 287);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 32);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCancelar.Location = new System.Drawing.Point(235, 287);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // chkMostrarPassword
            // 
            this.chkMostrarPassword.AutoSize = true;
            this.chkMostrarPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkMostrarPassword.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.chkMostrarPassword.Location = new System.Drawing.Point(25, 248);
            this.chkMostrarPassword.Name = "chkMostrarPassword";
            this.chkMostrarPassword.Size = new System.Drawing.Size(137, 19);
            this.chkMostrarPassword.TabIndex = 9;
            this.chkMostrarPassword.Text = "Mostrar contraseñas";
            this.chkMostrarPassword.UseVisualStyleBackColor = true;
            // 
            // FrmCambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 335);
            this.Controls.Add(this.chkMostrarPassword);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panelSeparatorFooter);
            this.Controls.Add(this.txtPasswordConfirmar);
            this.Controls.Add(this.lblPasswordConfirmar);
            this.Controls.Add(this.txtPasswordNuevo);
            this.Controls.Add(this.lblPasswordNuevo);
            this.Controls.Add(this.txtPasswordActual);
            this.Controls.Add(this.lblPasswordActual);
            this.Controls.Add(this.panelSeparatorHeader);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCambiarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambiar Contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelSeparatorHeader;
        private System.Windows.Forms.Label lblPasswordActual;
        private System.Windows.Forms.TextBox txtPasswordActual;
        private System.Windows.Forms.Label lblPasswordNuevo;
        private System.Windows.Forms.TextBox txtPasswordNuevo;
        private System.Windows.Forms.Label lblPasswordConfirmar;
        private System.Windows.Forms.TextBox txtPasswordConfirmar;
        private System.Windows.Forms.Panel panelSeparatorFooter;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkMostrarPassword;
    }
}
