using System;

namespace CapaNegocio
{
    /// <summary>
    /// Representa una persona con información básica como nombres, apellidos, cédula y número de teléfono.
    /// </summary>
    public class Persona
    {
        // Campos privados
        private string nombres;  // Primer nombre de la persona
        private string apellidos; // Apellidos de la persona
        private string cedula;  // Cédula o número de identificación personal
        private string numero;  // Número de teléfono de la persona

        /// <summary>
        /// Constructor por defecto que inicializa todas las propiedades con valores vacíos.
        /// </summary>
        public Persona()
        {
            nombres = string.Empty;
            apellidos = string.Empty;
            cedula = string.Empty;
            numero = string.Empty;
        }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Persona con los valores proporcionados.
        /// </summary>
        /// <param name="nombre">El primer nombre de la persona.</param>
        /// <param name="apellido">El apellido de la persona.</param>
        /// <param name="cedula">La cédula o número de identificación personal.</param>
        /// <param name="numero">El número de teléfono de la persona.</param>
        public Persona(string nombre, string apellido, string cedula, string numero)
        {
            this.nombres = nombre;
            this.apellidos = apellido;
            this.cedula = cedula;
            this.numero = numero;
        }

        /// <summary>
        /// Obtiene o establece el primer nombre de la persona.
        /// </summary>
        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        /// <summary>
        /// Obtiene o establece los apellidos de la persona.
        /// </summary>
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        /// <summary>
        /// Obtiene o establece la cédula o número de identificación personal de la persona.
        /// </summary>
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        /// <summary>
        /// Obtiene o establece el número de teléfono de la persona.
        /// </summary>
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }
    }
}
