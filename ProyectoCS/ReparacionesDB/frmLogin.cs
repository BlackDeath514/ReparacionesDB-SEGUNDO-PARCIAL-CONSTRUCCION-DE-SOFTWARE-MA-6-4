using CapaNegocio;
using CapaPresentacion;
using System.Windows.Forms;

namespace ReparacionesDB
{
    /// <summary>
    /// Representa el formulario de inicio de sesión de la aplicación.
    /// Gestiona la autenticación del usuario y la navegación a la pantalla principal.
    /// </summary>
    public partial class frmLogin : Form
    {
        /// <summary>
        /// Instancia de la clase encargada de autenticar al usuario.
        /// </summary>
        private AutentificacionUsuario verif_usuario;

        /// <summary>
        /// Constructor de la clase Login.
        /// Inicializa los componentes del formulario y crea una nueva instancia de autentificacionUsuario.
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
            verif_usuario = new AutentificacionUsuario();
            
        }

        /// <summary>
        /// Limpia los campos de usuario y contraseña.
        /// Este método se utiliza para restablecer los campos de texto en el formulario.
        /// </summary>
        public void SetearCampos()
        {
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
        }

        /// <summary>
        /// Controlador del evento de clic en el botón "Entrar".
        /// Intenta autenticar al usuario con el nombre de usuario y contraseña proporcionados.
        /// Si la autenticación es exitosa, muestra la pantalla principal. De lo contrario, muestra un mensaje de error.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento, en este caso el botón "Entrar".</param>
        /// <param name="e">El objeto de eventos que contiene información sobre el evento.</param>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUsuario.Text == "Ingrese usuario" || string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Por favor, ingrese un usuario válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtContrasena.Text == "Ingrese contraseña" || string.IsNullOrWhiteSpace(txtContrasena.Text))
                {
                    MessageBox.Show("Por favor, ingrese una contraseña válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Obtener los valores de los campos de texto
                string username = txtUsuario.Text;
                string password = txtContrasena.Text;

                // Verificar la autenticación del usuario
                bool isAuthenticated = verif_usuario.AuntentificarUsuario(username, password);

                if (isAuthenticated)
                {
                    // Si la autenticación es exitosa, mostrar mensaje y abrir la página principal
                    MessageBox.Show("BIENVENIDO " + username + " !");
                    Form paginaPrincipal = new frmPrincipal();
                    paginaPrincipal.FormClosed += NewForm_FormClosed;
                    paginaPrincipal.Show();
                    this.Hide(); //Ocultar el formulario de login
                }
                else
                {
                    // Si las credenciales son incorrectas, mostrar un mensaje de error y limpiar los campos
                    MessageBox.Show("Usuario o contraseña invalidos");
                    SetearCampos();
                }
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, mostrar el mensaje de error
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(Object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close(); // Cierra Form1 cuando Form2 se cierra
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}