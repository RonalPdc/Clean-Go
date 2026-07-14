using System;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Servicios;
using Clean_Go_Entities.Servicios;

namespace Clean_Go.BusinessLogic.Servicios
{
    public partial class FrmServicioEditar : Form
    {
        private readonly ServiciosBLL _serviciosBLL = new ServiciosBLL();
        private readonly Servicio _servicioToEdit;

        public FrmServicioEditar()
        {
            InitializeComponent();
            _servicioToEdit = null;
            this.Load += FrmServicioEditar_Load;
            btnCancelar.Click += (s, e) => this.Close();
            btnGuardar.Click += BtnGuardar_Click;
            txtPrecio.KeyPress += TxtPrecio_KeyPress;
        }

        public FrmServicioEditar(Servicio servicio) : this()
        {
            _servicioToEdit = servicio;
        }

        private void FrmServicioEditar_Load(object sender, EventArgs e)
        {
            txtNombre.MaxLength = 50;
            txtDescripcion.MaxLength = 200;
            txtPrecio.MaxLength = 10;

            if (_servicioToEdit != null)
            {
                txtNombre.Text = _servicioToEdit.Nombre;
                txtDescripcion.Text = _servicioToEdit.Descripcion;
                txtPrecio.Text = _servicioToEdit.Precio.ToString("0.00");
                chkEstado.Checked = _servicioToEdit.Estado;
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

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio valido mayor o igual a cero.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return;
            }

            try
            {
                BloquearControles(false);

                Servicio servicio = _servicioToEdit ?? new Servicio();
                servicio.Nombre = txtNombre.Text.Trim();
                servicio.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
                servicio.Precio = precio;
                servicio.Estado = chkEstado.Checked;

                bool resultado;
                if (_servicioToEdit == null)
                {
                    resultado = _serviciosBLL.Crear(servicio);
                    if (resultado)
                    {
                        MessageBox.Show("Servicio creado con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    resultado = _serviciosBLL.Actualizar(servicio);
                    if (resultado)
                    {
                        MessageBox.Show("Servicio actualizado con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (resultado)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el servicio. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtDescripcion.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            chkEstado.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            this.Cursor = habilitar ? Cursors.Default : Cursors.WaitCursor;
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != decimalSeparator)
            {
                e.Handled = true;
            }

            if (e.KeyChar == decimalSeparator && ((TextBox)sender).Text.Contains(decimalSeparator.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}
