using CapaDatos.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    /// <summary>
    /// Enumeración que representa los diferentes tipos de repuestos con sus respectivos costos.
    /// </summary>
    public enum Repuesto
    {
        /// <summary>
        /// Representa el repuesto de pantalla con un costo de 30 unidades monetarias.
        /// </summary>
        Pantalla = 30,

        /// <summary>
        /// Representa el repuesto de batería con un costo de 20 unidades monetarias.
        /// </summary>
        Bateria = 20,

        /// <summary>
        /// Representa los repuestos de accesorios con un costo de 15 unidades monetarias.
        /// </summary>
        Accesorios = 15,

        /// <summary>
        /// Representa el repuesto de botones con un costo de 10 unidades monetarias.
        /// </summary>
        Botones = 10,

        /// <summary>
        /// Representa el repuesto de carcaza con un costo de 7 unidades monetarias.
        /// </summary>
        Carcaza = 7
    }
}
