using System;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic.Ordenes
{
    public partial class FrmDatosTarjeta : Form
    {
        public string NumeroTarjeta { get; private set; }
        public string Expiracion { get; private set; }
        public string Cvv { get; private set; }

        public FrmDatosTarjeta()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnConfirmar.Click += BtnConfirmar_Click;
            txtNumeroTarjeta.KeyPress += SoloNumeros_KeyPress;
            txtCvv.KeyPress += SoloNumeros_KeyPress;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string tarjeta = txtNumeroTarjeta.Text.Trim();
            string exp = txtExpiracion.Text.Trim();
            string cvv = txtCvv.Text.Trim();

            if (tarjeta.Length != 16)
            {
                MessageBox.Show("El numero de tarjeta debe tener 16 digitos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroTarjeta.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(exp) || !exp.Contains("/") || exp.Length != 5)
            {
                MessageBox.Show("La fecha de expiracion debe tener el formato MM/AA (ej: 12/28).", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExpiracion.Focus();
                return;
            }

            if (cvv.Length != 3)
            {
                MessageBox.Show("El codigo CVV debe tener 3 digitos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCvv.Focus();
                return;
            }

            NumeroTarjeta = tarjeta;
            Expiracion = exp;
            Cvv = cvv;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
