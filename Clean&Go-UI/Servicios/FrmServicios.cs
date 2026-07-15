using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Servicios;
using Clean_Go_Entities.Servicios;
using Clean_Go.BusinessLogic;

namespace Clean_Go.BusinessLogic.Servicios
{
    public partial class FrmServicios : Form
    {
        private readonly ServiciosBLL _serviciosBLL = new ServiciosBLL();

        public FrmServicios()
        {
            InitializeComponent();
            ConfigurarEventos();

            // Estilos Premium
            DisenoHelper.StyleButton(btnNuevo, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnEditar, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnEliminar, Color.FromArgb(239, 68, 68), Color.White);
            DisenoHelper.StyleButton(btnBuscar, Color.FromArgb(71, 85, 105), Color.White);
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmServicios_Load;
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnBuscar.Click += BtnBuscar_Click;
            txtBuscar.KeyDown += TxtBuscar_KeyDown;
        }

        private void FrmServicios_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvServicios);
            CargarServicios();
        }

        private void CargarServicios()
        {
            try
            {
                var servicios = _serviciosBLL.ObtenerTodos();
                string filtro = txtBuscar.Text.Trim().ToLower();

                if (!string.IsNullOrEmpty(filtro))
                {
                    servicios = servicios.FindAll(s =>
                        (s.Nombre != null && s.Nombre.ToLower().Contains(filtro)) ||
                        (s.Descripcion != null && s.Descripcion.ToLower().Contains(filtro))
                    );
                }

                dgvServicios.DataSource = servicios;

                if (dgvServicios.Columns.Contains("ServicioId")) dgvServicios.Columns["ServicioId"].HeaderText = "ID";
                if (dgvServicios.Columns.Contains("Nombre")) dgvServicios.Columns["Nombre"].HeaderText = "Nombre";
                if (dgvServicios.Columns.Contains("Descripcion")) dgvServicios.Columns["Descripcion"].HeaderText = "Descripcion";
                if (dgvServicios.Columns.Contains("Precio")) dgvServicios.Columns["Precio"].HeaderText = "Precio";
                if (dgvServicios.Columns.Contains("Estado")) dgvServicios.Columns["Estado"].HeaderText = "Activo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar servicios:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarServicios();
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarServicios();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmServicioEditar frm = new FrmServicioEditar())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarServicios();
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un servicio para editar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Servicio servicioSeleccionado = (Servicio)dgvServicios.CurrentRow.DataBoundItem;
            using (FrmServicioEditar frm = new FrmServicioEditar(servicioSeleccionado))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarServicios();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un servicio para eliminar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Servicio servicioSeleccionado = (Servicio)dgvServicios.CurrentRow.DataBoundItem;
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de eliminar el servicio " + servicioSeleccionado.Nombre + "?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bool eliminado = _serviciosBLL.Eliminar(servicioSeleccionado.ServicioId);
                    if (eliminado)
                    {
                        MessageBox.Show("Servicio eliminado con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarServicios();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
