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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincial));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserStatus = new System.Windows.Forms.Label();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCambiarContra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTiposPrenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTiposPrenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdenes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOrdenes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReporteOrdenes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReporteClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReporteServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblPlaceholderText = new System.Windows.Forms.Label();
            this.lblPlaceholderIcon = new System.Windows.Forms.Label();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.statusLblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.statusStripBottom.SuspendLayout();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.lblUserStatus);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1008, 55);
            this.pnlHeader.TabIndex = 0;

            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(80, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(118, 30);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Clean&&Go";

            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;

            this.lblUserStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUserStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblUserStatus.Location = new System.Drawing.Point(600, 15);
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new System.Drawing.Size(393, 25);
            this.lblUserStatus.TabIndex = 1;
            this.lblUserStatus.Text = "Usuario: Admin";
            this.lblUserStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.menuStripMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.menuStripMain.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArchivo,
            this.menuSeguridad,
            this.menuClientes,
            this.menuServicios,
            this.menuTiposPrenda,
            this.menuOrdenes,
            this.menuReportes,
            this.menuAyuda});
            this.menuStripMain.Location = new System.Drawing.Point(0, 55);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.menuStripMain.Size = new System.Drawing.Size(1008, 35);
            this.menuStripMain.TabIndex = 1;

            this.menuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCambiarContra,
            this.menuItemCerrarSesion,
            this.menuItemSalir});
            this.menuArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.menuArchivo.Name = "menuArchivo";
            this.menuArchivo.Size = new System.Drawing.Size(67, 23);
            this.menuArchivo.Text = "Archivo";

            this.menuItemCambiarContra.Name = "menuItemCambiarContra";
            this.menuItemCambiarContra.Size = new System.Drawing.Size(200, 24);
            this.menuItemCambiarContra.Text = "Cambiar contraseña";
            this.menuItemCambiarContra.Click += new System.EventHandler(this.menuItemCambiarContra_Click);

            this.menuItemCerrarSesion.Name = "menuItemCerrarSesion";
            this.menuItemCerrarSesion.Size = new System.Drawing.Size(200, 24);
            this.menuItemCerrarSesion.Text = "Cerrar sesión";
            this.menuItemCerrarSesion.Click += new System.EventHandler(this.menuItemCerrarSesion_Click);

            this.menuItemSalir.Name = "menuItemSalir";
            this.menuItemSalir.Size = new System.Drawing.Size(200, 24);
            this.menuItemSalir.Text = "Salir";
            this.menuItemSalir.Click += new System.EventHandler(this.menuItemSalir_Click);

            this.menuSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUsuarios});
            this.menuSeguridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.menuSeguridad.Name = "menuSeguridad";
            this.menuSeguridad.Size = new System.Drawing.Size(82, 23);
            this.menuSeguridad.Text = "Seguridad";

            this.menuItemUsuarios.Name = "menuItemUsuarios";
            this.menuItemUsuarios.Size = new System.Drawing.Size(180, 24);
            this.menuItemUsuarios.Text = "Usuarios";
            this.menuItemUsuarios.Click += new System.EventHandler(this.menuItemUsuarios_Click);

            this.menuClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClientes});
            this.menuClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(69, 23);
            this.menuClientes.Text = "Clientes";

            this.menuItemClientes.Name = "menuItemClientes";
            this.menuItemClientes.Size = new System.Drawing.Size(200, 24);
            this.menuItemClientes.Text = "Administrar Clientes";

            this.menuServicios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemServicios});
            this.menuServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.menuServicios.Name = "menuServicios";
            this.menuServicios.Size = new System.Drawing.Size(73, 23);
            this.menuServicios.Text = "Servicios";

            this.menuItemServicios.Name = "menuItemServicios";
            this.menuItemServicios.Size = new System.Drawing.Size(200, 24);
            this.menuItemServicios.Text = "Administrar Servicios";

            this.menuTiposPrenda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTiposPrenda});
            this.menuTiposPrenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.menuTiposPrenda.Name = "menuTiposPrenda";
            this.menuTiposPrenda.Size = new System.Drawing.Size(119, 23);
            this.menuTiposPrenda.Text = "Tipos de Prenda";

            this.menuItemTiposPrenda.Name = "menuItemTiposPrenda";
            this.menuItemTiposPrenda.Size = new System.Drawing.Size(200, 24);
            this.menuItemTiposPrenda.Text = "Administrar Tipos de Prenda";

            this.menuOrdenes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOrdenes});
            this.menuOrdenes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.menuOrdenes.Name = "menuOrdenes";
            this.menuOrdenes.Size = new System.Drawing.Size(73, 23);
            this.menuOrdenes.Text = "Órdenes";

            this.menuItemOrdenes.Name = "menuItemOrdenes";
            this.menuItemOrdenes.Size = new System.Drawing.Size(200, 24);
            this.menuItemOrdenes.Text = "Administrar Órdenes";

            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemReporteOrdenes,
            this.menuItemReporteClientes,
            this.menuItemReporteServicios});
            this.menuReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(75, 23);
            this.menuReportes.Text = "Reportes";

            this.menuItemReporteOrdenes.Name = "menuItemReporteOrdenes";
            this.menuItemReporteOrdenes.Size = new System.Drawing.Size(130, 24);
            this.menuItemReporteOrdenes.Text = "Órdenes";

            this.menuItemReporteClientes.Name = "menuItemReporteClientes";
            this.menuItemReporteClientes.Size = new System.Drawing.Size(130, 24);
            this.menuItemReporteClientes.Text = "Clientes";

            this.menuItemReporteServicios.Name = "menuItemReporteServicios";
            this.menuItemReporteServicios.Size = new System.Drawing.Size(130, 24);
            this.menuItemReporteServicios.Text = "Servicios";

            this.menuAyuda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.menuAyuda.Name = "menuAyuda";
            this.menuAyuda.Size = new System.Drawing.Size(60, 23);
            this.menuAyuda.Text = "Ayuda";

            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.lblPlaceholderText);
            this.pnlContent.Controls.Add(this.lblPlaceholderIcon);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 90);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1008, 619);
            this.pnlContent.TabIndex = 2;

            this.lblPlaceholderText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlaceholderText.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblPlaceholderText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPlaceholderText.Location = new System.Drawing.Point(200, 320);
            this.lblPlaceholderText.Name = "lblPlaceholderText";
            this.lblPlaceholderText.Size = new System.Drawing.Size(608, 30);
            this.lblPlaceholderText.TabIndex = 1;
            this.lblPlaceholderText.Text = "Seleccione una opción del menú para comenzar";
            this.lblPlaceholderText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblPlaceholderIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlaceholderIcon.Font = new System.Drawing.Font("Segoe UI", 48F);
            this.lblPlaceholderIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblPlaceholderIcon.Location = new System.Drawing.Point(200, 220);
            this.lblPlaceholderIcon.Name = "lblPlaceholderIcon";
            this.lblPlaceholderIcon.Size = new System.Drawing.Size(608, 100);
            this.lblPlaceholderIcon.TabIndex = 0;
            this.lblPlaceholderIcon.Text = "🧺";
            this.lblPlaceholderIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.statusStripBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.statusStripBottom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLblEstado,
            this.statusLblSpring,
            this.statusLblTime});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 709);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(1008, 22);
            this.statusStripBottom.TabIndex = 3;
            this.statusStripBottom.Text = "statusStripBottom";

            this.statusLblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(222)))), ((int)(((byte)(128)))));
            this.statusLblEstado.Name = "statusLblEstado";
            this.statusLblEstado.Size = new System.Drawing.Size(118, 17);
            this.statusLblEstado.Text = "Estado: Conectado";

            this.statusLblSpring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.statusLblSpring.Name = "statusLblSpring";
            this.statusLblSpring.Size = new System.Drawing.Size(812, 17);
            this.statusLblSpring.Spring = true;

            this.statusLblTime.ForeColor = System.Drawing.Color.White;
            this.statusLblTime.Name = "statusLblTime";
            this.statusLblTime.Size = new System.Drawing.Size(63, 17);
            this.statusLblTime.Text = "00:00 AM";

            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 731);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.statusStripBottom);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.pnlHeader);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormPrincial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clean&&Go Pro - Sistema de Gestión de Lavandería";
            this.Load += new System.EventHandler(this.FormPrincial_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblUserStatus;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem menuArchivo;
        private ToolStripMenuItem menuItemCambiarContra;
        private ToolStripMenuItem menuItemCerrarSesion;
        private ToolStripMenuItem menuItemSalir;
        private ToolStripMenuItem menuSeguridad;
        private ToolStripMenuItem menuItemUsuarios;
        private ToolStripMenuItem menuClientes;
        private ToolStripMenuItem menuItemClientes;
        private ToolStripMenuItem menuServicios;
        private ToolStripMenuItem menuItemServicios;
        private ToolStripMenuItem menuTiposPrenda;
        private ToolStripMenuItem menuItemTiposPrenda;
        private ToolStripMenuItem menuOrdenes;
        private ToolStripMenuItem menuItemOrdenes;
        private ToolStripMenuItem menuReportes;
        private ToolStripMenuItem menuItemReporteOrdenes;
        private ToolStripMenuItem menuItemReporteClientes;
        private ToolStripMenuItem menuItemReporteServicios;
        private ToolStripMenuItem menuAyuda;
        
        private Panel pnlContent;
        private Label lblPlaceholderIcon;
        private Label lblPlaceholderText;
        
        private StatusStrip statusStripBottom;
        private ToolStripStatusLabel statusLblEstado;
        private ToolStripStatusLabel statusLblSpring;
        private ToolStripStatusLabel statusLblTime;
        private Timer timerClock;
        private PictureBox pictureBox1;
    }
}
