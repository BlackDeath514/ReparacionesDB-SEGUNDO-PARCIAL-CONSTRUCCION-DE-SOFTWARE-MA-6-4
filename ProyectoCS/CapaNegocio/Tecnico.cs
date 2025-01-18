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
    /// Clase que representa un técnico, heredando de la clase <see cref="Persona"/>.
    /// </summary>
    public class Tecnico : Persona
    {
        private int id_tec;  // Identificador del técnico
        private string anios_ex;  // Años de experiencia del técnico
        private interfaceReparacion conexion_db;  // Instancia de la interfaz para la conexión a la base de datos

        /// <summary>
        /// Constructor por defecto de la clase <see cref="Tecnico"/>.
        /// </summary>
        public Tecnico()
        {
            id_tec = 0;
            anios_ex = string.Empty;
            conexion_db = new interfaceReparacion();
        }

        /// <summary>
        /// Constructor de la clase <see cref="Tecnico"/> con parámetros para inicializar las propiedades.
        /// </summary>
        /// <param name="id_tec">Identificador del técnico.</param>
        /// <param name="nombres">Nombres del técnico.</param>
        /// <param name="apellidos">Apellidos del técnico.</param>
        /// <param name="cedula">Cédula del técnico.</param>
        /// <param name="numero">Número de contacto del técnico.</param>
        /// <param name="anios_ex">Años de experiencia del técnico.</param>
        public Tecnico(int id_tec, string nombres, string apellidos, string cedula, string numero, string anios_ex)
            : base(nombres, apellidos, cedula, numero)
        {
            this.id_tec = id_tec;
            this.anios_ex = anios_ex;
            conexion_db = new interfaceReparacion();
        }

        /// <summary>
        /// Propiedad que obtiene o establece el identificador del técnico.
        /// </summary>
        public int IdTec
        {
            get { return id_tec; }
            set { id_tec = value; }
        }

        /// <summary>
        /// Propiedad que obtiene o establece los años de experiencia del técnico.
        /// </summary>
        public string Experiencia
        {
            get { return anios_ex; }
            set { anios_ex = value; }
        }

        /// <summary>
        /// Inserta un nuevo técnico en la base de datos.
        /// </summary>
        /// <param name="mi_tecn">Instancia de la clase <see cref="Tecnico"/> que contiene los datos del técnico.</param>
        /// <returns>Devuelve un valor booleano que indica si la inserción fue exitosa.</returns>
        public bool InsertarTec(Tecnico mi_tecn)
        {
            return conexion_db.crearTecnico(mi_tecn.Nombres, mi_tecn.Apellidos, mi_tecn.Cedula, mi_tecn.Numero, mi_tecn.Experiencia);
        }

        /// <summary>
        /// Obtiene una tabla con los datos de todos los técnicos registrados.
        /// </summary>
        /// <returns>Un objeto <see cref="DataTable"/> con los datos de los técnicos.</returns>
        public DataTable ObtenerTecnicos()
        {
            return conexion_db.getAllTecnicos();
        }

        /// <summary>
        /// Elimina un técnico de la base de datos.
        /// </summary>
        /// <param name="mi_tecn">Instancia de la clase <see cref="Tecnico"/> que contiene los datos del técnico a eliminar.</param>
        /// <returns>Devuelve un valor booleano que indica si la eliminación fue exitosa.</returns>
        public bool EliminarTec(Tecnico mi_tecn)
        {
            return conexion_db.EliminarTecnico(mi_tecn.Nombres, mi_tecn.Apellidos, mi_tecn.Cedula, mi_tecn.Numero, mi_tecn.Experiencia);
        }

        /// <summary>
        /// Actualiza los datos de un técnico en la base de datos.
        /// </summary>
        /// <param name="id_tecnico">ID del técnico a actualizar.</param>
        /// <param name="nombre_tecnico">Nuevo nombre del técnico.</param>
        /// <param name="apellido_tecnico">Nuevo apellido del técnico.</param>
        /// <param name="cedula_tecnico">Nueva cédula del técnico.</param>
        /// <param name="numero_tecnico">Nuevo número de teléfono del técnico.</param>
        /// <param name="experiencia_tecnico">Nueva experiencia del técnico.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool ActualizarTec(int id_tecnico, string nombre_tecnico, string apellido_tecnico, string cedula_tecnico, string numero_tecnico, string experiencia_tecnico)
        {
            return conexion_db.actualizarTecnico(id_tecnico, nombre_tecnico, apellido_tecnico, cedula_tecnico, numero_tecnico, experiencia_tecnico);
        }

    }
}
