using CapaDatos.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Clase que representa a un cliente, hereda de la clase <see cref="Persona"/>.
    /// </summary>
    public class Cliente : Persona
    {
        private int id_cliente;  // ID único del cliente
        private string direccion;  // Dirección del cliente
        private List<EquipoCelular> celular;  // Lista de celulares asociados al cliente
        private interfaceReparacion conexion_db;  // Instancia para acceder a los métodos de la capa de datos

        /// <summary>
        /// Constructor por defecto de la clase Cliente.
        /// Inicializa las propiedades con valores predeterminados.
        /// </summary>
        public Cliente()
        {
            id_cliente = 0;
            direccion = string.Empty;
            celular = new List<EquipoCelular>();
            conexion_db = new interfaceReparacion();
        }

        /// <summary>
        /// Constructor parametrizado de la clase Cliente.
        /// Inicializa las propiedades con los valores proporcionados.
        /// </summary>
        /// <param name="id_cliente">ID del cliente.</param>
        /// <param name="nombres">Nombres del cliente.</param>
        /// <param name="apellidos">Apellidos del cliente.</param>
        /// <param name="cedula">Cédula del cliente.</param>
        /// <param name="direccion">Dirección del cliente.</param>
        /// <param name="numero">Número de contacto del cliente.</param>
        public Cliente(int id_cliente, string nombres, string apellidos, string cedula, string direccion, string numero)
            : base(nombres, apellidos, cedula, numero)
        {
            this.id_cliente = id_cliente;
            this.direccion = direccion;
            celular = new List<EquipoCelular>();
            conexion_db = new interfaceReparacion();
        }

        /// <summary>
        /// Obtiene o establece el ID del cliente.
        /// </summary>
        public int IdCliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        /// <summary>
        /// Obtiene o establece la dirección del cliente.
        /// </summary>
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        /// <summary>
        /// Obtiene o establece la lista de celulares asociados al cliente.
        /// </summary>
        public List<EquipoCelular> Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        /// <summary>
        /// Método para insertar un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="mi_cliente">Instancia de la clase Cliente que contiene los datos del nuevo cliente.</param>
        /// <returns>Devuelve true si el cliente se insertó correctamente, false en caso contrario.</returns>
        public bool InsertarCliente(Cliente mi_cliente)
        {
            return conexion_db.crearCliente(mi_cliente.Nombres, mi_cliente.Apellidos, mi_cliente.Cedula, mi_cliente.Numero, mi_cliente.Direccion);
        }

        /// <summary>
        /// Método para obtener todos los clientes desde la base de datos.
        /// </summary>
        /// <returns>Devuelve un DataTable con los datos de todos los clientes.</returns>
        public DataTable ObtenerTodosClientes()
        {
            return conexion_db.getAllClientes();
        }

        /// <summary>
        /// Método para eliminar un cliente de la base de datos.
        /// </summary>
        /// <param name="clienteId">ID del cliente que se desea eliminar.</param>
        /// <returns>Devuelve true si el cliente se eliminó correctamente, false en caso contrario.</returns>
        public bool EliminarClientes(int clienteId)
        {
            return conexion_db.eliminarCliente(clienteId);
        }

        /// <summary>
        /// Método para actualizar un cliente de la base de datos.
        /// </summary>
        /// <param name="clienteId">ID del cliente que se desea eliminar.</param>
        /// <returns>Devuelve true si el cliente se eliminó correctamente, false en caso contrario.</returns>
        public bool actualizarCliente(int id_cliente, string nombre_cliente, string apellido_cliente, string cedula_cliente, string numero_cliente, string direccion_cliente)
        {
            return conexion_db.actualizarCliente(id_cliente, nombre_cliente, apellido_cliente, cedula_cliente, numero_cliente, direccion_cliente);
        }
    }
}
