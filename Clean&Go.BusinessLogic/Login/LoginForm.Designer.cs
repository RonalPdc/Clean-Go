using System.Drawing;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelLeft;
        private Panel panelRight;
        private Label lblLogo;
        private Label lblSlogan;
        private Label lblLoginTitle;
        private Label lblLoginSubtitle;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkRemember;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private Label lblForgotPassword;
        private PictureBox pictureBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblSlogan = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.lblLoginSubtitle = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.panelLeft.Controls.Add(this.lblLogo);
            this.panelLeft.Controls.Add(this.lblSlogan);
            this.panelLeft.Controls.Add(this.pictureBox1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(380, 500);
            this.panelLeft.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(81, 268);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(205, 55);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "Clean&&Go";
            // 
            // lblSlogan
            // 
            this.lblSlogan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSlogan.ForeColor = System.Drawing.Color.FromArgb(200, 255, 255, 255);
            this.lblSlogan.Location = new System.Drawing.Point(89, 321);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(194, 25);
            this.lblSlogan.TabIndex = 1;
            this.lblSlogan.Text = "Tu lavandería de confianza";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.lblLoginTitle);
            this.panelRight.Controls.Add(this.lblLoginSubtitle);
            this.panelRight.Controls.Add(this.lblUsuario);
            this.panelRight.Controls.Add(this.txtUsuario);
            this.panelRight.Controls.Add(this.lblPassword);
            this.panelRight.Controls.Add(this.txtPassword);
            this.panelRight.Controls.Add(this.chkRemember);
            this.panelRight.Controls.Add(this.chkShowPassword);
            this.panelRight.Controls.Add(this.btnLogin);
            this.panelRight.Controls.Add(this.lblForgotPassword);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(380, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(420, 500);
            this.panelRight.TabIndex = 1;
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblLoginTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblLoginTitle.Location = new System.Drawing.Point(50, 60);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(227, 41);
            this.lblLoginTitle.TabIndex = 0;
            this.lblLoginTitle.Text = "Iniciar Sesión";
            // 
            // lblLoginSubtitle
            // 
            this.lblLoginSubtitle.AutoSize = true;
            this.lblLoginSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoginSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLoginSubtitle.Location = new System.Drawing.Point(54, 105);
            this.lblLoginSubtitle.Name = "lblLoginSubtitle";
            this.lblLoginSubtitle.Size = new System.Drawing.Size(242, 15);
            this.lblLoginSubtitle.TabIndex = 1;
            this.lblLoginSubtitle.Text = "Ingresa tus credenciales para continuar";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblUsuario.Location = new System.Drawing.Point(53, 155);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(60, 19);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtUsuario.Location = new System.Drawing.Point(55, 180);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(310, 27);
            this.txtUsuario.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblPassword.Location = new System.Drawing.Point(53, 225);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(85, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtPassword.Location = new System.Drawing.Point(55, 250);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(310, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.chkRemember.Location = new System.Drawing.Point(57, 295);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(90, 19);
            this.chkRemember.TabIndex = 2;
            this.chkRemember.Text = "Recordarme";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.chkShowPassword.Location = new System.Drawing.Point(235, 295);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(130, 19);
            this.chkShowPassword.TabIndex = 3;
            this.chkShowPassword.Text = "Mostrar contraseña";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(14, 116, 144);
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(6, 95, 115);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(55, 340);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(310, 45);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblForgotPassword.ForeColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.lblForgotPassword.Location = new System.Drawing.Point(55, 400);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(310, 20);
            this.lblForgotPassword.TabIndex = 8;
            this.lblForgotPassword.Text = "¿Olvidaste tu contraseña?";
            this.lblForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblForgotPassword.Click += new System.EventHandler(this.lblForgotPassword_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clean&&Go - Iniciar Sesión";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
