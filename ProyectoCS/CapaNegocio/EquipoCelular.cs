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
    /// Clase que representa un equipo celular, asociado a un cliente.
    /// </summary>
    public class EquipoCelular
    {
        private int id_celular;  // ID único del equipo celular
        private string modelo;  // Modelo del equipo celular
        private string marca;  // Marca del equipo celular
        private string detalle;  // Detalles adicionales del equipo celular
        private int cliente_id;  // ID del cliente al que pertenece el equipo celular
        private interfaceReparacion conexion_db;  // Instancia para acceder a los métodos de la capa de datos

        /// <summary>
        /// Constructor por defecto de la clase EquipoCelular.
        /// Inicializa las propiedades con valores predeterminados.
        /// </summary>
        public EquipoCelular()
        {
            id_celular = 0;
            modelo = string.Empty;
            marca = string.Empty;
            detalle = string.Empty;
            cliente_id = 0;
            conexion_db = new interfaceReparacion();
        }

        /// <summary>
        /// Constructor parametrizado de la clase EquipoCelular.
        /// Inicializa las propiedades con los valores proporcionados.
        /// </summary>
        /// <param name="id_celular">ID del equipo celular.</param>
        /// <param name="modelo">Modelo del equipo celular.</param>
        /// <param name="marca">Marca del equipo celular.</param>
        /// <param name="detalle">Detalles adicionales del equipo celular.</param>
        /// <param name="cliente_id">ID del cliente al que pertenece el equipo celular.</param>
        public EquipoCelular(int id_celular, string modelo, string marca, string detalle, int cliente_id)
        {
            this.id_celular = id_celular;
            this.modelo = modelo;
            this.marca = marca;
            this.detalle = detalle;
            this.cliente_id = cliente_id;
            conexion_db = new interfaceReparacion();
        }

        /// <summary>
        /// Obtiene o establece el ID del equipo celular.
        /// </summary>
        public int IdEquipo
        {
            get { return id_celular; }
            set { id_celular = value; }
        }

        /// <summary>
        /// Obtiene o establece el modelo del equipo celular.
        /// </summary>
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        /// <summary>
        /// Obtiene o establece la marca del equipo celular.
        /// </summary>
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        /// <summary>
        /// Obtiene o establece los detalles adicionales del equipo celular.
        /// </summary>
        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        /// <summary>
        /// Obtiene o establece el ID del cliente asociado al equipo celular.
        /// </summary>
        public int ClienteID
        {
            get { return cliente_id; }
            set { cliente_id = value; }
        }

        /// <summary>
        /// Método para agregar un nuevo equipo celular al sistema.
        /// </summary>
        /// <param name="celu">Instancia de la clase EquipoCelular con los datos del equipo a agregar.</param>
        /// <returns>Devuelve true si el equipo celular se agregó correctamente, false en caso contrario.</returns>
        public bool AgregarCelular(EquipoCelular celu)
        {
            try
            {
                return conexion_db.crearEquipo(celu.Modelo, celu.Marca, celu.Detalle, celu.ClienteID);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Método para obtener todos los equipos celulares asociados a un cliente.
        /// </summary>
        /// <param name="clienteId">ID del cliente al que pertenecen los equipos celulares.</param>
        /// <returns>Devuelve un DataTable con todos los equipos celulares asociados al cliente.</returns>
        public DataTable ObtenerTodosCelular()
        {
            return conexion_db.getAllCelular();
        }

        /// <summary>
        /// Método para eliminar un equipo celular del sistema.
        /// </summary>
        /// <param name="idEquipo">ID del equipo celular a eliminar.</param>
        /// <returns>Devuelve true si el equipo celular se eliminó correctamente, false en caso contrario.</returns>
        public bool EliminarCelular(int idEquipo)
        {
            try
            {
                return conexion_db.eliminarEquipo(idEquipo);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al eliminar el celular: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Método para actualizar un equipo celular en el sistema.
        /// </summary>
        /// <param name="idEquipo">ID del equipo celular.</param>
        /// <param name="modelo">Modelo del equipo celular.</param>
        /// <param name="marca">Marca del equipo celular.</param>
        /// <param name="detalles">Detalles del equipo celular.</param>
        /// <param name="clienteId">ID del cliente asociado al equipo celular.</param>
        /// <returns>Devuelve true si el equipo celular se actualizó correctamente, false en caso contrario.</returns>
        public bool actualizarEquipo(int idEquipo, string modelo, string marca, string detalles, int clienteId)
        {
            try
            {
                // Llamar al método de la capa de datos para actualizar el equipo
                return conexion_db.actualizarEquipo(idEquipo, modelo, marca, detalles, clienteId);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes registrar el error en un log si es necesario
                Console.WriteLine("Error en la capa de negocio: " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Método para obtener los nombres de los clientes desde la base de datos.
        /// </summary>
        /// <returns>Devuelve un DataTable con los nombres de los clientes.</returns>
        public DataTable ObtenerCliente()
        {
            return conexion_db.GetClientNames();
        }
    }
}
