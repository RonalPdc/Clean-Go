using System;
using System.Windows.Forms;
using Clean_Go_BusinessLogic.Service.Usuarios;
using Clean_Go_DataAccess.Repositories.Roles;
using Clean_Go_DataAccess.Repositories.Usuarios;
using Clean_Go_Entities.Usuarios;
using Clean_Go_Entities.Roles;

namespace Clean_Go.BusinessLogic.Usuarios
{
    public partial class FrmUsuarioEditar : Form
    {
        private readonly UsuariosBLL _usuariosBLL = new UsuariosBLL();
        private readonly RolDAL _rolDAL = new RolDAL();
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();
        private readonly Usuario _usuarioToEdit = null;

        public FrmUsuarioEditar()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        public FrmUsuarioEditar(Usuario usuario) : this()
        {
            _usuarioToEdit = usuario;
            lblTitulo.Text = "Editar Usuario";
            lblSubtitulo.Text = "Modifique los campos correspondientes.";
        }

        private void ConfigurarEventos()
        {
            this.Load += FrmUsuarioEditar_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void FrmUsuarioEditar_Load(object sender, EventArgs e)
        {
                        txtNombre.MaxLength = 50;
            txtApellido.MaxLength = 50;
            txtUsuario.MaxLength = 50;
            txtCorreo.MaxLength = 100;
            txtPassword.MaxLength = 100;

            chkMostrarPassword.CheckedChanged += (s, ev) => {
                bool estadoOriginalEnabled = txtPassword.Enabled;
                txtPassword.Enabled = true;
                
                if (chkMostrarPassword.Checked)
                {
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.PasswordChar = '\0';
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true;
                }
                
                txtPassword.Refresh();
                txtPassword.Enabled = estadoOriginalEnabled;
            };

            CargarRoles();
            
            if (_usuarioToEdit != null)
            {
                CargarDatosUsuario();
            }
        }

        private void CargarRoles()
        {
            try
            {
                var roles = _rolDAL.ObtenerTodos();
                var rolesActivos = roles.FindAll(r => r.Estado);

                cmbRol.DataSource = rolesActivos;
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "RolId";
                cmbRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosUsuario()
        {
            txtNombre.Text = _usuarioToEdit.Nombre;
            txtApellido.Text = _usuarioToEdit.Apellido;
            txtUsuario.Text = _usuarioToEdit.NombreUsuario;
            txtCorreo.Text = _usuarioToEdit.Correo;
            
            try
            {
                var det = _usuariosBLL.ObtenerPorId(_usuarioToEdit.UsuarioId);
                if (det != null)
                {
                    txtPassword.Text = det.PasswordHash;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles del usuario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbRol.SelectedValue = _usuarioToEdit.RolId;
            chkEstado.Checked = _usuarioToEdit.Estado;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El Nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El Apellido es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El Usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El Correo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            string email = txtCorreo.Text.Trim();
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Ingrese una dirección de correo electrónico válida (ejemplo@dominio.com).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La Contraseña es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (cmbRol.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return;
            }

            try
            {
                BloquearControles(false);

                Usuario usuario = _usuarioToEdit ?? new Usuario();
                usuario.Nombre = txtNombre.Text.Trim();
                usuario.Apellido = txtApellido.Text.Trim();
                usuario.NombreUsuario = txtUsuario.Text.Trim();
                usuario.Correo = txtCorreo.Text.Trim();
                usuario.PasswordHash = txtPassword.Text;
                usuario.RolId = (int)cmbRol.SelectedValue;
                usuario.Estado = chkEstado.Checked;

                bool resultado;
                if (_usuarioToEdit == null)
                {
                    resultado = _usuariosBLL.Crear(usuario);
                    if (resultado)
                    {
                        MessageBox.Show("Usuario creado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    resultado = _usuariosBLL.Actualizar(usuario);
                    if (resultado)
                    {
                        _usuarioDAL.ActualizarPassword(usuario.UsuarioId, usuario.PasswordHash);
                        MessageBox.Show("Usuario actualizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (resultado)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el usuario. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BloquearControles(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BloquearControles(true);
            }
        }

        private void BloquearControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtUsuario.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;
            txtPassword.Enabled = habilitar;
            cmbRol.Enabled = habilitar;
            chkEstado.Enabled = habilitar;
            if (chkMostrarPassword != null)
            {
                chkMostrarPassword.Enabled = habilitar;
            }
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            this.Cursor = habilitar ? Cursors.Default : Cursors.WaitCursor;
        }
    }
}
