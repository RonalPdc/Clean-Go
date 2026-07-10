using System;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Clientes;
using Clean_Go_Entities.Clientes;

namespace Clean_Go.BusinessLogic.Clientes
{
    public partial class FrmClienteEditar : Form
    {
        private readonly ClientesBLL _clientesBLL = new ClientesBLL();
        private readonly Cliente _clienteToEdit;

        public FrmClienteEditar()
        {
            InitializeComponent();
            _clienteToEdit = null;
            btnCancelar.Click += (s, e) => this.Close();
            btnGuardar.Click += BtnGuardar_Click;
        }

        public FrmClienteEditar(Cliente cliente) : this()
        {
            _clienteToEdit = cliente;
        }

        private void FrmClienteEditar_Load(object sender, EventArgs e)
        {
            if (_clienteToEdit != null)
            {
                txtNombre.Text = _clienteToEdit.Nombre;
                txtApellido.Text = _clienteToEdit.Apellido;
                txtCedula.Text = _clienteToEdit.Cedula;
                txtTelefono.Text = _clienteToEdit.Telefono;
                txtCorreo.Text = _clienteToEdit.Correo;
                txtDireccion.Text = _clienteToEdit.Direccion;
                txtTelegramChatId.Text = _clienteToEdit.TelegramChatId;
                chkEstado.Checked = _clienteToEdit.Estado;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El Nombre es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El Apellido es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("La Cedula es obligatoria.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El Telefono es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            try
            {
                BloquearControles(false);

                Cliente cliente = _clienteToEdit ?? new Cliente();
                cliente.Nombre = txtNombre.Text.Trim();
                cliente.Apellido = txtApellido.Text.Trim();
                cliente.Cedula = txtCedula.Text.Trim();
                cliente.Telefono = txtTelefono.Text.Trim();
                cliente.Correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim();
                cliente.Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim();
                cliente.TelegramChatId = string.IsNullOrWhiteSpace(txtTelegramChatId.Text) ? null : txtTelegramChatId.Text.Trim();
                cliente.Estado = chkEstado.Checked;

                bool resultado;
                if (_clienteToEdit == null)
                {
                    resultado = _clientesBLL.Crear(cliente);
                    if (resultado)
                    {
                        MessageBox.Show("Cliente creado con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    resultado = _clientesBLL.Actualizar(cliente);
                    if (resultado)
                    {
                        MessageBox.Show("Cliente actualizado con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (resultado)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cliente. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BloquearControles(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BloquearControles(true);
            }
        }

        private void BloquearControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtCedula.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            txtTelegramChatId.Enabled = habilitar;
            chkEstado.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            this.Cursor = habilitar ? Cursors.Default : Cursors.WaitCursor;
        }
    }
}
