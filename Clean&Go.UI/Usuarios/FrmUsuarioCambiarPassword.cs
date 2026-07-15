using System;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Usuarios;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go.BusinessLogic.Usuarios
{
    public partial class FrmUsuarioCambiarPassword : Form
    {
        private readonly UsuariosBLL _usuariosBLL = new UsuariosBLL();
        private readonly Usuario _usuarioLogueado;

        public FrmUsuarioCambiarPassword(Usuario usuario)
        {
            InitializeComponent();
            _usuarioLogueado = usuario;
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = chkMostrar.Checked;
            if (mostrar)
            {
                txtPasswordActual.UseSystemPasswordChar = false;
                txtPasswordActual.PasswordChar = '\0';
                txtPasswordNueva.UseSystemPasswordChar = false;
                txtPasswordNueva.PasswordChar = '\0';
                txtPasswordConfirmar.UseSystemPasswordChar = false;
                txtPasswordConfirmar.PasswordChar = '\0';
            }
            else
            {
                txtPasswordActual.UseSystemPasswordChar = true;
                txtPasswordNueva.UseSystemPasswordChar = true;
                txtPasswordConfirmar.UseSystemPasswordChar = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtPasswordActual.Text))
            {
                MessageBox.Show("Debe ingresar su contraseña actual.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordActual.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPasswordNueva.Text))
            {
                MessageBox.Show("Debe ingresar la nueva contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordNueva.Focus();
                return;
            }

            if (txtPasswordNueva.Text.Length < 4)
            {
                MessageBox.Show("La nueva contraseña debe tener al menos 4 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordNueva.Focus();
                return;
            }

            if (txtPasswordNueva.Text != txtPasswordConfirmar.Text)
            {
                MessageBox.Show("La nueva contraseña y la confirmación no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordConfirmar.Focus();
                return;
            }

            try
            {
                // Actualizar la contraseña utilizando el método dedicado de la BLL
                bool exito = _usuariosBLL.ActualizarPassword(_usuarioLogueado.UsuarioId, txtPasswordActual.Text, txtPasswordNueva.Text);

                if (exito)
                {
                    MessageBox.Show("Contraseña actualizada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Sincronizar en memoria
                    _usuarioLogueado.PasswordHash = txtPasswordNueva.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la contraseña. Inténtelo nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
