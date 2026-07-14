using System.Drawing;
using System.Windows.Forms;

namespace Clean_Go.BusinessLogic
{
    partial class FormPrincial
    {
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.btnMenuDashboard = new System.Windows.Forms.Button();
            this.btnMenuClientes = new System.Windows.Forms.Button();
            this.btnMenuServicios = new System.Windows.Forms.Button();
            this.btnMenuPrendas = new System.Windows.Forms.Button();
            this.btnMenuOrdenes = new System.Windows.Forms.Button();
            this.btnMenuReportes = new System.Windows.Forms.Button();
            this.btnMenuUsuarios = new System.Windows.Forms.Button();
            this.btnMenuSalir = new System.Windows.Forms.Button();
            this.btnSalirApp = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblUserStatus = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.pnlKpiPendientes = new System.Windows.Forms.Panel();
            this.pnlKpiPendientesBorde = new System.Windows.Forms.Panel();
            this.lblKpiPendientesValor = new System.Windows.Forms.Label();
            this.lblKpiPendientesTitulo = new System.Windows.Forms.Label();
            this.pnlKpiProceso = new System.Windows.Forms.Panel();
            this.pnlKpiProcesoBorde = new System.Windows.Forms.Panel();
            this.lblKpiProcesoValor = new System.Windows.Forms.Label();
            this.lblKpiProcesoTitulo = new System.Windows.Forms.Label();
            this.pnlKpiListo = new System.Windows.Forms.Panel();
            this.pnlKpiListoBorde = new System.Windows.Forms.Panel();
            this.lblKpiListoValor = new System.Windows.Forms.Label();
            this.lblKpiListoTitulo = new System.Windows.Forms.Label();
            this.pnlKpiEntregado = new System.Windows.Forms.Panel();
            this.pnlKpiEntregadoBorde = new System.Windows.Forms.Panel();
            this.lblKpiEntregadoValor = new System.Windows.Forms.Label();
            this.lblKpiEntregadoTitulo = new System.Windows.Forms.Label();
            this.pnlTablaContenedor = new System.Windows.Forms.Panel();
            this.lblTablaTitulo = new System.Windows.Forms.Label();
            this.dgvEntregasHoy = new System.Windows.Forms.DataGridView();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.statusLblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlKpiPendientes.SuspendLayout();
            this.pnlKpiProceso.SuspendLayout();
            this.pnlKpiListo.SuspendLayout();
            this.pnlKpiEntregado.SuspendLayout();
            this.pnlTablaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregasHoy)).BeginInit();
            this.statusStripBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Controls.Add(this.btnMenuDashboard);
            this.pnlSidebar.Controls.Add(this.btnMenuClientes);
            this.pnlSidebar.Controls.Add(this.btnMenuServicios);
            this.pnlSidebar.Controls.Add(this.btnMenuPrendas);
            this.pnlSidebar.Controls.Add(this.btnMenuOrdenes);
            this.pnlSidebar.Controls.Add(this.btnMenuReportes);
            this.pnlSidebar.Controls.Add(this.btnMenuUsuarios);
            this.pnlSidebar.Controls.Add(this.btnMenuSalir);
            this.pnlSidebar.Controls.Add(this.btnSalirApp);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 731);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.lblSidebarTitle.Location = new System.Drawing.Point(15, 15);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(190, 40);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "🧺 Clean&Go";
            this.lblSidebarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMenuDashboard
            // 
            this.btnMenuDashboard.BackColor = System.Drawing.Color.White;
            this.btnMenuDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuDashboard.FlatAppearance.BorderSize = 0;
            this.btnMenuDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMenuDashboard.Location = new System.Drawing.Point(15, 70);
            this.btnMenuDashboard.Name = "btnMenuDashboard";
            this.btnMenuDashboard.Size = new System.Drawing.Size(190, 38);
            this.btnMenuDashboard.TabIndex = 0;
            this.btnMenuDashboard.Text = "📊 Panel de Control";
            this.btnMenuDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuDashboard.UseVisualStyleBackColor = false;
            // 
            // btnMenuClientes
            // 
            this.btnMenuClientes.BackColor = System.Drawing.Color.White;
            this.btnMenuClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuClientes.FlatAppearance.BorderSize = 0;
            this.btnMenuClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuClientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMenuClientes.Location = new System.Drawing.Point(15, 115);
            this.btnMenuClientes.Name = "btnMenuClientes";
            this.btnMenuClientes.Size = new System.Drawing.Size(190, 38);
            this.btnMenuClientes.TabIndex = 1;
            this.btnMenuClientes.Text = "👥 Clientes";
            this.btnMenuClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuClientes.UseVisualStyleBackColor = false;
            // 
            // btnMenuServicios
            // 
            this.btnMenuServicios.BackColor = System.Drawing.Color.White;
            this.btnMenuServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuServicios.FlatAppearance.BorderSize = 0;
            this.btnMenuServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuServicios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMenuServicios.Location = new System.Drawing.Point(15, 160);
            this.btnMenuServicios.Name = "btnMenuServicios";
            this.btnMenuServicios.Size = new System.Drawing.Size(190, 38);
            this.btnMenuServicios.TabIndex = 2;
            this.btnMenuServicios.Text = "💼 Servicios";
            this.btnMenuServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuServicios.UseVisualStyleBackColor = false;
            // 
            // btnMenuPrendas
            // 
            this.btnMenuPrendas.BackColor = System.Drawing.Color.White;
            this.btnMenuPrendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuPrendas.FlatAppearance.BorderSize = 0;
            this.btnMenuPrendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPrendas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuPrendas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMenuPrendas.Location = new System.Drawing.Point(15, 205);
            this.btnMenuPrendas.Name = "btnMenuPrendas";
            this.btnMenuPrendas.Size = new System.Drawing.Size(190, 38);
            this.btnMenuPrendas.TabIndex = 3;
            this.btnMenuPrendas.Text = "👕 Tipos de Prenda";
            this.btnMenuPrendas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPrendas.UseVisualStyleBackColor = false;
            // 
            // btnMenuOrdenes
            // 
            this.btnMenuOrdenes.BackColor = System.Drawing.Color.White;
            this.btnMenuOrdenes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuOrdenes.FlatAppearance.BorderSize = 0;
            this.btnMenuOrdenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuOrdenes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuOrdenes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMenuOrdenes.Location = new System.Drawing.Point(15, 250);
            this.btnMenuOrdenes.Name = "btnMenuOrdenes";
            this.btnMenuOrdenes.Size = new System.Drawing.Size(190, 38);
            this.btnMenuOrdenes.TabIndex = 4;
            this.btnMenuOrdenes.Text = "🧺 Órdenes";
            this.btnMenuOrdenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuOrdenes.UseVisualStyleBackColor = false;
            // 
            // btnMenuReportes
            // 
            this.btnMenuReportes.BackColor = System.Drawing.Color.White;
            this.btnMenuReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuReportes.FlatAppearance.BorderSize = 0;
            this.btnMenuReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuReportes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMenuReportes.Location = new System.Drawing.Point(15, 295);
            this.btnMenuReportes.Name = "btnMenuReportes";
            this.btnMenuReportes.Size = new System.Drawing.Size(190, 38);
            this.btnMenuReportes.TabIndex = 5;
            this.btnMenuReportes.Text = "📈 Reportes";
            this.btnMenuReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuReportes.UseVisualStyleBackColor = false;
            // 
            // btnMenuUsuarios
            // 
            this.btnMenuUsuarios.BackColor = System.Drawing.Color.White;
            this.btnMenuUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuUsuarios.FlatAppearance.BorderSize = 0;
            this.btnMenuUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMenuUsuarios.Location = new System.Drawing.Point(15, 340);
            this.btnMenuUsuarios.Name = "btnMenuUsuarios";
            this.btnMenuUsuarios.Size = new System.Drawing.Size(190, 38);
            this.btnMenuUsuarios.TabIndex = 6;
            this.btnMenuUsuarios.Text = "🔒 Usuarios / Seguridad";
            this.btnMenuUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnMenuSalir
            // 
            this.btnMenuSalir.BackColor = System.Drawing.Color.White;
            this.btnMenuSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMenuSalir.FlatAppearance.BorderSize = 0;
            this.btnMenuSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSalir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnMenuSalir.Location = new System.Drawing.Point(0, 655);
            this.btnMenuSalir.Name = "btnMenuSalir";
            this.btnMenuSalir.Size = new System.Drawing.Size(220, 38);
            this.btnMenuSalir.TabIndex = 7;
            this.btnMenuSalir.Text = "🚪 Cerrar Sesión";
            this.btnMenuSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuSalir.UseVisualStyleBackColor = false;
            // 
            // btnSalirApp
            // 
            this.btnSalirApp.BackColor = System.Drawing.Color.White;
            this.btnSalirApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalirApp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalirApp.FlatAppearance.BorderSize = 0;
            this.btnSalirApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalirApp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalirApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnSalirApp.Location = new System.Drawing.Point(0, 693);
            this.btnSalirApp.Name = "btnSalirApp";
            this.btnSalirApp.Size = new System.Drawing.Size(220, 38);
            this.btnSalirApp.TabIndex = 8;
            this.btnSalirApp.Text = "❌ Salir del Sistema";
            this.btnSalirApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirApp.UseVisualStyleBackColor = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblUserStatus);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(788, 55);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(161, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Panel de Control";
            // 
            // lblUserStatus
            // 
            this.lblUserStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblUserStatus.Location = new System.Drawing.Point(380, 15);
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new System.Drawing.Size(393, 25);
            this.lblUserStatus.TabIndex = 1;
            this.lblUserStatus.Text = "Usuario: Admin";
            this.lblUserStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlContent.Controls.Add(this.pnlDashboard);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 55);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(788, 654);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlDashboard.Controls.Add(this.pnlKpiPendientes);
            this.pnlDashboard.Controls.Add(this.pnlKpiProceso);
            this.pnlDashboard.Controls.Add(this.pnlKpiListo);
            this.pnlDashboard.Controls.Add(this.pnlKpiEntregado);
            this.pnlDashboard.Controls.Add(this.pnlTablaContenedor);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(788, 654);
            this.pnlDashboard.TabIndex = 0;
            // 
            // pnlKpiPendientes
            // 
            this.pnlKpiPendientes.BackColor = System.Drawing.Color.White;
            this.pnlKpiPendientes.Controls.Add(this.pnlKpiPendientesBorde);
            this.pnlKpiPendientes.Controls.Add(this.lblKpiPendientesValor);
            this.pnlKpiPendientes.Controls.Add(this.lblKpiPendientesTitulo);
            this.pnlKpiPendientes.Location = new System.Drawing.Point(20, 20);
            this.pnlKpiPendientes.Name = "pnlKpiPendientes";
            this.pnlKpiPendientes.Size = new System.Drawing.Size(170, 90);
            this.pnlKpiPendientes.TabIndex = 0;
            // 
            // pnlKpiPendientesBorde
            // 
            this.pnlKpiPendientesBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.pnlKpiPendientesBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiPendientesBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiPendientesBorde.Name = "pnlKpiPendientesBorde";
            this.pnlKpiPendientesBorde.Size = new System.Drawing.Size(170, 4);
            this.pnlKpiPendientesBorde.TabIndex = 0;
            // 
            // lblKpiPendientesValor
            // 
            this.lblKpiPendientesValor.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblKpiPendientesValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiPendientesValor.Location = new System.Drawing.Point(10, 40);
            this.lblKpiPendientesValor.Name = "lblKpiPendientesValor";
            this.lblKpiPendientesValor.Size = new System.Drawing.Size(150, 35);
            this.lblKpiPendientesValor.TabIndex = 1;
            this.lblKpiPendientesValor.Text = "0";
            // 
            // lblKpiPendientesTitulo
            // 
            this.lblKpiPendientesTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiPendientesTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiPendientesTitulo.Location = new System.Drawing.Point(10, 15);
            this.lblKpiPendientesTitulo.Name = "lblKpiPendientesTitulo";
            this.lblKpiPendientesTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblKpiPendientesTitulo.TabIndex = 2;
            this.lblKpiPendientesTitulo.Text = "LAVADOS PENDIENTES";
            // 
            // pnlKpiProceso
            // 
            this.pnlKpiProceso.BackColor = System.Drawing.Color.White;
            this.pnlKpiProceso.Controls.Add(this.pnlKpiProcesoBorde);
            this.pnlKpiProceso.Controls.Add(this.lblKpiProcesoValor);
            this.pnlKpiProceso.Controls.Add(this.lblKpiProcesoTitulo);
            this.pnlKpiProceso.Location = new System.Drawing.Point(210, 20);
            this.pnlKpiProceso.Name = "pnlKpiProceso";
            this.pnlKpiProceso.Size = new System.Drawing.Size(170, 90);
            this.pnlKpiProceso.TabIndex = 1;
            // 
            // pnlKpiProcesoBorde
            // 
            this.pnlKpiProcesoBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.pnlKpiProcesoBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiProcesoBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiProcesoBorde.Name = "pnlKpiProcesoBorde";
            this.pnlKpiProcesoBorde.Size = new System.Drawing.Size(170, 4);
            this.pnlKpiProcesoBorde.TabIndex = 0;
            // 
            // lblKpiProcesoValor
            // 
            this.lblKpiProcesoValor.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblKpiProcesoValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiProcesoValor.Location = new System.Drawing.Point(10, 40);
            this.lblKpiProcesoValor.Name = "lblKpiProcesoValor";
            this.lblKpiProcesoValor.Size = new System.Drawing.Size(150, 35);
            this.lblKpiProcesoValor.TabIndex = 1;
            this.lblKpiProcesoValor.Text = "0";
            // 
            // lblKpiProcesoTitulo
            // 
            this.lblKpiProcesoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiProcesoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiProcesoTitulo.Location = new System.Drawing.Point(10, 15);
            this.lblKpiProcesoTitulo.Name = "lblKpiProcesoTitulo";
            this.lblKpiProcesoTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblKpiProcesoTitulo.TabIndex = 2;
            this.lblKpiProcesoTitulo.Text = "LAVANDO (PROCESO)";
            // 
            // pnlKpiListo
            // 
            this.pnlKpiListo.BackColor = System.Drawing.Color.White;
            this.pnlKpiListo.Controls.Add(this.pnlKpiListoBorde);
            this.pnlKpiListo.Controls.Add(this.lblKpiListoValor);
            this.pnlKpiListo.Controls.Add(this.lblKpiListoTitulo);
            this.pnlKpiListo.Location = new System.Drawing.Point(400, 20);
            this.pnlKpiListo.Name = "pnlKpiListo";
            this.pnlKpiListo.Size = new System.Drawing.Size(170, 90);
            this.pnlKpiListo.TabIndex = 2;
            // 
            // pnlKpiListoBorde
            // 
            this.pnlKpiListoBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.pnlKpiListoBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiListoBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiListoBorde.Name = "pnlKpiListoBorde";
            this.pnlKpiListoBorde.Size = new System.Drawing.Size(170, 4);
            this.pnlKpiListoBorde.TabIndex = 0;
            // 
            // lblKpiListoValor
            // 
            this.lblKpiListoValor.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblKpiListoValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiListoValor.Location = new System.Drawing.Point(10, 40);
            this.lblKpiListoValor.Name = "lblKpiListoValor";
            this.lblKpiListoValor.Size = new System.Drawing.Size(150, 35);
            this.lblKpiListoValor.TabIndex = 1;
            this.lblKpiListoValor.Text = "0";
            // 
            // lblKpiListoTitulo
            // 
            this.lblKpiListoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiListoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiListoTitulo.Location = new System.Drawing.Point(10, 15);
            this.lblKpiListoTitulo.Name = "lblKpiListoTitulo";
            this.lblKpiListoTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblKpiListoTitulo.TabIndex = 2;
            this.lblKpiListoTitulo.Text = "LISTAS PARA ENTREGA";
            // 
            // pnlKpiEntregado
            // 
            this.pnlKpiEntregado.BackColor = System.Drawing.Color.White;
            this.pnlKpiEntregado.Controls.Add(this.pnlKpiEntregadoBorde);
            this.pnlKpiEntregado.Controls.Add(this.lblKpiEntregadoValor);
            this.pnlKpiEntregado.Controls.Add(this.lblKpiEntregadoTitulo);
            this.pnlKpiEntregado.Location = new System.Drawing.Point(590, 20);
            this.pnlKpiEntregado.Name = "pnlKpiEntregado";
            this.pnlKpiEntregado.Size = new System.Drawing.Size(170, 90);
            this.pnlKpiEntregado.TabIndex = 3;
            // 
            // pnlKpiEntregadoBorde
            // 
            this.pnlKpiEntregadoBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.pnlKpiEntregadoBorde.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpiEntregadoBorde.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiEntregadoBorde.Name = "pnlKpiEntregadoBorde";
            this.pnlKpiEntregadoBorde.Size = new System.Drawing.Size(170, 4);
            this.pnlKpiEntregadoBorde.TabIndex = 0;
            // 
            // lblKpiEntregadoValor
            // 
            this.lblKpiEntregadoValor.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblKpiEntregadoValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiEntregadoValor.Location = new System.Drawing.Point(10, 40);
            this.lblKpiEntregadoValor.Name = "lblKpiEntregadoValor";
            this.lblKpiEntregadoValor.Size = new System.Drawing.Size(150, 35);
            this.lblKpiEntregadoValor.TabIndex = 1;
            this.lblKpiEntregadoValor.Text = "0";
            // 
            // lblKpiEntregadoTitulo
            // 
            this.lblKpiEntregadoTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiEntregadoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblKpiEntregadoTitulo.Location = new System.Drawing.Point(10, 15);
            this.lblKpiEntregadoTitulo.Name = "lblKpiEntregadoTitulo";
            this.lblKpiEntregadoTitulo.Size = new System.Drawing.Size(150, 20);
            this.lblKpiEntregadoTitulo.TabIndex = 2;
            this.lblKpiEntregadoTitulo.Text = "ENTREGADAS";
            // 
            // pnlTablaContenedor
            // 
            this.pnlTablaContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTablaContenedor.BackColor = System.Drawing.Color.White;
            this.pnlTablaContenedor.Controls.Add(this.lblTablaTitulo);
            this.pnlTablaContenedor.Controls.Add(this.dgvEntregasHoy);
            this.pnlTablaContenedor.Location = new System.Drawing.Point(20, 130);
            this.pnlTablaContenedor.Name = "pnlTablaContenedor";
            this.pnlTablaContenedor.Size = new System.Drawing.Size(740, 490);
            this.pnlTablaContenedor.TabIndex = 4;
            // 
            // lblTablaTitulo
            // 
            this.lblTablaTitulo.AutoSize = true;
            this.lblTablaTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTablaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTablaTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTablaTitulo.Name = "lblTablaTitulo";
            this.lblTablaTitulo.Size = new System.Drawing.Size(203, 21);
            this.lblTablaTitulo.TabIndex = 0;
            this.lblTablaTitulo.Text = "Entrega de hoy / Órdenes";
            // 
            // dgvEntregasHoy
            // 
            this.dgvEntregasHoy.AllowUserToAddRows = false;
            this.dgvEntregasHoy.AllowUserToDeleteRows = false;
            this.dgvEntregasHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntregasHoy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntregasHoy.BackgroundColor = System.Drawing.Color.White;
            this.dgvEntregasHoy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEntregasHoy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntregasHoy.Location = new System.Drawing.Point(15, 50);
            this.dgvEntregasHoy.MultiSelect = false;
            this.dgvEntregasHoy.Name = "dgvEntregasHoy";
            this.dgvEntregasHoy.ReadOnly = true;
            this.dgvEntregasHoy.RowHeadersWidth = 51;
            this.dgvEntregasHoy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntregasHoy.Size = new System.Drawing.Size(710, 420);
            this.dgvEntregasHoy.TabIndex = 0;
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.statusStripBottom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.statusStripBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLblEstado,
            this.statusLblSpring,
            this.statusLblTime});
            this.statusStripBottom.Location = new System.Drawing.Point(220, 709);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(788, 22);
            this.statusStripBottom.TabIndex = 3;
            this.statusStripBottom.Text = "statusStripBottom";
            // 
            // statusLblEstado
            // 
            this.statusLblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(222)))), ((int)(((byte)(128)))));
            this.statusLblEstado.Name = "statusLblEstado";
            this.statusLblEstado.Size = new System.Drawing.Size(118, 17);
            this.statusLblEstado.Text = "Estado: Conectado";
            // 
            // statusLblSpring
            // 
            this.statusLblSpring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.statusLblSpring.Name = "statusLblSpring";
            this.statusLblSpring.Size = new System.Drawing.Size(592, 17);
            this.statusLblSpring.Spring = true;
            // 
            // statusLblTime
            // 
            this.statusLblTime.ForeColor = System.Drawing.Color.White;
            this.statusLblTime.Name = "statusLblTime";
            this.statusLblTime.Size = new System.Drawing.Size(63, 17);
            this.statusLblTime.Text = "00:00 AM";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            // 
            // FormPrincial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1008, 731);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.statusStripBottom);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "FormPrincial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clean&&Go Pro - Sistema de Gestión de Lavandería";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlKpiPendientes.ResumeLayout(false);
            this.pnlKpiProceso.ResumeLayout(false);
            this.pnlKpiListo.ResumeLayout(false);
            this.pnlKpiEntregado.ResumeLayout(false);
            this.pnlTablaContenedor.ResumeLayout(false);
            this.pnlTablaContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregasHoy)).EndInit();
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlSidebar;
        private Label lblSidebarTitle;
        private Button btnMenuDashboard;
        private Button btnMenuClientes;
        private Button btnMenuServicios;
        private Button btnMenuPrendas;
        private Button btnMenuOrdenes;
        private Button btnMenuReportes;
        private Button btnMenuUsuarios;
        private Button btnMenuSalir;
        private Button btnSalirApp;
        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblUserStatus;
        private Panel pnlContent;
        private Panel pnlDashboard;
        private Panel pnlKpiPendientes;
        private Panel pnlKpiPendientesBorde;
        private Label lblKpiPendientesValor;
        private Label lblKpiPendientesTitulo;
        private Panel pnlKpiProceso;
        private Panel pnlKpiProcesoBorde;
        private Label lblKpiProcesoValor;
        private Label lblKpiProcesoTitulo;
        private Panel pnlKpiListo;
        private Panel pnlKpiListoBorde;
        private Label lblKpiListoValor;
        private Label lblKpiListoTitulo;
        private Panel pnlKpiEntregado;
        private Panel pnlKpiEntregadoBorde;
        private Label lblKpiEntregadoValor;
        private Label lblKpiEntregadoTitulo;
        private Panel pnlTablaContenedor;
        private Label lblTablaTitulo;
        private DataGridView dgvEntregasHoy;
        private StatusStrip statusStripBottom;
        private ToolStripStatusLabel statusLblEstado;
        private ToolStripStatusLabel statusLblSpring;
        private ToolStripStatusLabel statusLblTime;
        private Timer timerClock;
    }
}
