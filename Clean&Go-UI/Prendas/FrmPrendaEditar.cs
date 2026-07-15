using System;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Prendas;
using Clean_Go_Entities.Prendas;

namespace Clean_Go.BusinessLogic.Prendas
{
    public partial class FrmPrendaEditar : Form
    {
        private readonly TiposPrendaBLL _prendaBLL = new TiposPrendaBLL();
        private readonly TipoPrenda _prendaToEdit;

        public FrmPrendaEditar()
        {
            InitializeComponent();
            _prendaToEdit = null;
            this.Load += FrmPrendaEditar_Load;
            btnCancelar.Click += (s, e) => this.Close();
            btnGuardar.Click += BtnGuardar_Click;
        }

        public FrmPrendaEditar(TipoPrenda prenda) : this()
        {
            _prendaToEdit = prenda;
        }

        private void FrmPrendaEditar_Load(object sender, EventArgs e)
        {
            txtNombre.MaxLength = 50;
            txtDescripcion.MaxLength = 100;

            if (_prendaToEdit != null)
            {
                txtNombre.Text = _prendaToEdit.Nombre;
                txtDescripcion.Text = _prendaToEdit.Descripcion;
                chkEstado.Checked = _prendaToEdit.Estado;
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

            try
            {
                BloquearControles(false);

                TipoPrenda prenda = _prendaToEdit ?? new TipoPrenda();
                prenda.Nombre = txtNombre.Text.Trim();
                prenda.Descripcion = txtDescripcion.Text.Trim();
                prenda.Estado = chkEstado.Checked;

                bool resultado;
                if (_prendaToEdit == null)
                {
                    resultado = _prendaBLL.Crear(prenda);
                    if (resultado)
                    {
                        MessageBox.Show("Prenda creada con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    resultado = _prendaBLL.Actualizar(prenda);
                    if (resultado)
                    {
                        MessageBox.Show("Prenda actualizada con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (resultado)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la prenda. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            chkEstado.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            this.Cursor = habilitar ? Cursors.Default : Cursors.WaitCursor;
        }
    }
}
