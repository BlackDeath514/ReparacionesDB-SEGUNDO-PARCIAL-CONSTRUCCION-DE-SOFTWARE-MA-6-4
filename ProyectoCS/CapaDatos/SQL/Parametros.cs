using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.SQL
{
    /// <summary>
    /// Clase que representa un parámetro para procedimientos almacenados en SQL.
    /// Contiene el nombre, tipo y valor del parámetro.
    /// </summary>
    internal class Parametros
    {
        /// <summary>
        /// Nombre del parámetro.
        /// </summary>
        private string name_parameter;

        /// <summary>
        /// Tipo de dato del parámetro en SQL.
        /// </summary>
        private SqlDbType type_parameter;

        /// <summary>
        /// Valor del parámetro.
        /// </summary>
        private object value_parameter;

        /// <summary>
        /// Constructor por defecto. Inicializa los valores predeterminados del parámetro.
        /// </summary>
        public Parametros()
        {
            name_parameter = string.Empty; // Nombre vacío por defecto
            type_parameter = SqlDbType.Int; // Tipo de dato predeterminado: entero
            value_parameter = string.Empty; // Valor vacío por defecto
        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="name_parameter">Nombre del parámetro.</param>
        /// <param name="type_parameter">Tipo de dato del parámetro.</param>
        /// <param name="value_parameter">Valor del parámetro.</param>
        public Parametros(string name_parameter, SqlDbType type_parameter, object value_parameter)
        {
            this.name_parameter = name_parameter;
            this.type_parameter = type_parameter;
            this.value_parameter = value_parameter;
        }

        /// <summary>
        /// Propiedad para obtener o establecer el nombre del parámetro.
        /// </summary>
        public string NameParameter
        {
            get { return name_parameter; }
            set { name_parameter = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer el tipo de dato del parámetro.
        /// </summary>
        public SqlDbType TypeParameter
        {
            get { return type_parameter; }
            set { type_parameter = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer el valor del parámetro.
        /// </summary>
        public object ValueParameter
        {
            get { return value_parameter; }
            set { value_parameter = value; }
        }
    }
}

