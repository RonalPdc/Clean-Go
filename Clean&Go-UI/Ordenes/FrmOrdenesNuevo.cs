using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Clientes;
using Clean_Go_BusinessLogic.Service.Prendas;
using Clean_Go_BusinessLogic.Service.Servicios;
using Clean_Go_BusinessLogic.Service.Ordenes;
using Clean_Go_Entities.Clientes;
using Clean_Go_Entities.Prendas;
using Clean_Go_Entities.Servicios;
using Clean_Go_Entities.Ordenes;
using Clean_Go_Entities.Usuarios;

namespace Clean_Go.BusinessLogic.Ordenes
{
    public partial class FrmOrdenesNuevo : Form
    {
        private readonly ClientesBLL _clientesBLL = new ClientesBLL();
        private readonly TiposPrendaBLL _prendaBLL = new TiposPrendaBLL();
        private readonly ServiciosBLL _serviciosBLL = new ServiciosBLL();
        private readonly OrdenesBLL _ordenesBLL = new OrdenesBLL();
        private readonly Usuario _usuarioLogueado;

        private readonly List<DetalleOrden> _detalles = new List<DetalleOrden>();
        private decimal _totalAcumulado = 0;

        public FrmOrdenesNuevo(Usuario usuarioLogueado)
        {
            try
            {
                InitializeComponent();
                _usuarioLogueado = usuarioLogueado;
                this.Load += FrmOrdenesNuevo_Load;
                ConfigurarEventos();
            }
            catch (Exception ex)
            {
                RegistrarError(ex, "Constructor");
                throw;
            }
        }

        private void ConfigurarEventos()
        {
            btnCancelar.Click += (s, e) => this.Close();
            btnAgregarDetalle.Click += BtnAgregarDetalle_Click;
            btnQuitarDetalle.Click += BtnQuitarDetalle_Click;
            btnGuardar.Click += BtnGuardar_Click;
            cmbServicio.SelectedIndexChanged += CmbServicio_SelectedIndexChanged;
            txtCantidad.KeyPress += TxtCantidad_KeyPress;
        }

        private void FrmOrdenesNuevo_Load(object sender, EventArgs e)
        {
            try
            {
                txtObservacionesCabecera.MaxLength = 200;
                txtObservacionesDetalle.MaxLength = 100;
                txtCantidad.MaxLength = 3;

                CargarCombos();
                txtNumeroOrden.Text = "ORD-" + DateTime.Now.ToString("yyMMddHHmmss");
                ActualizarGrid();
            }
            catch (Exception ex)
            {
                RegistrarError(ex, "Load");
                throw;
            }
        }

        private void CargarCombos()
        {
            try
            {
                var clientes = _clientesBLL.ObtenerTodos();
                var clientesActivos = clientes.FindAll(c => c.Estado);
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "ClienteId";
                cmbCliente.DataSource = clientesActivos;

                var prendas = _prendaBLL.ObtenerTodos();
                var prendasActivas = prendas.FindAll(p => p.Estado);
                cmbPrenda.DisplayMember = "Nombre";
                cmbPrenda.ValueMember = "TipoPrendaId";
                cmbPrenda.DataSource = prendasActivas;

                var servicios = _serviciosBLL.ObtenerTodos();
                var serviciosActivos = servicios.FindAll(s => s.Estado);
                cmbServicio.DisplayMember = "Nombre";
                cmbServicio.ValueMember = "ServicioId";
                cmbServicio.DataSource = serviciosActivos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar catalogos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicio.SelectedItem is Servicio servicio)
            {
                txtPrecio.Text = servicio.Precio.ToString("0.00");
            }
        }

        private void BtnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (cmbPrenda.SelectedValue == null || cmbServicio.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una prenda y servicio validos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad valida mayor a cero.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            try
            {
                int tipoPrendaId = (int)cmbPrenda.SelectedValue;
                int servicioId = (int)cmbServicio.SelectedValue;
                decimal precio = decimal.Parse(txtPrecio.Text);
                string obs = string.IsNullOrWhiteSpace(txtObservacionesDetalle.Text) ? null : txtObservacionesDetalle.Text.Trim();

                                DetalleOrden itemExistente = _detalles.Find(d => d.TipoPrendaId == tipoPrendaId && d.ServicioId == servicioId);

                if (itemExistente != null)
                {
                    itemExistente.Cantidad += cantidad;
                    itemExistente.Precio = precio; 
                    if (!string.IsNullOrEmpty(obs))
                    {
                        if (string.IsNullOrEmpty(itemExistente.Observaciones))
                            itemExistente.Observaciones = obs;
                        else if (!itemExistente.Observaciones.Contains(obs))
                            itemExistente.Observaciones += "; " + obs;
                    }
                }
                else
                {
                    DetalleOrden item = new DetalleOrden
                    {
                        TipoPrendaId = tipoPrendaId,
                        ServicioId = servicioId,
                        Cantidad = cantidad,
                        Precio = precio,
                        Observaciones = obs
                    };
                    _detalles.Add(item);
                }

                ActualizarGrid();

                txtCantidad.Text = "1";
                txtObservacionesDetalle.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar detalle:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuitarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para quitar del detalle.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = dgvDetalles.CurrentRow.Index;
            _detalles.RemoveAt(index);
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            if (_detalles.Count == 0)
            {
                dgvDetalles.DataSource = null;
                _totalAcumulado = 0;
                lblTotal.Text = "$0.00";
                return;
            }

                        var dictPrendas = new Dictionary<int, string>();
            if (cmbPrenda.DataSource is List<Clean_Go_Entities.Prendas.TipoPrenda> prendas)
            {
                foreach (var p in prendas)
                {
                    dictPrendas[p.TipoPrendaId] = p.Nombre;
                }
            }

            var dictServicios = new Dictionary<int, string>();
            if (cmbServicio.DataSource is List<Clean_Go_Entities.Servicios.Servicio> servicios)
            {
                foreach (var s in servicios)
                {
                    dictServicios[s.ServicioId] = s.Nombre;
                }
            }

            System.Data.DataTable tabla = new System.Data.DataTable();
            tabla.Columns.Add("Prenda");
            tabla.Columns.Add("Servicio");
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("PrecioUnitario");
            tabla.Columns.Add("Observaciones");

            foreach (var item in _detalles)
            {
                string prendaNombre = dictPrendas.ContainsKey(item.TipoPrendaId) ? dictPrendas[item.TipoPrendaId] : "Desconocido (" + item.TipoPrendaId + ")";
                string servicioNombre = dictServicios.ContainsKey(item.ServicioId) ? dictServicios[item.ServicioId] : "Desconocido (" + item.ServicioId + ")";

                tabla.Rows.Add(
                    prendaNombre,
                    servicioNombre,
                    item.Cantidad,
                    "$" + item.Precio.ToString("0.00"),
                    item.Observaciones
                );
            }

            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = tabla;

            if (dgvDetalles.Columns.Contains("Prenda")) dgvDetalles.Columns["Prenda"].HeaderText = "Prenda";
            if (dgvDetalles.Columns.Contains("Servicio")) dgvDetalles.Columns["Servicio"].HeaderText = "Servicio";
            if (dgvDetalles.Columns.Contains("Cantidad")) dgvDetalles.Columns["Cantidad"].HeaderText = "Cantidad";
            if (dgvDetalles.Columns.Contains("PrecioUnitario")) dgvDetalles.Columns["PrecioUnitario"].HeaderText = "Precio Unit.";
            if (dgvDetalles.Columns.Contains("Observaciones")) dgvDetalles.Columns["Observaciones"].HeaderText = "Observaciones";

            _totalAcumulado = 0;
            foreach (var item in _detalles)
            {
                _totalAcumulado += (item.Precio * item.Cantidad);
            }

            lblTotal.Text = "$" + _totalAcumulado.ToString("0.00");
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroOrden.Text))
            {
                MessageBox.Show("El numero de orden es obligatorio.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroOrden.Focus();
                return;
            }

            if (_detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos una prenda al detalle.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BloquearControles(false);

                Orden orden = new Orden
                {
                    NumeroOrden = txtNumeroOrden.Text.Trim(),
                    ClienteId = (int)cmbCliente.SelectedValue,
                    FechaEntregaEstimada = dtpFechaEntrega.Value,
                    Observaciones = string.IsNullOrWhiteSpace(txtObservacionesCabecera.Text) ? null : txtObservacionesCabecera.Text.Trim(),
                    UsuarioRegistroId = _usuarioLogueado.UsuarioId,
                    Total = _totalAcumulado
                };

                bool creado = _ordenesBLL.CrearOrden(orden, _detalles);

                if (creado)
                {
                    MessageBox.Show("Orden registrada con exito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BloquearControles(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar orden:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BloquearControles(true);
            }
        }

        private void BloquearControles(bool habilitar)
        {
            cmbCliente.Enabled = habilitar;
            txtNumeroOrden.Enabled = habilitar;
            dtpFechaEntrega.Enabled = habilitar;
            txtObservacionesCabecera.Enabled = habilitar;
            grpDetalle.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            this.Cursor = habilitar ? Cursors.Default : Cursors.WaitCursor;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarError(Exception ex, string origen)
        {
            try
            {
                string rutaLog = @"C:\Users\Ronal\source\repos\Clean&Go\error_nueva_orden.txt";
                string contenido = $"=== ERROR EN {origen.ToUpper()} ===\r\n" +
                                   $"Fecha: {DateTime.Now}\r\n" +
                                   $"Mensaje: {ex.Message}\r\n" +
                                   $"StackTrace:\r\n{ex.StackTrace}\r\n" +
                                   $"InnerException: {ex.InnerException?.Message}\r\n\r\n";
                System.IO.File.AppendAllText(rutaLog, contenido);
                
                MessageBox.Show($"Ocurrió un error en {origen}:\n{ex.Message}\n\nDetalle:\n{ex.StackTrace}", 
                                "Error de Diagnóstico", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
            catch 
            {
                MessageBox.Show($"Error crítico:\n{ex.Message}", "Error de Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
