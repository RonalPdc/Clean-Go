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
            txtPasswordActual.UseSystemPasswordChar = !mostrar;
            txtPasswordNueva.UseSystemPasswordChar = !mostrar;
            txtPasswordConfirmar.UseSystemPasswordChar = !mostrar;
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
                // Obtener el usuario completo actualizado de la base de datos
                var usuarioDB = _usuariosBLL.ObtenerPorId(_usuarioLogueado.UsuarioId);
                if (usuarioDB == null)
                {
                    MessageBox.Show("No se encontró el usuario en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar contraseña actual
                if (usuarioDB.PasswordHash != txtPasswordActual.Text)
                {
                    MessageBox.Show("La contraseña actual ingresada es incorrecta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPasswordActual.Focus();
                    return;
                }

                // Asignar nueva contraseña
                usuarioDB.PasswordHash = txtPasswordNueva.Text;

                // Actualizar en base de datos
                bool exito = _usuariosBLL.Actualizar(usuarioDB);

                if (exito)
                {
                    MessageBox.Show("Contraseña actualizada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Error al cambiar contraseña:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
