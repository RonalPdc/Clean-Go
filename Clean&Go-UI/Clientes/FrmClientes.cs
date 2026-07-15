using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Clientes;
using Clean_Go_Entities.Clientes;
using Clean_Go.BusinessLogic;

namespace Clean_Go.BusinessLogic.Clientes
{
    public partial class FrmClientes : Form
    {
        private readonly ClientesBLL _clientesBLL = new ClientesBLL();

        public FrmClientes()
        {
            InitializeComponent();
            ConfigurarEventos();

                        DisenoHelper.StyleButton(btnNuevo, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnEditar, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnEliminar, Color.FromArgb(239, 68, 68), Color.White);
            DisenoHelper.StyleButton(btnBuscar, Color.FromArgb(71, 85, 105), Color.White);
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmClientes_Load;
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnBuscar.Click += BtnBuscar_Click;
            txtBuscar.KeyDown += TxtBuscar_KeyDown;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvClientes);
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = _clientesBLL.ObtenerTodos();
                string filtro = txtBuscar.Text.Trim().ToLower();

                if (!string.IsNullOrEmpty(filtro))
                {
                    clientes = clientes.FindAll(c =>
                        (c.Nombre != null && c.Nombre.ToLower().Contains(filtro)) ||
                        (c.Apellido != null && c.Apellido.ToLower().Contains(filtro)) ||
                        (c.Cedula != null && c.Cedula.Contains(filtro)) ||
                        (c.Telefono != null && c.Telefono.Contains(filtro)) ||
                        (c.Correo != null && c.Correo.ToLower().Contains(filtro))
                    );
                }

                dgvClientes.DataSource = clientes;

                if (dgvClientes.Columns.Contains("ClienteId")) dgvClientes.Columns["ClienteId"].HeaderText = "ID";
                if (dgvClientes.Columns.Contains("Nombre")) dgvClientes.Columns["Nombre"].HeaderText = "Nombre";
                if (dgvClientes.Columns.Contains("Apellido")) dgvClientes.Columns["Apellido"].HeaderText = "Apellido";
                if (dgvClientes.Columns.Contains("Cedula")) dgvClientes.Columns["Cedula"].HeaderText = "Cedula";
                if (dgvClientes.Columns.Contains("Telefono")) dgvClientes.Columns["Telefono"].HeaderText = "Telefono";
                if (dgvClientes.Columns.Contains("Correo")) dgvClientes.Columns["Correo"].HeaderText = "Correo";
                if (dgvClientes.Columns.Contains("Direccion")) dgvClientes.Columns["Direccion"].HeaderText = "Direccion";
                if (dgvClientes.Columns.Contains("TelegramChatId")) dgvClientes.Columns["TelegramChatId"].HeaderText = "Telegram Chat ID";
                if (dgvClientes.Columns.Contains("FechaRegistro")) dgvClientes.Columns["FechaRegistro"].HeaderText = "Fecha Registro";
                if (dgvClientes.Columns.Contains("Estado")) dgvClientes.Columns["Estado"].HeaderText = "Activo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarClientes();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmClienteEditar frm = new FrmClienteEditar())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarClientes();
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para editar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cliente clienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            using (FrmClienteEditar frm = new FrmClienteEditar(clienteSeleccionado))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarClientes();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Cliente clienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de eliminar al cliente " + clienteSeleccionado.Nombre + " " + clienteSeleccionado.Apellido + "?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bool eliminado = _clientesBLL.Eliminar(clienteSeleccionado.ClienteId);
                    if (eliminado)
                    {
                        MessageBox.Show("Cliente eliminado con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
