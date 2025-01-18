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
    /// Clase que representa el mantenimiento de un equipo celular.
    /// </summary>
    public class Mantenimiento
    {
        private interfaceReparacion conexion_db;  // Instancia para acceder a los métodos de la capa de datos
        private DateTime fecha_hoy;  // Fecha del mantenimiento
        private string man_descrip;  // Descripción del mantenimiento
        private int id_mantenimiento;  // ID único del mantenimiento
        private float precio_mant;  // Precio del mantenimiento
        private float precio_rep;  // Precio de los repuestos
        private float mant_costo = 30.0f;  // Costo base del mantenimiento
        private float iva = 0.12f;  // Porcentaje de IVA
        private List<Repuesto> re_mante;  // Lista de repuestos utilizados en el mantenimiento

        /// <summary>
        /// Constructor por defecto de la clase Mantenimiento.
        /// Inicializa las propiedades con valores predeterminados.
        /// </summary>
        public Mantenimiento()
        {
            conexion_db = new interfaceReparacion();
            id_mantenimiento = 0;
            man_descrip = string.Empty;
            precio_mant = 0;
            precio_rep = 0;
            fecha_hoy = DateTime.Now;
            re_mante = new List<Repuesto>();
        }

        /// <summary>
        /// Constructor parametrizado de la clase Mantenimiento.
        /// Inicializa las propiedades con los valores proporcionados.
        /// </summary>
        /// <param name="fecha_hoy">Fecha del mantenimiento.</param>
        /// <param name="man_descrip">Descripción del mantenimiento.</param>
        /// <param name="id_mantenimiento">ID del mantenimiento.</param>
        /// <param name="precio_mant">Precio del mantenimiento.</param>
        /// <param name="precio_rep">Precio de los repuestos.</param>
        public Mantenimiento(DateTime fecha_hoy, string man_descrip, int id_mantenimiento, float precio_mant, float precio_rep)
        {
            this.fecha_hoy = fecha_hoy;
            this.man_descrip = man_descrip;
            this.id_mantenimiento = id_mantenimiento;
            this.precio_mant = precio_mant;
            this.precio_rep = precio_rep;
            conexion_db = new interfaceReparacion();
            re_mante = new List<Repuesto>();
        }

        /// <summary>
        /// Obtiene o establece el ID del mantenimiento.
        /// </summary>
        public int IdMante
        {
            get { return id_mantenimiento; }
            set { id_mantenimiento = value; }
        }

        /// <summary>
        /// Obtiene o establece la fecha del mantenimiento.
        /// </summary>
        public DateTime FechaHoy
        {
            get { return fecha_hoy; }
            set { fecha_hoy = value; }
        }

        /// <summary>
        /// Obtiene o establece la descripción del mantenimiento.
        /// </summary>
        public string ManDescrip
        {
            get { return man_descrip; }
            set { man_descrip = value; }
        }

        /// <summary>
        /// Obtiene o establece el precio del mantenimiento.
        /// </summary>
        public float PrecioMante
        {
            get { return precio_mant; }
            set { precio_mant = value; }
        }

        /// <summary>
        /// Obtiene o establece el precio de los repuestos utilizados.
        /// </summary>
        public float PrecioRep
        {
            get { return precio_rep; }
            set { precio_rep = value; }
        }

        /// <summary>
        /// Obtiene o establece la lista de repuestos utilizados en el mantenimiento.
        /// </summary>
        public List<Repuesto> ReMante
        {
            get { return re_mante; }
            set { re_mante = value; }
        }

        /// <summary>
        /// Calcula el costo total del mantenimiento, incluyendo el precio de los repuestos, el costo base y el IVA.
        /// </summary>
        /// <returns>Devuelve el costo total con IVA incluido.</returns>
        public float CostoTotal()
        {
            // Suma de los precios de los repuestos
            float precio_rep = re_mante.Sum(r => (float)r);
            // Cálculo del subtotal
            float sub = precio_rep + mant_costo;
            // Cálculo del IVA
            float ivaa = sub * iva;
            // Cálculo total con IVA
            return sub + ivaa;
        }

        /// <summary>
        /// Guarda los datos del mantenimiento en la base de datos.
        /// </summary>
        /// <param name="mante">Instancia de la clase Mantenimiento con los datos a guardar.</param>
        /// <returns>Devuelve true si el mantenimiento se guardó correctamente, false en caso contrario.</returns>
        public bool GuardarMante(Mantenimiento mante)
        {
            // Actualiza el precio del mantenimiento con el costo total
            precio_mant = CostoTotal();
            // Convierte la lista de repuestos a una lista de strings
            List<string> repuestosS = re_mante.Select(r => r.ToString()).ToList();
            // Llama al método para guardar el mantenimiento en la base de datos
            return conexion_db.MantenimientoCreado(mante.FechaHoy, mante.ManDescrip, mante.precio_mant, repuestosS);
        }

        /// <summary>
        /// Obtiene los nombres de los clientes desde la base de datos.
        /// </summary>
        /// <returns>Devuelve un DataTable con los nombres de los clientes.</returns>
        public DataTable ObtenerClientes()
        {
            return conexion_db.GetClientNames();
        }

        /// <summary>
        /// Obtiene los nombres de los técnicos desde la base de datos.
        /// </summary>
        /// <returns>Devuelve un DataTable con los nombres de los técnicos.</returns>
        public DataTable ObtenerTecnico()
        {
            return conexion_db.GetTecnicosNames();
        }

        /// <summary>
        /// Obtiene los detalles de los celulares asociados a un cliente específico.
        /// </summary>
        /// <param name="clientId">ID del cliente al que pertenecen los celulares.</param>
        /// <returns>Devuelve un DataTable con los detalles de los celulares asociados al cliente.</returns>
        public DataTable GetCellphoneDetailsByClientId(int clientId)
        {
            return conexion_db.ObtieneCelularesClientes(clientId);
        }

        /// <summary>
        /// Obtiene las reparaciones desde la base de datos.
        /// </summary>
        /// <returns>Devuelve un DataTable con los nombres de los técnicos.</returns>
        public DataTable ObtenerMantenimientos()
        {
            return conexion_db.getAllMantenimientos();
        }

        /// <summary>
        /// Método para eliminar un cliente de la base de datos.
        /// </summary>
        /// <param name="clienteId">ID del cliente que se desea eliminar.</param>
        /// <returns>Devuelve true si el cliente se eliminó correctamente, false en caso contrario.</returns>
        public bool EliminarMantenimientos(int mantenimientoId)
        {
            return conexion_db.EliminarMantenimiento(mantenimientoId);
        }

    }
}

