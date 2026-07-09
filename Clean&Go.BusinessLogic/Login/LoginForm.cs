using System;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Usuarios;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go.BusinessLogic
{
    public partial class LoginForm : Form
    {
        private readonly UsuariosBLL usuarioBLL = new UsuariosBLL();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Ingrese el usuario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Ingrese la contraseña.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                Usuario usuario = usuarioBLL.Login(txtUsuario.Text.Trim(), txtPassword.Text.Trim());

                if (usuario != null)
                {
                    // Guardar configuración de Recordarme
                    if (chkRemember.Checked)
                    {
                        Properties.Settings.Default.Usuario = txtUsuario.Text.Trim();
                        Properties.Settings.Default.Recordarme = true;
                    }
                    else
                    {
                        Properties.Settings.Default.Usuario = "";
                        Properties.Settings.Default.Recordarme = false;
                    }
                    Properties.Settings.Default.Save();

                    MessageBox.Show($"Bienvenido {usuario.Nombre} {usuario.Apellido}", "Clean&Go", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    FormPrincial principal = new FormPrincial();
                    principal.FormClosed += (s, args) => this.Close();
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Cargar configuración de Recordarme
            if (Properties.Settings.Default.Recordarme)
            {
                txtUsuario.Text = Properties.Settings.Default.Usuario;
                chkRemember.Checked = true;
                txtPassword.Focus();
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            using (RecuperarPasswordForm recoverForm = new RecuperarPasswordForm())
            {
                recoverForm.ShowDialog();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
