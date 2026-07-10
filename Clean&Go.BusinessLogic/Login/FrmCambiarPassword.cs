using System;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Usuarios;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go.BusinessLogic.Login
{
    public partial class FrmCambiarPassword : Form
    {
        private readonly UsuariosBLL _usuariosBLL = new UsuariosBLL();
        private readonly Usuario _usuarioLogueado;

        public FrmCambiarPassword(Usuario usuario)
        {
            InitializeComponent();
            _usuarioLogueado = usuario;
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            chkMostrarPassword.CheckedChanged += ChkMostrarPassword_CheckedChanged;
        }

        private void ChkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordActual.UseSystemPasswordChar = !chkMostrarPassword.Checked;
            txtPasswordNuevo.UseSystemPasswordChar = !chkMostrarPassword.Checked;
            txtPasswordConfirmar.UseSystemPasswordChar = !chkMostrarPassword.Checked;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string passwordActual = txtPasswordActual.Text;
            string passwordNuevo = txtPasswordNuevo.Text;
            string passwordConfirmar = txtPasswordConfirmar.Text;

            if (string.IsNullOrWhiteSpace(passwordActual))
            {
                MessageBox.Show("La contraseña actual es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordActual.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordNuevo))
            {
                MessageBox.Show("La nueva contraseña es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordNuevo.Focus();
                return;
            }

            if (passwordNuevo != passwordConfirmar)
            {
                MessageBox.Show("La nueva contraseña y la confirmación no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordConfirmar.Focus();
                return;
            }

            try
            {
                BloquearControles(false);
                bool resultado = _usuariosBLL.ActualizarPassword(_usuarioLogueado.UsuarioId, passwordActual, passwordNuevo);
                if (resultado)
                {
                    MessageBox.Show("Contraseña actualizada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BloquearControles(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BloquearControles(true);
            }
        }

        private void BloquearControles(bool habilitar)
        {
            txtPasswordActual.Enabled = habilitar;
            txtPasswordNuevo.Enabled = habilitar;
            txtPasswordConfirmar.Enabled = habilitar;
            chkMostrarPassword.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            this.Cursor = habilitar ? Cursors.Default : Cursors.WaitCursor;
        }
    }
}
