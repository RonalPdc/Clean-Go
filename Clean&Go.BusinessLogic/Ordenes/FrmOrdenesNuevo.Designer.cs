using System.Drawing;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic.Ordenes
{
    partial class FrmOrdenesNuevo
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Label lblNumeroOrden;
        private TextBox txtNumeroOrden;
        private Label lblFechaEntrega;
        private DateTimePicker dtpFechaEntrega;
        private Label lblObservacionesCabecera;
        private TextBox txtObservacionesCabecera;
        private GroupBox grpDetalle;
        private Label lblPrenda;
        private ComboBox cmbPrenda;
        private Label lblServicio;
        private ComboBox cmbServicio;
        private Label lblCantidad;
        private TextBox txtCantidad;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblObservacionesDetalle;
        private TextBox txtObservacionesDetalle;
        private Button btnAgregarDetalle;
        private Button btnQuitarDetalle;
        private DataGridView dgvDetalles;
        private Label lblTotalLabel;
        private Label lblTotal;
        private Button btnGuardar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblNumeroOrden = new System.Windows.Forms.Label();
            this.txtNumeroOrden = new System.Windows.Forms.TextBox();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblObservacionesCabecera = new System.Windows.Forms.Label();
            this.txtObservacionesCabecera = new System.Windows.Forms.TextBox();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.btnQuitarDetalle = new System.Windows.Forms.Button();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.txtObservacionesDetalle = new System.Windows.Forms.TextBox();
            this.lblObservacionesDetalle = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.cmbPrenda = new System.Windows.Forms.ComboBox();
            this.lblPrenda = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(195, 21);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nueva Orden de Trabajo";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCliente.Location = new System.Drawing.Point(20, 53);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(50, 17);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(110, 50);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(200, 25);
            this.cmbCliente.TabIndex = 0;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // lblNumeroOrden
            // 
            this.lblNumeroOrden.AutoSize = true;
            this.lblNumeroOrden.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNumeroOrden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNumeroOrden.Location = new System.Drawing.Point(340, 53);
            this.lblNumeroOrden.Name = "lblNumeroOrden";
            this.lblNumeroOrden.Size = new System.Drawing.Size(100, 17);
            this.lblNumeroOrden.TabIndex = 3;
            this.lblNumeroOrden.Text = "Numero Orden:";
            // 
            // txtNumeroOrden
            // 
            this.txtNumeroOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtNumeroOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroOrden.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNumeroOrden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtNumeroOrden.Location = new System.Drawing.Point(450, 50);
            this.txtNumeroOrden.Name = "txtNumeroOrden";
            this.txtNumeroOrden.Size = new System.Drawing.Size(310, 24);
            this.txtNumeroOrden.TabIndex = 1;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFechaEntrega.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFechaEntrega.Location = new System.Drawing.Point(20, 88);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(80, 17);
            this.lblFechaEntrega.TabIndex = 5;
            this.lblFechaEntrega.Text = "Entrega Est.:";
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dtpFechaEntrega.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaEntrega.Location = new System.Drawing.Point(110, 85);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(200, 24);
            this.dtpFechaEntrega.TabIndex = 2;
            // 
            // lblObservacionesCabecera
            // 
            this.lblObservacionesCabecera.AutoSize = true;
            this.lblObservacionesCabecera.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblObservacionesCabecera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblObservacionesCabecera.Location = new System.Drawing.Point(340, 88);
            this.lblObservacionesCabecera.Name = "lblObservacionesCabecera";
            this.lblObservacionesCabecera.Size = new System.Drawing.Size(97, 17);
            this.lblObservacionesCabecera.TabIndex = 7;
            this.lblObservacionesCabecera.Text = "Observaciones:";
            // 
            // txtObservacionesCabecera
            // 
            this.txtObservacionesCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtObservacionesCabecera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacionesCabecera.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtObservacionesCabecera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtObservacionesCabecera.Location = new System.Drawing.Point(450, 85);
            this.txtObservacionesCabecera.Name = "txtObservacionesCabecera";
            this.txtObservacionesCabecera.Size = new System.Drawing.Size(310, 24);
            this.txtObservacionesCabecera.TabIndex = 3;
            // 
            // grpDetalle
            // 
            this.grpDetalle.BackColor = System.Drawing.Color.White;
            this.grpDetalle.Controls.Add(this.btnQuitarDetalle);
            this.grpDetalle.Controls.Add(this.btnAgregarDetalle);
            this.grpDetalle.Controls.Add(this.txtObservacionesDetalle);
            this.grpDetalle.Controls.Add(this.lblObservacionesDetalle);
            this.grpDetalle.Controls.Add(this.txtPrecio);
            this.grpDetalle.Controls.Add(this.lblPrecio);
            this.grpDetalle.Controls.Add(this.txtCantidad);
            this.grpDetalle.Controls.Add(this.lblCantidad);
            this.grpDetalle.Controls.Add(this.cmbServicio);
            this.grpDetalle.Controls.Add(this.lblServicio);
            this.grpDetalle.Controls.Add(this.cmbPrenda);
            this.grpDetalle.Controls.Add(this.lblPrenda);
            this.grpDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpDetalle.Location = new System.Drawing.Point(20, 125);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(740, 120);
            this.grpDetalle.TabIndex = 4;
            this.grpDetalle.TabStop = false;
            this.grpDetalle.Text = "Agregar Prendas y Servicios";
            // 
            // btnQuitarDetalle
            // 
            this.btnQuitarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnQuitarDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarDetalle.FlatAppearance.BorderSize = 0;
            this.btnQuitarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuitarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnQuitarDetalle.Location = new System.Drawing.Point(600, 60);
            this.btnQuitarDetalle.Name = "btnQuitarDetalle";
            this.btnQuitarDetalle.Size = new System.Drawing.Size(120, 27);
            this.btnQuitarDetalle.TabIndex = 5;
            this.btnQuitarDetalle.Text = "Quitar Item";
            this.btnQuitarDetalle.UseVisualStyleBackColor = false;
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.btnAgregarDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDetalle.FlatAppearance.BorderSize = 0;
            this.btnAgregarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDetalle.Location = new System.Drawing.Point(470, 60);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(115, 27);
            this.btnAgregarDetalle.TabIndex = 4;
            this.btnAgregarDetalle.Text = "Agregar Item";
            this.btnAgregarDetalle.UseVisualStyleBackColor = false;
            // 
            // txtObservacionesDetalle
            // 
            this.txtObservacionesDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtObservacionesDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacionesDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtObservacionesDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtObservacionesDetalle.Location = new System.Drawing.Point(120, 62);
            this.txtObservacionesDetalle.Name = "txtObservacionesDetalle";
            this.txtObservacionesDetalle.Size = new System.Drawing.Size(330, 24);
            this.txtObservacionesDetalle.TabIndex = 3;
            // 
            // lblObservacionesDetalle
            // 
            this.lblObservacionesDetalle.AutoSize = true;
            this.lblObservacionesDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblObservacionesDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblObservacionesDetalle.Location = new System.Drawing.Point(15, 65);
            this.lblObservacionesDetalle.Name = "lblObservacionesDetalle";
            this.lblObservacionesDetalle.Size = new System.Drawing.Size(97, 17);
            this.lblObservacionesDetalle.TabIndex = 8;
            this.lblObservacionesDetalle.Text = "Observaciones:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtPrecio.Location = new System.Drawing.Point(650, 22);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(70, 24);
            this.txtPrecio.TabIndex = 7;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPrecio.Location = new System.Drawing.Point(600, 25);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(47, 17);
            this.lblPrecio.TabIndex = 6;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtCantidad.Location = new System.Drawing.Point(540, 22);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(45, 24);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.Text = "1";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblCantidad.Location = new System.Drawing.Point(470, 25);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(63, 17);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // cmbServicio
            // 
            this.cmbServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbServicio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbServicio.FormattingEnabled = true;
            this.cmbServicio.Location = new System.Drawing.Point(300, 22);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(150, 25);
            this.cmbServicio.TabIndex = 1;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblServicio.Location = new System.Drawing.Point(240, 25);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(56, 17);
            this.lblServicio.TabIndex = 2;
            this.lblServicio.Text = "Servicio:";
            // 
            // cmbPrenda
            // 
            this.cmbPrenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.cmbPrenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrenda.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPrenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbPrenda.FormattingEnabled = true;
            this.cmbPrenda.Location = new System.Drawing.Point(70, 22);
            this.cmbPrenda.Name = "cmbPrenda";
            this.cmbPrenda.Size = new System.Drawing.Size(150, 25);
            this.cmbPrenda.TabIndex = 0;
            // 
            // lblPrenda
            // 
            this.lblPrenda.AutoSize = true;
            this.lblPrenda.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPrenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPrenda.Location = new System.Drawing.Point(15, 25);
            this.lblPrenda.Name = "lblPrenda";
            this.lblPrenda.Size = new System.Drawing.Size(52, 17);
            this.lblPrenda.TabIndex = 0;
            this.lblPrenda.Text = "Prenda:";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(20, 260);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(740, 200);
            this.dgvDetalles.TabIndex = 5;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTotalLabel.Location = new System.Drawing.Point(580, 480);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(48, 20);
            this.lblTotalLabel.TabIndex = 11;
            this.lblTotalLabel.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.lblTotal.Location = new System.Drawing.Point(645, 477);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(61, 25);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "$0.00";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(20, 520);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 35);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar Orden";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(165, 520);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 35);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FrmOrdenesNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 580);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.txtObservacionesCabecera);
            this.Controls.Add(this.lblObservacionesCabecera);
            this.Controls.Add(this.dtpFechaEntrega);
            this.Controls.Add(this.lblFechaEntrega);
            this.Controls.Add(this.txtNumeroOrden);
            this.Controls.Add(this.lblNumeroOrden);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOrdenesNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Orden";
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
