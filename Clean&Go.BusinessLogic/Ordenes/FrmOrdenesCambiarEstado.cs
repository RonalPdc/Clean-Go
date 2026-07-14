using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Ordenes;
using Clean_Go_BusinessLogic.Validator.Ordenes.Estado;
using Clean_Go_Entities.Ordenes;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go.BusinessLogic.Ordenes
{
    public partial class FrmOrdenesCambiarEstado : Form
    {
        private readonly OrdenesBLL _ordenesBLL = new OrdenesBLL();
        private readonly Orden _orden;
        private readonly Usuario _usuarioLogueado;

        public FrmOrdenesCambiarEstado(Orden orden, Usuario usuarioLogueado)
        {
            InitializeComponent();
            _orden = orden;
            _usuarioLogueado = usuarioLogueado;
            this.Load += FrmOrdenesCambiarEstado_Load;
            btnCancelar.Click += (s, e) => this.Close();
            btnGuardar.Click += BtnGuardar_Click;
        }

        private void FrmOrdenesCambiarEstado_Load(object sender, EventArgs e)
        {
            IEstadoOrden estadoActual = EstadoOrdenHelper.ObtenerEstado(_orden.EstadoId);
            txtEstadoActual.Text = estadoActual.Nombre;

            CargarTransicionesPermitidas(estadoActual);
        }

        private void CargarTransicionesPermitidas(IEstadoOrden estadoActual)
        {
            List<NextStateItem> transiciones = new List<NextStateItem>();
            int[] todosEstados = { 1, 2, 3, 4, 5 };

            foreach (int id in todosEstados)
            {
                if (estadoActual.PuedeCambiarA(id))
                {
                    IEstadoOrden next = EstadoOrdenHelper.ObtenerEstado(id);
                    transiciones.Add(new NextStateItem { EstadoId = next.EstadoId, Nombre = next.Nombre });
                }
            }

            if (transiciones.Count == 0)
            {
                MessageBox.Show("Esta orden se encuentra en un estado final (" + estadoActual.Nombre + ") y no admite cambios.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = false;
                cmbNuevoEstado.Enabled = false;
                txtComentario.Enabled = false;
            }
            else
            {
                cmbNuevoEstado.DisplayMember = "Nombre";
                cmbNuevoEstado.ValueMember = "EstadoId";
                cmbNuevoEstado.DataSource = transiciones;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbNuevoEstado.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el nuevo estado.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtComentario.Text))
            {
                MessageBox.Show("El comentario de auditoria es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComentario.Focus();
                return;
            }

            try
            {
                int nuevoEstadoId = (int)cmbNuevoEstado.SelectedValue;
                string comentario = txtComentario.Text.Trim();

                bool resultado = _ordenesBLL.CambiarEstado(_orden.OrdenId, nuevoEstadoId, _usuarioLogueado.UsuarioId, comentario);

                if (resultado)
                {
                    MessageBox.Show("Estado actualizado con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el estado de la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar estado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class NextStateItem
    {
        public int EstadoId { get; set; }
        public string Nombre { get; set; }
    }
}
