using CapaNegocio;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario para la gestión de clientes, incluyendo registro, edición, eliminación y validaciones.
    /// </summary>
    public partial class frmRegistrarCliente : Form
    {
        /// <summary>
        /// Instancia de la clase Cliente para interactuar con la capa de negocio.
        /// </summary>
        private Cliente n_cliente;

        /// <summary>
        /// Bandera para indicar si se está creando un nuevo cliente.
        /// </summary>
        private bool is_nuevo;

        /// <summary>
        /// Constructor del formulario. Inicializa los componentes y las variables necesarias.
        /// </summary>
        public frmRegistrarCliente()
        {
            InitializeComponent();
            n_cliente = new Cliente();
            is_nuevo = false;
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario. Desactiva botones y llena el DataGridView.
        /// </summary>
        private void frmRegistrarCliente_Load(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Visible = false;
            btnActualizar.Enabled = false;
            LlenarGridCliente();
        }

        /// <summary>
        /// Llena el DataGridView con la lista de clientes obtenida desde la base de datos.
        /// </summary>
        private void LlenarGridCliente()
        {
            try
            {
                dgvClientes.DataSource = n_cliente.ObtenerTodosClientes();
                dgvClientes.Columns["ID_CLIENTE"].Visible = false; // Oculta el ID del cliente.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos: " + ex.Message);
            }
        }

        /// <summary>
        /// Limpia los campos del formulario para prepararlos para un nuevo registro.
        /// </summary>
        private void SetearCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtCelular.Clear();
            rtxtDireccion.Clear();
        }

        /// <summary>
        /// Evento para habilitar el formulario y permitir el registro de un nuevo cliente.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                is_nuevo = true;
                SetearCampos();
                btnGuardar.Visible = true;
                btnGuardar.Enabled = true;
                btnNuevo.Enabled = false;
                btnActualizar.Visible = false;
                btnActualizar.Enabled = false;
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento para guardar los datos del cliente, ya sea un registro nuevo o una edición.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                {
                    return; // Si las validaciones fallan, se detiene el proceso.
                }

                if (is_nuevo)
                {
                    Cliente obj_cl = new Cliente(0, txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCelular.Text, rtxtDireccion.Text);

                    if (n_cliente.InsertarCliente(obj_cl))
                    {
                        MessageBox.Show("Registro insertado con éxito.");
                        LlenarGridCliente();
                        SetearCampos();
                        btnGuardar.Enabled = false;
                        btnNuevo.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar el registro.");
                    }
                }

                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento para cerrar el formulario.
        /// </summary>
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Evento que carga los datos del cliente seleccionado en el DataGridView hacia los campos del formulario.
        /// </summary>
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Asegurarse de que el índice de fila es válido
                {
                    txtNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["NOMBRE_CLIENTE"].Value.ToString();
                    txtApellido.Text = dgvClientes.Rows[e.RowIndex].Cells["APELLIDO_CLIENTE"].Value.ToString();
                    txtCedula.Text = dgvClientes.Rows[e.RowIndex].Cells["CEDULA_CLIENTE"].Value.ToString();
                    txtCelular.Text = dgvClientes.Rows[e.RowIndex].Cells["NUMERO_CLIENTE"].Value.ToString();
                    rtxtDireccion.Text = dgvClientes.Rows[e.RowIndex].Cells["DIRECCION_CLIENTE"].Value.ToString();

                    btnNuevo.Enabled = true;

                    btnGuardar.Enabled = false;
                    btnGuardar.Visible = false;

                    btnActualizar.Visible = true;
                    btnActualizar.Enabled = true;

                    btnEliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }
        }

        /// <summary>
        /// Evento para eliminar el cliente seleccionado en el DataGridView.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ID_CLIENTE"].Value);

                    if (n_cliente.EliminarClientes(clienteId))
                    {
                        MessageBox.Show("Eliminado correctamente.");
                        LlenarGridCliente();
                        SetearCampos();

                        btnGuardar.Enabled = false;
                        btnGuardar.Visible = true;

                        btnActualizar.Visible = false;
                        btnActualizar.Enabled = false;
                        btnEliminar.Enabled=false;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Valida los datos ingresados en los campos del formulario.
        /// </summary>
        /// <returns>True si todos los datos son válidos; False en caso contrario.</returns>
        private bool ValidarCampos()
        {
            // Verificar si algún campo está vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtCelular.Text) ||
                string.IsNullOrWhiteSpace(rtxtDireccion.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return false;
            }

            // Validación para nombre y apellido (permitir letras, espacios y caracteres especiales como tildes y ñ)
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$") ||
                !Regex.IsMatch(txtApellido.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre y apellido solo deben contener letras y caracteres especiales.");
                return false;
            }

            // Validación de cédula (debe tener 10 dígitos)
            if (!Regex.IsMatch(txtCedula.Text, @"^\d{10}$"))
            {
                MessageBox.Show("La cédula debe contener exactamente 10 dígitos.");
                return false;
            }

            // Validación de celular (debe tener 10 dígitos)
            if (!Regex.IsMatch(txtCelular.Text, @"^\d{10}$"))
            {
                MessageBox.Show("El número de celular debe contener exactamente 10 dígitos.");
                return false;
            }

            // Validación de dirección (debe tener más de 5 caracteres)
            if (rtxtDireccion.Text.Length < 5)
            {
                MessageBox.Show("La dirección debe ser más específica.");
                return false;
            }

            return true;
        }


        /// <summary>
        /// Evento para restringir el ingreso de solo números en el campo de cédula.
        /// </summary>
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.");
            }
        }

        /// <summary>
        /// Evento para restringir el ingreso de solo números en el campo de celular.
        /// </summary>
        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.");
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de actualizar.
        /// Este método valida que se haya seleccionado un cliente y que los campos de entrada no estén vacíos. 
        /// Luego, llama al método de la capa de datos para actualizar los datos del cliente en la base de datos.
        /// Si la operación es exitosa, recarga el grid de clientes y limpia los campos del formulario.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento (el botón de actualización).</param>
        /// <param name="e">Argumentos del evento (información sobre el evento de clic).</param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada en el DataGridView
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    // Obtener el ID del cliente seleccionado
                    int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ID_CLIENTE"].Value);

                    // Verificar que los campos del formulario no estén vacíos antes de proceder
                    if (!ValidarCampos())
                    {
                        return; // Si alguna validación falla, se detiene el proceso
                    }

                    // Llamar al método de la capa de datos para actualizar los datos del cliente
                    bool actualizado = n_cliente.actualizarCliente(clienteId, txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCelular.Text, rtxtDireccion.Text);

                    if (actualizado)
                    {
                        // Si la actualización es exitosa, mostrar un mensaje de éxito
                        MessageBox.Show("Cliente actualizado correctamente.");
                        LlenarGridCliente();  // Recargar el grid de clientes
                        SetearCampos();  // Limpiar los campos del formulario
                        btnGuardar.Enabled = false;
                        btnGuardar.Visible = true;

                        btnActualizar.Visible = false;
                        btnActualizar.Enabled = false;
                        btnEliminar.Enabled = false;
                    }
                    else
                    {
                        // Si la actualización falla, mostrar un mensaje de error
                        MessageBox.Show("No se pudo actualizar el cliente.");
                    }
                }
                else
                {
                    // Si no se seleccionó ningún cliente, mostrar un mensaje indicando que se debe seleccionar uno
                    MessageBox.Show("Por favor, selecciona un cliente para actualizar.");
                }
            }
            catch (Exception ex)
            {
                // En caso de un error en la ejecución, mostrar un mensaje con el detalle del error
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

    }
}
