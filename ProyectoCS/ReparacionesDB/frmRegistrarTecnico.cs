using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario para registrar y gestionar técnicos en el sistema.
    /// Permite realizar operaciones como insertar, actualizar, eliminar y visualizar técnicos.
    /// </summary>
    public partial class frmRegistrarTecnico : Form
    {
        private Tecnico n_tec;  // Instancia de la clase Tecnico
        private bool is_nuv;    // Bandera para indicar si el registro es nuevo

        /// <summary>
        /// Constructor de la clase que inicializa el formulario y crea una nueva instancia de la clase Tecnico.
        /// </summary>
        public frmRegistrarTecnico()
        {
            InitializeComponent();
            n_tec = new Tecnico();
            is_nuv = false;
        }

        /// <summary>
        /// Evento que se ejecuta cuando el formulario se carga. Deshabilita ciertos botones y llena el DataGridView con los técnicos.
        /// </summary>
        private void frmRegistrarTecnico_Load(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Visible = false;
            btnActualizar.Enabled = false;
            LlenarGridTEC();
        }

        /// <summary>
        /// Llenar el DataGridView con los datos de los técnicos obtenidos de la capa de negocio.
        /// </summary>
        private void LlenarGridTEC()
        {
            try
            {
                DGVtec.DataSource = n_tec.ObtenerTecnicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos " + ex.Message);
            }
        }

        /// <summary>
        /// Limpia todos los campos de texto del formulario.
        /// </summary>
        private void SetearCampos()
        {
            txtNombreTec.Text = string.Empty;
            txtApellTec.Text = string.Empty;
            txtCedulaT.Text = string.Empty;
            txtCelularT.Text = string.Empty;
            txtExpe.Text = string.Empty;
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en el botón Nuevo. Prepara el formulario para registrar un nuevo técnico.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                is_nuv = true;
                SetearCampos();

                btnGuardar.Visible = true;
                btnGuardar.Enabled = true;
                btnNuevo.Enabled = false;
                btnActualizar.Visible = false;
                btnActualizar.Enabled = false;

                txtNombreTec.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro -> " + ex.Message);
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en el botón Guardar. Guarda un nuevo técnico en la base de datos.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                if (is_nuv)
                {
                    Tecnico obj_cl = new Tecnico(0, txtNombreTec.Text, txtApellTec.Text,
                                                  txtCedulaT.Text, txtCelularT.Text, txtExpe.Text);
                    if (n_tec.InsertarTec(obj_cl))
                    {
                        MessageBox.Show("Registro Insertado con Exito");
                        LlenarGridTEC();
                        btnGuardar.Enabled = false;
                        btnNuevo.Enabled = true;
                    }
                    else
                        MessageBox.Show("No se pudo insertar el registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error -> " + ex.Message);
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en el botón Actualizar. Actualiza los datos de un técnico existente.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                int id_tecnico = Convert.ToInt32(DGVtec.Rows[DGVtec.CurrentRow.Index].Cells["ID_TECNICO"].Value);
                string nombre_tecnico = txtNombreTec.Text;
                string apellido_tecnico = txtApellTec.Text;
                string cedula_tecnico = txtCedulaT.Text;
                string numero_tecnico = txtCelularT.Text;
                string experiencia_tecnico = txtExpe.Text;

                bool resultado = n_tec.ActualizarTec(id_tecnico, nombre_tecnico, apellido_tecnico, cedula_tecnico, numero_tecnico, experiencia_tecnico);

                if (resultado)
                {
                    MessageBox.Show("Técnico actualizado correctamente.");
                    LlenarGridTEC();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el técnico.");
                }

                btnGuardar.Enabled = false;
                btnGuardar.Visible = true;

                btnActualizar.Visible = false;
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                SetearCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el técnico: " + ex.Message);
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en el botón Eliminar. Elimina un técnico de la base de datos.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Tecnico obj_cl = new Tecnico(0, txtNombreTec.Text, txtApellTec.Text
                        , txtCedulaT.Text, txtCelularT.Text, txtExpe.Text);
                n_tec.EliminarTec(obj_cl);
                LlenarGridTEC();
                SetearCampos();
                btnGuardar.Enabled = false;
                btnGuardar.Visible = true;

                btnActualizar.Visible = false;
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                txtNombreTec.Focus();
                MessageBox.Show("Eliminado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en el botón Regreso. Cierra el formulario actual.
        /// </summary>
        private void btnRegreso_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en una celda del DataGridView. Rellena los campos con los datos del técnico seleccionado.
        /// </summary>
        private void DGVtec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNombreTec.Text = DGVtec.Rows[e.RowIndex].Cells["NOMBRE_TECNICO"].Value.ToString();
                txtApellTec.Text = DGVtec.Rows[e.RowIndex].Cells["APELLIDO_TECNICO"].Value.ToString();
                txtCedulaT.Text = DGVtec.Rows[e.RowIndex].Cells["CEDULA_TECNICO"].Value.ToString();
                txtCelularT.Text = DGVtec.Rows[e.RowIndex].Cells["NUMERO_TECNICO"].Value.ToString();
                txtExpe.Text = DGVtec.Rows[e.RowIndex].Cells["EXPERIENCIA_TECNICO"].Value.ToString();

                btnNuevo.Enabled = true;

                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

                btnActualizar.Visible = true;
                btnActualizar.Enabled = true;

                btnEliminar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error " + ex.Message);
            }
        }

        /// <summary>
        /// Valida que todos los campos estén correctamente llenados y que los datos tengan el formato adecuado.
        /// </summary>
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreTec.Text) || string.IsNullOrWhiteSpace(txtApellTec.Text) ||
                string.IsNullOrWhiteSpace(txtCedulaT.Text) || string.IsNullOrWhiteSpace(txtCelularT.Text) ||
                string.IsNullOrWhiteSpace(txtExpe.Text))
            {
                MessageBox.Show("Debe llenar todos los campos.");
                return false;
            }

            if (!txtCelularT.Text.All(char.IsDigit))
            {
                MessageBox.Show("El número de celular debe contener solo números.");
                return false;
            }

            if (!txtCedulaT.Text.All(char.IsDigit))
            {
                MessageBox.Show("La cédula debe contener solo números.");
                return false;
            }

            return true;
        }
    }
}
