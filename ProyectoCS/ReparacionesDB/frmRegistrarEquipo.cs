using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario para el registro de equipos celulares.
    /// Permite agregar, actualizar, eliminar y visualizar equipos registrados.
    /// </summary>
    public partial class frmRegistrarEquipo : Form
    {
        private EquipoCelular e_celular;
        private Cliente n_cliente;
        private bool is_nuevo;

        /// <summary>
        /// Inicializa los componentes y las instancias de las clases necesarias.
        /// </summary>
        public frmRegistrarEquipo()
        {
            InitializeComponent();
            e_celular = new EquipoCelular();
            n_cliente = new Cliente();
            is_nuevo = false;

            CargarCombosBox();
        }

        /// <summary>
        /// Evento que se ejecuta cuando el formulario se carga.
        /// Desactiva ciertos botones e inicializa el DataGridView con los datos de equipos.
        /// </summary>
        private void frmRegistrarEquipo_Load(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Visible = false;
            btnActualizar.Enabled = false;

            LlenarGridEquipo();
        }

        /// <summary>
        /// Método para llenar el DataGridView con los datos de los equipos celulares.
        /// </summary>
        private void LlenarGridEquipo()
        {
            try
            {
                dgvEquipos.DataSource = e_celular.ObtenerTodosCelular();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos: " + ex.Message);
            }
        }

        /// <summary>
        /// Método para cargar los datos de los clientes en el ComboBox.
        /// </summary>
        private void CargarCombosBox()
        {
            DataTable clientes = n_cliente.ObtenerTodosClientes();
            clientes.Columns.Add("NombreCompleto", typeof(string), "NOMBRE_CLIENTE + ' ' + APELLIDO_CLIENTE");
            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "ID_Cliente";
            cmbCliente.SelectedIndex = -1;
        }

        /// <summary>
        /// Limpia los campos de texto y el ComboBox de cliente.
        /// </summary>
        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            txtModelo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtDetalles.Text = string.Empty;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de nuevo.
        /// Permite habilitar el formulario para registrar un nuevo equipo.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                is_nuevo = true;
                LimpiarCampos();

                btnGuardar.Visible = true;
                btnGuardar.Enabled = true;

                btnNuevo.Enabled = false;

                btnActualizar.Visible = false;
                btnActualizar.Enabled = false;

                cmbCliente.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Método para validar los campos del formulario.
        /// </summary>
        private bool ValidarCampos()
        {
            // Validación del cliente
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                cmbCliente.Focus();
                return false;
            }

            // Validación del modelo
            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Debe ingresar un modelo de equipo.");
                txtModelo.Focus();
                return false;
            }
            // Validación del modelo para asegurarse de que no contenga caracteres especiales
            // Ahora se permiten letras con tildes, números, y espacios
            if (!Regex.IsMatch(txtModelo.Text, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El modelo solo puede contener letras, números, tildes, ñ y espacios.");
                txtModelo.Focus();
                return false;
            }

            // Validación de la marca
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Debe ingresar una marca de equipo.");
                txtMarca.Focus();
                return false;
            }
            // Validación de la marca para asegurarse de que no contenga caracteres especiales
            // Ahora se permiten letras con tildes, números, y espacios
            if (!Regex.IsMatch(txtMarca.Text, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("La marca solo puede contener letras, números, tildes, ñ y espacios.");
                txtMarca.Focus();
                return false;
            }

            // Validación de detalles
            if (string.IsNullOrWhiteSpace(txtDetalles.Text))
            {
                MessageBox.Show("Debe ingresar detalles del equipo.");
                txtDetalles.Focus();
                return false;
            }

            return true; // Si todas las validaciones pasan, retornamos true
        }


        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón guardar.
        /// Valida los campos y, si son correctos, guarda un nuevo equipo o lo actualiza.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Llamar al método de validación
                if (!ValidarCampos()) return; // Si la validación falla, no proceder con el guardado

                if (is_nuevo)
                {
                    int clienteID = Convert.ToInt32(cmbCliente.SelectedValue);
                    EquipoCelular obj_cl = new EquipoCelular(0, txtModelo.Text, txtMarca.Text, txtDetalles.Text, clienteID);

                    if (e_celular.AgregarCelular(obj_cl))
                    {
                        MessageBox.Show("Registro insertado con éxito.");
                        LlenarGridEquipo();
                        LimpiarCampos();
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
        /// Evento que se ejecuta cuando se hace clic en el botón de actualización de equipo.
        /// Este método verifica si hay una fila seleccionada en el DataGridView, valida que los campos
        /// no estén vacíos y llama al método correspondiente en la capa de negocio para actualizar los datos
        /// del equipo seleccionado.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada en el DataGridView
                if (dgvEquipos.SelectedRows.Count > 0)
                {
                    // Obtener el ID del equipo seleccionado
                    int cequipoId = Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["ID_EQUIPO"].Value);

                    // Llamar al método de validación
                    if (!ValidarCampos()) return; // Si la validación falla, no proceder con la actualización

                    // Llamar al método de la capa de negocio para actualizar los datos del equipo
                    bool actualizado = e_celular.actualizarEquipo(cequipoId, txtModelo.Text, txtMarca.Text, txtDetalles.Text, Convert.ToInt32(cmbCliente.SelectedValue));

                    if (actualizado)
                    {
                        // Si la actualización es exitosa, mostrar un mensaje de éxito
                        MessageBox.Show("Equipo actualizado correctamente.");
                        LlenarGridEquipo();  // Recargar el grid de equipos
                        LimpiarCampos(); // Limpiar los campos del formulario

                        // Actualizar visibilidad de botones
                        btnGuardar.Enabled = false;
                        btnGuardar.Visible = true;
                        btnActualizar.Visible = false;
                        btnActualizar.Enabled = false;
                        btnEliminar.Enabled = false;
                    }
                    else
                    {
                        // Si la actualización falla, mostrar un mensaje de error
                        MessageBox.Show("No se pudo actualizar el equipo.");
                    }
                }
                else
                {
                    // Si no se seleccionó ningún equipo, mostrar un mensaje indicando que se debe seleccionar uno
                    MessageBox.Show("Por favor, selecciona un equipo para actualizar.");
                }
            }
            catch (Exception ex)
            {
                // En caso de un error en la ejecución, mostrar un mensaje con el detalle del error
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }


        /// <summary>
        /// Evento para cerrar el formulario cuando se hace clic en el botón regresar.
        /// </summary>
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en una celda del DataGridView.
        /// Carga los datos del equipo seleccionado en los campos de texto.
        /// </summary>
        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Asegurarse de que el índice de fila es válido
                {
                    cmbCliente.SelectedValue = Convert.ToInt32(dgvEquipos.Rows[e.RowIndex].Cells["CLIENTE_ID"].Value);
                    txtModelo.Text = dgvEquipos.Rows[e.RowIndex].Cells["MODELO_EQUIPO"].Value.ToString();
                    txtMarca.Text = dgvEquipos.Rows[e.RowIndex].Cells["MARCA_EQUIPO"].Value.ToString();
                    txtDetalles.Text = dgvEquipos.Rows[e.RowIndex].Cells["DETALLE_EQUIPO"].Value.ToString();

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
        /// Evento que se ejecuta al hacer clic en el botón eliminar.
        /// Elimina el equipo seleccionado del sistema tras confirmación del usuario.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEquipos.SelectedRows.Count > 0) // Verificar si hay una fila seleccionada
                {
                    DataGridViewRow filaSeleccionada = dgvEquipos.SelectedRows[0];
                    int idEquipo = Convert.ToInt32(filaSeleccionada.Cells["ID_EQUIPO"].Value);

                    DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este equipo?",
                                                                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        if (e_celular.EliminarCelular(idEquipo)) // Método que debes implementar
                        {
                            MessageBox.Show("Equipo eliminado correctamente.");
                            LlenarGridEquipo(); // Refrescar los datos
                            LimpiarCampos();
                            btnGuardar.Enabled = false;
                            btnGuardar.Visible = true;

                            btnActualizar.Visible = false;
                            btnActualizar.Enabled = false;
                            btnEliminar.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el equipo.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un equipo para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el equipo: " + ex.Message);
            }
        }

    }
}
