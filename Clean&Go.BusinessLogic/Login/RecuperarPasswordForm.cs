using System;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Usuarios;

namespace Clean_Go.BusinessLogic
{
    public partial class RecuperarPasswordForm : Form
    {
        private readonly UsuariosBLL usuarioBLL = new UsuariosBLL();

        public RecuperarPasswordForm()
        {
            InitializeComponent();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string email = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, ingrese el correo electrónico.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            try
            {
                string password = usuarioBLL.RecuperarPassword(username, email);
                
                MessageBox.Show($"Su contraseña es: {password}", "Recuperación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
