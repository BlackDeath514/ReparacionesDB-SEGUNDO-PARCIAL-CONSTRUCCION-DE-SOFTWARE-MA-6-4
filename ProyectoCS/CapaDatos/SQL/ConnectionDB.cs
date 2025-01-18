using System.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Clase para gestionar la conexión con la base de datos.
    /// Proporciona métodos para abrir y cerrar conexiones.
    /// </summary>
    internal class ConnectionDB
    {
        /// <summary>
        /// Objeto de conexión SQL configurado con el servidor y la base de datos.
        /// </summary>
        private SqlConnection conexion_db = new SqlConnection("server=DORMITORIOPC\\SQLEXPRESS; database=DB_POE_FINAL; Integrated Security=true");

        /// <summary>
        /// Abre la conexión con la base de datos si no está ya abierta.
        /// </summary>
        /// <returns>Objeto SqlConnection abierto.</returns>
        public SqlConnection AbrirConexion()
        {
            if (conexion_db.State == System.Data.ConnectionState.Closed)
                conexion_db.Open(); // Abre la conexión si está cerrada
            return conexion_db; // Retorna la conexión abierta
        }

        /// <summary>
        /// Cierra la conexión con la base de datos si está abierta.
        /// </summary>
        /// <returns>Objeto SqlConnection cerrado.</returns>
        public SqlConnection CerrarConexion()
        {
            if (conexion_db.State == System.Data.ConnectionState.Open)
                conexion_db.Close(); // Cierra la conexión si está abierta
            return conexion_db; // Retorna la conexión cerrada
        }
    }
}

