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
            this.Load += FrmClienteEditar_Load;
            btnCancelar.Click += (s, e) => this.Close();
            btnGuardar.Click += BtnGuardar_Click;

                        txtTelefono.TextChanged += TxtTelefono_TextChanged;
            txtTelefono.KeyPress += SoloNumerosYFormato_KeyPress;
            txtCedula.TextChanged += TxtCedula_TextChanged;
            txtCedula.KeyPress += SoloNumerosYFormato_KeyPress;
            txtTelegramChatId.KeyPress += SoloNumeros_KeyPress;
        }

        public FrmClienteEditar(Cliente cliente) : this()
        {
            _clienteToEdit = cliente;
        }

        private void FrmClienteEditar_Load(object sender, EventArgs e)
        {
                        txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;
            txtCedula.MaxLength = 13;                   txtTelefono.MaxLength = 14;                 txtCorreo.MaxLength = 100;
            txtTelegramChatId.MaxLength = 20;
            txtDireccion.MaxLength = 250;

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
            
            string cedulaLimpia = ObtenerSoloNumeros(txtCedula.Text);
            if (cedulaLimpia.Length != 11)
            {
                MessageBox.Show("La Cedula debe contener exactamente 11 digitos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }

            string telefonoLimpio = ObtenerSoloNumeros(txtTelefono.Text);
            if (telefonoLimpio.Length != 10)
            {
                MessageBox.Show("El Telefono debe contener exactamente 10 digitos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                string email = txtCorreo.Text.Trim();
                if (!email.Contains("@") || !email.Contains("."))
                {
                    MessageBox.Show("Ingrese una direccion de correo electronico valida (ejemplo@dominio.com).", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return;
                }
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

        private void TxtTelefono_TextChanged(object sender, EventArgs e)
        {
            txtTelefono.TextChanged -= TxtTelefono_TextChanged;
            string soloNumeros = ObtenerSoloNumeros(txtTelefono.Text);
            if (soloNumeros.Length > 10) soloNumeros = soloNumeros.Substring(0, 10);

            if (soloNumeros.Length == 10)
            {
                txtTelefono.Text = $"({soloNumeros.Substring(0, 3)}) {soloNumeros.Substring(3, 3)}-{soloNumeros.Substring(6, 4)}";
            }
            else
            {
                txtTelefono.Text = soloNumeros;
            }
            txtTelefono.SelectionStart = txtTelefono.Text.Length;
            txtTelefono.TextChanged += TxtTelefono_TextChanged;
        }

        private void TxtCedula_TextChanged(object sender, EventArgs e)
        {
            txtCedula.TextChanged -= TxtCedula_TextChanged;
            string soloNumeros = ObtenerSoloNumeros(txtCedula.Text);
            if (soloNumeros.Length > 11) soloNumeros = soloNumeros.Substring(0, 11);

            if (soloNumeros.Length == 11)
            {
                txtCedula.Text = $"{soloNumeros.Substring(0, 3)}-{soloNumeros.Substring(3, 7)}-{soloNumeros.Substring(10, 1)}";
            }
            else
            {
                txtCedula.Text = soloNumeros;
            }
            txtCedula.SelectionStart = txtCedula.Text.Length;
            txtCedula.TextChanged += TxtCedula_TextChanged;
        }

        private string ObtenerSoloNumeros(string texto)
        {
            string resultado = "";
            foreach (char c in texto)
            {
                if (char.IsDigit(c))
                {
                    resultado += c;
                }
            }
            return resultado;
        }

        private void SoloNumerosYFormato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
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
