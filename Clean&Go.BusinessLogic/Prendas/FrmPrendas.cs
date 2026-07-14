using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Prendas;
using Clean_Go_Entities.Prendas;
using Clean_Go.BusinessLogic;

namespace Clean_Go.BusinessLogic.Prendas
{
    public partial class FrmPrendas : Form
    {
        private readonly TiposPrendaBLL _prendaBLL = new TiposPrendaBLL();

        public FrmPrendas()
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
            this.Load += FrmPrendas_Load;
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnBuscar.Click += BtnBuscar_Click;
            txtBuscar.KeyDown += TxtBuscar_KeyDown;
        }

        private void FrmPrendas_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvPrendas);
            CargarPrendas();
        }

        private void CargarPrendas()
        {
            try
            {
                var prendas = _prendaBLL.ObtenerTodos();
                string filtro = txtBuscar.Text.Trim().ToLower();

                if (!string.IsNullOrEmpty(filtro))
                {
                    prendas = prendas.FindAll(p =>
                        (p.Nombre != null && p.Nombre.ToLower().Contains(filtro))
                    );
                }

                dgvPrendas.DataSource = prendas;

                if (dgvPrendas.Columns.Contains("TipoPrendaId")) dgvPrendas.Columns["TipoPrendaId"].HeaderText = "ID";
                if (dgvPrendas.Columns.Contains("Nombre")) dgvPrendas.Columns["Nombre"].HeaderText = "Nombre";
                if (dgvPrendas.Columns.Contains("Estado")) dgvPrendas.Columns["Estado"].HeaderText = "Activo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar prendas:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarPrendas();
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarPrendas();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmPrendaEditar frm = new FrmPrendaEditar())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarPrendas();
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPrendas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una prenda para editar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TipoPrenda prendaSeleccionada = (TipoPrenda)dgvPrendas.CurrentRow.DataBoundItem;
            using (FrmPrendaEditar frm = new FrmPrendaEditar(prendaSeleccionada))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarPrendas();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPrendas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una prenda para eliminar.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TipoPrenda prendaSeleccionada = (TipoPrenda)dgvPrendas.CurrentRow.DataBoundItem;
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de eliminar la prenda " + prendaSeleccionada.Nombre + "?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bool eliminado = _prendaBLL.Eliminar(prendaSeleccionada.TipoPrendaId);
                    if (eliminado)
                    {
                        MessageBox.Show("Prenda eliminada con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPrendas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la prenda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
