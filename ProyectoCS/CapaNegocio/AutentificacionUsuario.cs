using CapaDatos.Interface;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    /// <summary>
    /// Clase que representa la autenticación de un usuario en el sistema.
    /// </summary>
    public class AutentificacionUsuario
    {
        private int id_user;  // ID del usuario
        private string usuario;  // Nombre de usuario
        private string contrasena;  // Contraseña del usuario
        private interfaceReparacion conexion_db;  // Instancia para acceder a los métodos de la base de datos

        /// <summary>
        /// Constructor por defecto de la clase AutentificacionUsuario.
        /// Inicializa los valores de las propiedades con valores predeterminados.
        /// </summary>
        public AutentificacionUsuario()
        {
            id_user = 0;
            usuario = string.Empty;
            contrasena = string.Empty;
            conexion_db = new interfaceReparacion();
        }

        /// <summary>
        /// Constructor parametrizado de la clase AutentificacionUsuario.
        /// Inicializa los valores de las propiedades con los valores proporcionados.
        /// </summary>
        /// <param name="id_user">ID del usuario.</param>
        /// <param name="usuario">Nombre de usuario.</param>
        /// <param name="contrasena">Contraseña del usuario.</param>
        public AutentificacionUsuario(int id_user, string usuario, string contrasena)
        {
            this.id_user = id_user;
            this.usuario = usuario;
            this.contrasena = contrasena;
            conexion_db = new interfaceReparacion();
        }

        /// <summary>
        /// Obtiene o establece el ID del usuario.
        /// </summary>
        public int Id_user
        {
            get { return id_user; }
            set { id_user = value; }
        }

        /// <summary>
        /// Obtiene o establece el nombre de usuario.
        /// </summary>
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        /// <summary>
        /// Método para autentificar al usuario.
        /// Llama al método <see cref="interfaceReparacion.RevisarUsuario"/> de la capa de datos para validar las credenciales del usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>Devuelve true si las credenciales son correctas, false en caso contrario.</returns>
        public bool AuntentificarUsuario(string username, string password)
        {
            return conexion_db.RevisarUsuario(username, password);
        }
    }
}

