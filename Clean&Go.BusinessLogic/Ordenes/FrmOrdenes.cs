using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Ordenes;
using Clean_Go_Entities.Ordenes;
using Clean_Go_Entities.Usuarios;
using Clean_Go.BusinessLogic;

namespace Clean_Go.BusinessLogic.Ordenes
{
    public partial class FrmOrdenes : Form
    {
        private readonly OrdenesBLL _ordenesBLL = new OrdenesBLL();
        private readonly Usuario _usuarioLogueado;

        public FrmOrdenes(Usuario usuarioLogueado)
        {
            InitializeComponent();
            _usuarioLogueado = usuarioLogueado;
            ConfigurarEventos();

            // Estilos Premium
            DisenoHelper.StyleButton(btnNuevo, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnCambiarEstado, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnBuscar, Color.FromArgb(71, 85, 105), Color.White);
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmOrdenes_Load;
            btnNuevo.Click += BtnNuevo_Click;
            btnCambiarEstado.Click += BtnCambiarEstado_Click;
            btnBuscar.Click += BtnBuscar_Click;
            txtBuscar.KeyDown += TxtBuscar_KeyDown;
            
            OrdenesBLL.AlCambiarOrdenes += CargarOrdenes;
            this.FormClosed += (s, e) => OrdenesBLL.AlCambiarOrdenes -= CargarOrdenes;
        }

        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvOrdenes);
            CargarOrdenes();
        }

        private void CargarOrdenes()
        {
            try
            {
                var ordenes = _ordenesBLL.ObtenerTodos();
                string filtro = txtBuscar.Text.Trim().ToLower();

                if (!string.IsNullOrEmpty(filtro))
                {
                    ordenes = ordenes.FindAll(o =>
                        (o.NumeroOrden != null && o.NumeroOrden.ToLower().Contains(filtro)) ||
                        o.ClienteId.ToString() == filtro ||
                        o.OrdenId.ToString() == filtro
                    );
                }

                // Cargar clientes en memoria para mapear a nombres
                var clientesBLL = new Clean_Go_BusinessLogic.Service.Clientes.ClientesBLL();
                var clientesList = clientesBLL.ObtenerTodos();
                var dictClientes = new Dictionary<int, string>();
                foreach (var c in clientesList)
                {
                    dictClientes[c.ClienteId] = $"{c.Nombre} {c.Apellido}";
                }

                // Cargar usuarios en memoria para mapear a nombres de usuario
                var usuariosBLL = new Clean_Go_BusinessLogic.Service.Usuarios.UsuariosBLL();
                var usuariosList = usuariosBLL.ObtenerTodos();
                var dictUsuarios = new Dictionary<int, string>();
                foreach (var u in usuariosList)
                {
                    dictUsuarios[u.UsuarioId] = u.NombreUsuario;
                }

                // Proyectar lista legible para el Grid
                var listaLegible = new List<object>();
                foreach (var o in ordenes)
                {
                    string clienteNombre = dictClientes.ContainsKey(o.ClienteId) ? dictClientes[o.ClienteId] : "Desconocido (" + o.ClienteId + ")";
                    string usuarioNombre = dictUsuarios.ContainsKey(o.UsuarioRegistroId) ? dictUsuarios[o.UsuarioRegistroId] : "Sistema (" + o.UsuarioRegistroId + ")";

                    string estadoStr = "Pendiente";
                    if (o.EstadoId == 2) estadoStr = "En Proceso";
                    else if (o.EstadoId == 3) estadoStr = "Lista para Entrega";
                    else if (o.EstadoId == 4) estadoStr = "Entregada";
                    else if (o.EstadoId == 5) estadoStr = "Cancelada";

                    listaLegible.Add(new
                    {
                        ID = o.OrdenId,
                        NumeroOrden = o.NumeroOrden,
                        Cliente = clienteNombre,
                        FechaRecepcion = o.FechaRecepcion.ToString("dd/MM/yyyy hh:mm tt"),
                        FechaEntregaEstimada = o.FechaEntregaEstimada.ToString("dd/MM/yyyy"),
                        Observaciones = o.Observaciones,
                        Total = "$" + o.Total.ToString("0.00"),
                        Estado = estadoStr,
                        RegistradoPor = usuarioNombre
                    });
                }

                dgvOrdenes.DataSource = null;
                dgvOrdenes.DataSource = listaLegible;

                if (dgvOrdenes.Columns.Contains("ID")) dgvOrdenes.Columns["ID"].HeaderText = "ID";
                if (dgvOrdenes.Columns.Contains("NumeroOrden")) dgvOrdenes.Columns["NumeroOrden"].HeaderText = "Número Orden";
                if (dgvOrdenes.Columns.Contains("Cliente")) dgvOrdenes.Columns["Cliente"].HeaderText = "Cliente";
                if (dgvOrdenes.Columns.Contains("FechaRecepcion")) dgvOrdenes.Columns["FechaRecepcion"].HeaderText = "Fecha Recepción";
                if (dgvOrdenes.Columns.Contains("FechaEntregaEstimada")) dgvOrdenes.Columns["FechaEntregaEstimada"].HeaderText = "Entrega Estimada";
                if (dgvOrdenes.Columns.Contains("Total")) dgvOrdenes.Columns["Total"].HeaderText = "Total";
                if (dgvOrdenes.Columns.Contains("Estado")) dgvOrdenes.Columns["Estado"].HeaderText = "Estado";
                if (dgvOrdenes.Columns.Contains("Observaciones")) dgvOrdenes.Columns["Observaciones"].HeaderText = "Observaciones";
                if (dgvOrdenes.Columns.Contains("RegistradoPor")) dgvOrdenes.Columns["RegistradoPor"].HeaderText = "Registrado Por";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ordenes:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarOrdenes();
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarOrdenes();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmOrdenesNuevo frm = new FrmOrdenesNuevo(_usuarioLogueado))
            {
                frm.ShowDialog();
            }
        }

        private void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una orden para cambiar de estado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int ordenId = 0;
            if (dgvOrdenes.CurrentRow.Cells["ID"].Value != null)
            {
                ordenId = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells["ID"].Value);
            }

            if (ordenId > 0)
            {
                Orden ordenSeleccionada = _ordenesBLL.ObtenerPorId(ordenId);
                if (ordenSeleccionada != null)
                {
                    using (FrmOrdenesCambiarEstado frm = new FrmOrdenesCambiarEstado(ordenSeleccionada, _usuarioLogueado))
                    {
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo cargar el detalle de la orden seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
