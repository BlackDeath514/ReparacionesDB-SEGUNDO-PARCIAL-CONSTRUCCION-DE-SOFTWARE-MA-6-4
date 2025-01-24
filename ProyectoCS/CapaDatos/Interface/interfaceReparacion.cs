using CapaDatos.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interface
{
    public class interfaceReparacion
    {
        // Instancia de la clase ManageSQL para realizar operaciones con la base de datos
        private ManageSQL obj_bd = new ManageSQL();

        //--------------------CLIENTE

        /// <summary>
        /// Obtiene todos los clientes de la base de datos.
        /// </summary>
        /// <returns>DataTable con los datos de todos los clientes.</returns>
        public DataTable getAllClientes()
        {
            return obj_bd.EjecutarSPSelect("SP_GET_ALL_CLIENTE");
        }

        /// <summary>
        /// Crea un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="nombre_cliente">Nombre del cliente.</param>
        /// <param name="apellido_cliente">Apellido del cliente.</param>
        /// <param name="cedula_cliente">Cédula del cliente.</param>
        /// <param name="numero_cliente">Número de teléfono del cliente.</param>
        /// <param name="direccion_cliente">Dirección del cliente.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool crearCliente(string nombre_cliente, string apellido_cliente, string cedula_cliente, string numero_cliente, string direccion_cliente)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("n_cliente", SqlDbType.VarChar, nombre_cliente),
                new Parametros("a_cliente", SqlDbType.VarChar, apellido_cliente),
                new Parametros("c_cliente", SqlDbType.VarChar, cedula_cliente),
                new Parametros("num_cliente", SqlDbType.VarChar, numero_cliente),
                new Parametros("d_cliente", SqlDbType.VarChar, direccion_cliente)
            };

            return obj_bd.EjecutarSPNoQuery("SP_CREAR_CLIENTE", lista_parametros);
        }

        /// <summary>
        /// Elimina un cliente de la base de datos.
        /// </summary>
        /// <param name="clienteId">ID del cliente a eliminar.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool eliminarCliente(int clienteId)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("ID_CLIENTE", SqlDbType.Int, clienteId)
            };

            return obj_bd.EjecutarSPNoQuery("SP_ELIMINAR_CLIENTE", lista_parametros);
        }

        /// <summary>
        /// Actualiza los datos de un cliente en la base de datos.
        /// </summary>
        /// <param name="id_cliente">ID del cliente a actualizar.</param>
        /// <param name="nombre_cliente">Nuevo nombre del cliente.</param>
        /// <param name="apellido_cliente">Nuevo apellido del cliente.</param>
        /// <param name="cedula_cliente">Nueva cédula del cliente.</param>
        /// <param name="numero_cliente">Nuevo número de teléfono del cliente.</param>
        /// <param name="direccion_cliente">Nueva dirección del cliente.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool actualizarCliente(int id_cliente, string nombre_cliente, string apellido_cliente, string cedula_cliente, string numero_cliente, string direccion_cliente)
        {
            // Lista de parámetros a pasar al procedimiento almacenado
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("ID_CLIENTE", SqlDbType.Int, id_cliente),
                new Parametros("NOMBRE_CLIENTE", SqlDbType.VarChar, nombre_cliente),
                new Parametros("APELLIDO_CLIENTE", SqlDbType.VarChar, apellido_cliente),
                new Parametros("CEDULA_CLIENTE", SqlDbType.VarChar, cedula_cliente),
                new Parametros("NUMERO_CLIENTE", SqlDbType.VarChar, numero_cliente),
                new Parametros("DIRECCION_CLIENTE", SqlDbType.VarChar, direccion_cliente)
            };

            // Ejecutar el procedimiento almacenado y devolver el resultado
            return obj_bd.EjecutarSPNoQuery("SP_ACTUALIZAR_CLIENTE", lista_parametros);
        }


        //-------------------CELULAR

        /// <summary>
        /// Obtiene todos los celulares de un cliente específico.
        /// </summary>
        /// <param name="clienteId">ID del cliente.</param>
        /// <returns>DataTable con los celulares del cliente.</returns>
        public DataTable getAllCelular()
        {
            return obj_bd.EjecutarSPSelect("SP_GET_ALL_CELULAR");
        }

        /// <summary>
        /// Crea un nuevo celular para un cliente.
        /// </summary>
        /// <param name="modelo_c">Modelo del celular.</param>
        /// <param name="marca_c">Marca del celular.</param>
        /// <param name="detalle_c">Detalles del celular.</param>
        /// <param name="clienteId">ID del cliente al que pertenece el celular.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool crearEquipo(string modelo_c, string marca_c, string detalle_c, int clienteId)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("modelo", SqlDbType.VarChar, modelo_c),
                new Parametros("marca", SqlDbType.VarChar, marca_c),
                new Parametros("detalle", SqlDbType.VarChar, detalle_c),
                new Parametros("cliente_id", SqlDbType.Int, clienteId.ToString())
            };

            return obj_bd.EjecutarSPNoQuery("SP_CREAR_CELULAR", lista_parametros);
        }

        /// <summary>
        /// Elimina un celular por su ID.
        /// </summary>
        /// <param name="idEquipo">ID del celular a eliminar.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool eliminarEquipo(int idEquipo)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("ID_EQUIPO", SqlDbType.Int, idEquipo.ToString())
            };

            return obj_bd.EjecutarSPNoQuery("SP_ELIMINAR_CELULAR", lista_parametros);
        }

        /// <summary>
        /// Actualiza un celular en la base de datos.
        /// </summary>
        /// <param name="idEquipo">ID del celular a actualizar.</param>
        /// <param name="modelo_c">Nuevo modelo del celular.</param>
        /// <param name="marca_c">Nueva marca del celular.</param>
        /// <param name="detalle_c">Nuevos detalles del celular.</param>
        /// <param name="clienteId">Nuevo ID del cliente al que pertenece el celular.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool actualizarEquipo(int idEquipo, string modelo_c, string marca_c, string detalle_c, int clienteId)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("ID_EQUIPO", SqlDbType.Int, idEquipo.ToString()),
                new Parametros("MODELO_EQUIPO", SqlDbType.VarChar, modelo_c),
                new Parametros("MARCA_EQUIPO", SqlDbType.VarChar, marca_c),
                new Parametros("DETALLE_EQUIPO", SqlDbType.VarChar, detalle_c),
                new Parametros("CLIENTE_ID", SqlDbType.Int, clienteId.ToString())
            };

            return obj_bd.EjecutarSPNoQuery("SP_ACTUALIZAR_EQUIPO", lista_parametros);         
        }


        /// <summary>
        /// Obtiene todos los celulares de un cliente específico.
        /// </summary>
        /// <param name="clienteId">ID del cliente.</param>
        /// <returns>DataTable con los celulares del cliente.</returns>
        public DataTable getAllCelular(int clienteId)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("ID_CLIENTE", SqlDbType.Int, clienteId.ToString())
            };

            return obj_bd.EjecutarSPSelect("SP_GET_ALL_CELULAR", lista_parametros);
        }

        /// <summary>
        /// Obtiene los nombres de todos los clientes.
        /// </summary>
        /// <returns>DataTable con los nombres de los clientes.</returns>
        public DataTable GetClientNames()
        {
            return obj_bd.GetClienteNombres();
        }

        /// <summary>
        /// Obtiene los nombres de todos los técnicos.
        /// </summary>
        /// <returns>DataTable con los nombres de los técnicos.</returns>
        public DataTable GetTecnicosNames()
        {
            return obj_bd.GetTecnicosNombres();
        }

        /// <summary>
        /// Obtiene los celulares asociados a un cliente específico.
        /// </summary>
        /// <param name="clientId">ID del cliente.</param>
        /// <returns>DataTable con los celulares del cliente.</returns>
        public DataTable ObtieneCelularesClientes(int clientId)
        {
            return obj_bd.GetCelularClientes(clientId);
        }



        //---------------------TECNICOS

        /// <summary>
        /// Obtiene todos los técnicos registrados en la base de datos.
        /// </summary>
        /// <returns>DataTable con los datos de los técnicos.</returns>
        public DataTable getAllTecnicos()
        {
            return obj_bd.EjecutarSPSelect("SP_GET_ALL_TECNICO");
        }

        /// <summary>
        /// Crea un nuevo técnico en la base de datos.
        /// </summary>
        /// <param name="nombre_tecnico">Nombre del técnico.</param>
        /// <param name="apellido_tecnico">Apellido del técnico.</param>
        /// <param name="cedula_tecnico">Cédula del técnico.</param>
        /// <param name="numero_tecnico">Número de teléfono del técnico.</param>
        /// <param name="experiencia_tecnico">Experiencia del técnico.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool crearTecnico(string nombre_tecnico, string apellido_tecnico, string cedula_tecnico, string numero_tecnico, string experiencia_tecnico)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("n_tecnico", SqlDbType.VarChar, nombre_tecnico),
                new Parametros("a_tecnico", SqlDbType.VarChar, apellido_tecnico),
                new Parametros("c_tecnico", SqlDbType.VarChar, cedula_tecnico),
                new Parametros("num_tecnico", SqlDbType.VarChar, numero_tecnico),
                new Parametros("ex_tecnico", SqlDbType.VarChar, experiencia_tecnico)
            };

            return obj_bd.EjecutarSPNoQuery("SP_CREAR_TECNICO", lista_parametros);
        }

        /// <summary>
        /// Elimina un técnico de la base de datos.
        /// </summary>
        /// <param name="nombre_tecnico">Nombre del técnico.</param>
        /// <param name="apellido_tecnico">Apellido del técnico.</param>
        /// <param name="cedula_tecnico">Cédula del técnico.</param>
        /// <param name="numero_tecnico">Número de teléfono del técnico.</param>
        /// <param name="experiencia_tecnico">Experiencia del técnico.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool EliminarTecnico(string nombre_tecnico, string apellido_tecnico, string cedula_tecnico, string numero_tecnico, string experiencia_tecnico)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("n_tecnico", SqlDbType.VarChar, nombre_tecnico),
                new Parametros("a_tecnico", SqlDbType.VarChar, apellido_tecnico),
                new Parametros("c_tecnico", SqlDbType.VarChar, cedula_tecnico),
                new Parametros("num_tecnico", SqlDbType.VarChar, numero_tecnico),
                new Parametros("ex_tecnico", SqlDbType.VarChar, experiencia_tecnico)
            };

            return obj_bd.EjecutarSPNoQuery("SP_ELIMINAR_TECNICO", lista_parametros);
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
        public bool actualizarTecnico(int id_tecnico, string nombre_tecnico, string apellido_tecnico, string cedula_tecnico, string numero_tecnico, string experiencia_tecnico)
        {
            List<Parametros> lista_parametros = new List<Parametros>
    {
        new Parametros("ID_TECNICO", SqlDbType.Int, id_tecnico),
        new Parametros("NOMBRE_TECNICO", SqlDbType.VarChar, nombre_tecnico),
        new Parametros("APELLIDO_TECNICO", SqlDbType.VarChar, apellido_tecnico),
        new Parametros("CEDULA_TECNICO", SqlDbType.VarChar, cedula_tecnico),
        new Parametros("NUMERO_TECNICO", SqlDbType.VarChar, numero_tecnico),
        new Parametros("EXPERIENCIA_TECNICO", SqlDbType.VarChar, experiencia_tecnico)
    };

            return obj_bd.EjecutarSPNoQuery("SP_ACTUALIZAR_TECNICO", lista_parametros);
        }



        //----------------------USUARIO

        /// <summary>
        /// Valida el usuario y la contraseña.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="password">Contraseña del usuario.</param>
        /// <returns>True si el usuario es válido, false en caso contrario.</returns>
        public bool RevisarUsuario(string username, string password)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("Usuario_u", SqlDbType.VarChar, username),
                new Parametros("Contrasena_u", SqlDbType.VarChar, password)
            };

            return obj_bd.EjecutarAutentificarUsuario("SP_VALIDAR_USER", lista_parametros);
        }




        //-----------------------MANTENIMIENTO

        /// <summary>
        /// Crea un nuevo mantenimiento para un equipo.
        /// </summary>
        /// <param name="fechaMantenimiento">Fecha del mantenimiento.</param>
        /// <param name="descripcion">Descripción del mantenimiento.</param>
        /// <param name="precioMan">Precio del mantenimiento.</param>
        /// <param name="re_mante">Lista de repuestos usados.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool MantenimientoCreado(DateTime fechaMantenimiento, string descripcion, float precioMan, List<string> re_mante)
        {
            List<Parametros> lista_parametros = new List<Parametros>
            {
                new Parametros("FECHA_MANTENIMIENTO", SqlDbType.DateTime, fechaMantenimiento),
                new Parametros("DESCRIPCION", SqlDbType.VarChar, descripcion),
                new Parametros("PRECIO", SqlDbType.Float, precioMan),
                new Parametros("REPUESTOS", SqlDbType.VarChar, string.Join(",", re_mante))
            };

            return obj_bd.EjecutarSPNoQuery("SP_CREAR_MANTENIMIENTO", lista_parametros);
        }

        /// <summary>
        /// Obtiene todos los registros de la tabla MANTENIMIENTO desde la base de datos.
        /// </summary>
        /// <returns>Un objeto DataTable que contiene todos los registros de la tabla MANTENIMIENTO.</returns>
        public DataTable getAllMantenimientos()
        {
            // Ejecuta el procedimiento almacenado SP_GET_ALL_MANTENIMIENTO para obtener todos los registros de la tabla MANTENIMIENTO
            return obj_bd.EjecutarSPSelect("SP_GET_ALL_MANTENIMIENTO");
        }

        /// <summary>
        /// Elimina un mantenimiento específico de la base de datos.
        /// </summary>
        /// <param name="id_mantenimiento">El ID del mantenimiento que se desea eliminar.</param>
        /// <returns>True si la operación fue exitosa, false en caso contrario.</returns>
        public bool EliminarMantenimiento(int id_mantenimiento)
        {
            // Se crea una lista de parámetros que se enviarán al procedimiento almacenado
            List<Parametros> lista_parametros = new List<Parametros>
    {
        new Parametros("ID_MANTENIMIENTO", SqlDbType.Int, id_mantenimiento)  // El ID del mantenimiento a eliminar
    };

            // Ejecuta el procedimiento almacenado SP_ELIMINAR_MANTENIMIENTO, pasando los parámetros definidos
            return obj_bd.EjecutarSPNoQuery("SP_ELIMINAR_MANTENIMIENTO", lista_parametros);
        }


    }
}
