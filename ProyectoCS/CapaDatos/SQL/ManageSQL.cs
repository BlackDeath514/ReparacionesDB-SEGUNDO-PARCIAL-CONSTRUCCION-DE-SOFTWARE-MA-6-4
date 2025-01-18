using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.SQL;

namespace CapaDatos
{
    internal class ManageSQL
    {
        // Instancia para manejar la conexión a la base de datos
        private ConnectionDB conn = new ConnectionDB();

        /// <summary>
        /// Ejecuta sentencias SQL de tipo INSERT, UPDATE o DELETE.
        /// </summary>
        /// <param name="sql">La sentencia SQL a ejecutar.</param>
        /// <returns>True si la operación afecta filas; de lo contrario, False.</returns>
        public bool EjecutarNoQuery(string sql)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.Text; // Tipo de ejecución: texto
            command.CommandText = sql; // Asignar la sentencia SQL
            command.Connection = conn.AbrirConexion(); // Abrir conexión
            var resultado = command.ExecuteNonQuery();
            return resultado > 0;
        }

        /// <summary>
        /// Ejecuta una consulta SELECT y devuelve los resultados en un DataTable.
        /// </summary>
        /// <param name="sql">La sentencia SQL de tipo SELECT.</param>
        /// <returns>Un DataTable con los resultados de la consulta.</returns>
        public DataTable EjecutarSelect(string sql)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = conn.AbrirConexion();
            SqlDataReader reader = command.ExecuteReader();
            using (var tabla = new DataTable())
            {
                tabla.Load(reader);
                reader.DisposeAsync();
                conn.CerrarConexion();
                return tabla;
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado que no recibe parámetros y devuelve los resultados en un DataTable.
        /// </summary>
        /// <param name="sp_name">El nombre del procedimiento almacenado.</param>
        /// <returns>Un DataTable con los resultados del procedimiento almacenado.</returns>
        public DataTable EjecutarSPSelect(string sp_name)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = sp_name;
            command.Connection = conn.AbrirConexion();
            SqlDataReader reader = command.ExecuteReader();
            using (var tabla = new DataTable())
            {
                tabla.Load(reader);
                reader.DisposeAsync();
                conn.CerrarConexion();
                return tabla;
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado con parámetros y devuelve los resultados en un DataTable.
        /// </summary>
        /// <param name="sp_name">El nombre del procedimiento almacenado.</param>
        /// <param name="lista_parametros">Lista de parámetros a pasar al procedimiento almacenado.</param>
        /// <returns>Un DataTable con los resultados del procedimiento almacenado.</returns>
        public DataTable EjecutarSPSelect(string sp_name, List<Parametros> lista_parametros)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = sp_name;
            foreach (var parametro in lista_parametros)
                command.Parameters.Add(parametro.NameParameter, parametro.TypeParameter).Value = parametro.ValueParameter;
            command.Connection = conn.AbrirConexion();
            SqlDataReader reader = command.ExecuteReader();
            using (var tabla = new DataTable())
            {
                tabla.Load(reader);
                reader.DisposeAsync();
                conn.CerrarConexion();
                return tabla;
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado de tipo INSERT, UPDATE o DELETE que no recibe parámetros.
        /// </summary>
        /// <param name="name_sp">El nombre del procedimiento almacenado.</param>
        /// <returns>True si la operación afecta filas; de lo contrario, False.</returns>
        public bool EjecutarSPNoQuery(string name_sp)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name_sp;
            command.Connection = conn.AbrirConexion();
            var resultado = command.ExecuteNonQuery();
            return resultado > 0;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado de tipo INSERT, UPDATE o DELETE con parámetros.
        /// </summary>
        /// <param name="name_sp">El nombre del procedimiento almacenado.</param>
        /// <param name="lista_parametros">Lista de parámetros a pasar al procedimiento almacenado.</param>
        /// <returns>True si la operación afecta filas; de lo contrario, False.</returns>
        public bool EjecutarSPNoQuery(string name_sp, List<Parametros> lista_parametros)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name_sp;
            foreach (var parametro in lista_parametros)
                command.Parameters.Add(parametro.NameParameter, parametro.TypeParameter).Value = parametro.ValueParameter;
            command.Connection = conn.AbrirConexion();
            var resultado = command.ExecuteNonQuery();
            return resultado > 0;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado para autenticar a un usuario.
        /// </summary>
        /// <param name="sp_name">El nombre del procedimiento almacenado.</param>
        /// <param name="lista_parametros">Lista de parámetros a pasar al procedimiento almacenado.</param>
        /// <returns>True si la autenticación es exitosa; de lo contrario, False.</returns>
        public bool EjecutarAutentificarUsuario(string sp_name, List<Parametros> lista_parametros)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = sp_name;
            foreach (var parametro in lista_parametros)
                command.Parameters.Add(parametro.NameParameter, parametro.TypeParameter).Value = parametro.ValueParameter;
            command.Connection = conn.AbrirConexion();
            int result = Convert.ToInt32(command.ExecuteScalar());
            conn.CerrarConexion();
            return result == 1;
        }

        /// <summary>
        /// Obtiene los nombres de los clientes.
        /// </summary>
        /// <returns>Un DataTable con los nombres de los clientes.</returns>
        public DataTable GetClienteNombres()
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_GET_NOMBRE_CLIENTE";
            command.Connection = conn.AbrirConexion();
            SqlDataReader reader = command.ExecuteReader();
            using (var tabla = new DataTable())
            {
                tabla.Load(reader);
                reader.DisposeAsync();
                conn.CerrarConexion();
                return tabla;
            }
        }

        /// <summary>
        /// Obtiene los nombres de los técnicos.
        /// </summary>
        /// <returns>Un DataTable con los nombres de los técnicos.</returns>
        public DataTable GetTecnicosNombres()
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_GET_NOMBRE_TECNICO";
            command.Connection = conn.AbrirConexion();
            SqlDataReader reader = command.ExecuteReader();
            using (var tabla = new DataTable())
            {
                tabla.Load(reader);
                reader.DisposeAsync();
                conn.CerrarConexion();
                return tabla;
            }
        }

        /// <summary>
        /// Obtiene los celulares de un cliente específico.
        /// </summary>
        /// <param name="clientId">El ID del cliente.</param>
        /// <returns>Un DataTable con los datos de los celulares del cliente.</returns>
        public DataTable GetCelularClientes(int clientId)
        {
            var command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CELULAR_CLIENTE"; // Procedimiento almacenado para obtener marca y modelo
            command.Parameters.Add(new SqlParameter("@CLIENTE_ID", SqlDbType.Int)).Value = clientId;
            command.Connection = conn.AbrirConexion();
            SqlDataReader reader = command.ExecuteReader();
            using (var tabla = new DataTable())
            {
                tabla.Load(reader);
                reader.DisposeAsync();
                conn.CerrarConexion();
                return tabla;
            }
        }
    }
}