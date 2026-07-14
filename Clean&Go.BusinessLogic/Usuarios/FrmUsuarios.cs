using System;
using System.Drawing;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Usuarios;
using Clean_Go_Entities.Usuarios;
using Clean_Go.BusinessLogic;

namespace Clean_Go.BusinessLogic.Usuarios
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuariosBLL _usuarioBLL = new UsuariosBLL();

        public FrmUsuarios()
        {
            InitializeComponent();
            ConfigurarEventos();

            // Estilos Premium
            DisenoHelper.StyleButton(btnNuevo, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnEditar, Color.FromArgb(8, 145, 178), Color.White);
            DisenoHelper.StyleButton(btnBuscar, Color.FromArgb(71, 85, 105), Color.White);
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmUsuarios_Load;
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnBuscar.Click += BtnBuscar_Click;
            txtBuscar.KeyDown += TxtBuscar_KeyDown;
            UsuariosBLL.AlCambiarUsuarios += CargarUsuarios;
            this.FormClosed += (s, e) => UsuariosBLL.AlCambiarUsuarios -= CargarUsuarios;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            DisenoHelper.StyleGrid(dgvUsuarios);
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                var usuarios = _usuarioBLL.ObtenerTodos();

                string filtro = txtBuscar.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(filtro))
                {
                    usuarios = usuarios.FindAll(u =>
                        (u.Nombre != null && u.Nombre.ToLower().Contains(filtro)) ||
                        (u.Apellido != null && u.Apellido.ToLower().Contains(filtro)) ||
                        (u.NombreUsuario != null && u.NombreUsuario.ToLower().Contains(filtro)) ||
                        (u.Correo != null && u.Correo.ToLower().Contains(filtro)) ||
                        (u.Rol != null && u.Rol.ToLower().Contains(filtro)) ||
                        u.UsuarioId.ToString() == filtro
                    );
                }

                dgvUsuarios.DataSource = usuarios;

                if (dgvUsuarios.Columns.Contains("UsuarioId")) dgvUsuarios.Columns["UsuarioId"].HeaderText = "ID";
                if (dgvUsuarios.Columns.Contains("Nombre")) dgvUsuarios.Columns["Nombre"].HeaderText = "Nombre";
                if (dgvUsuarios.Columns.Contains("Apellido")) dgvUsuarios.Columns["Apellido"].HeaderText = "Apellido";
                if (dgvUsuarios.Columns.Contains("NombreUsuario")) dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
                if (dgvUsuarios.Columns.Contains("Correo")) dgvUsuarios.Columns["Correo"].HeaderText = "Correo";
                if (dgvUsuarios.Columns.Contains("Rol")) dgvUsuarios.Columns["Rol"].HeaderText = "Rol";
                if (dgvUsuarios.Columns.Contains("Estado")) dgvUsuarios.Columns["Estado"].HeaderText = "Estado";
                if (dgvUsuarios.Columns.Contains("PasswordHash")) dgvUsuarios.Columns["PasswordHash"].Visible = false;
                if (dgvUsuarios.Columns.Contains("RolId")) dgvUsuarios.Columns["RolId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de usuarios:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmUsuarioEditar frm = new FrmUsuarioEditar())
            {
                frm.ShowDialog();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Usuario usuarioSeleccionado = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
            using (FrmUsuarioEditar frm = new FrmUsuarioEditar(usuarioSeleccionado))
            {
                frm.ShowDialog();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarUsuarios();
                e.Handled = true;
                e.SuppressKeyPress = true; // Previene el sonido de beep del sistema
            }
        }
    }
}
