using CapaNegocio;
using System;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario principal del sistema.
    /// Permite registrar clientes, técnicos, mantenimientos y equipos.
    /// Además, incluye funcionalidades para visualizar y gestionar mantenimientos.
    /// </summary>
    public partial class frmPrincipal : Form
    {
        // Formulario secundarios
        private frmRegistrarCliente reg_cliente;
        private frmRegistrarTecnico reg_tecnico;
        private frmRegistrarMantenimiento reg_mantenimiento;
        private frmRegistrarEquipo eq_registro;

        // Instancia de la capa de negocios
        private Mantenimiento n_mantenimiento;

        /// <summary>
        /// Constructor por defecto del formulario principal.
        /// Inicializa los componentes y carga los mantenimientos existentes.
        /// </summary>
        public frmPrincipal()
        {
            n_mantenimiento = new Mantenimiento();
            InitializeComponent();
            LlenarMantenimientos();
        }

        /// <summary>
        /// Maneja el evento de clic del botón para registrar un cliente.
        /// Abre el formulario correspondiente.
        /// </summary>
        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            reg_cliente = new frmRegistrarCliente();
            reg_cliente.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            reg_cliente.ShowDialog();
        }

        /// <summary>
        /// Maneja el evento de clic del botón para registrar un técnico.
        /// Abre el formulario correspondiente.
        /// </summary>
        private void btnRegistrarTecnico_Click(object sender, EventArgs e)
        {
            reg_tecnico = new frmRegistrarTecnico();
            reg_tecnico.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            reg_tecnico.ShowDialog();
        }

        /// <summary>
        /// Maneja el evento de clic del botón para registrar un mantenimiento.
        /// Abre el formulario correspondiente.
        /// </summary>
        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            reg_mantenimiento = new frmRegistrarMantenimiento(this);
            reg_mantenimiento.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            reg_mantenimiento.ShowDialog();
        }

        /// <summary>
        /// Maneja el evento de clic del botón para registrar un equipo.
        /// Abre el formulario correspondiente.
        /// </summary>
        private void btnREquipo_Click(object sender, EventArgs e)
        {
            eq_registro = new frmRegistrarEquipo();
            eq_registro.FormClosed += (s, args) => { this.Show(); };
            this.Hide();
            eq_registro.ShowDialog();
        }

        /// <summary>
        /// Carga y muestra los mantenimientos existentes en el DataGridView.
        /// </summary>
        public void LlenarMantenimientos()
        {
            try
            {
                dgvMantenimientos.DataSource = n_mantenimiento.ObtenerMantenimientos();
                dgvMantenimientos.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón para eliminar un mantenimiento.
        /// Elimina el mantenimiento seleccionado del DataGridView y la base de datos.
        /// </summary>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMantenimientos.SelectedRows.Count > 0) // Verifica si hay una fila seleccionada
                {
                    int mantenimientoId = Convert.ToInt32(dgvMantenimientos.SelectedRows[0].Cells["ID_MANTENIMIENTO"].Value); // Obtiene el ID del mantenimiento
                    if (n_mantenimiento.EliminarMantenimientos(mantenimientoId))
                    {
                        LlenarMantenimientos();
                        MessageBox.Show("Eliminado Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un Mantenimiento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón para exportar los mantenimientos a un archivo CSV.
        /// </summary>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                    saveFileDialog.Title = "Guardar datos como CSV";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportarDatosCSV(saveFileDialog.FileName);
                        MessageBox.Show("Datos exportados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Exporta los datos del DataGridView a un archivo CSV en la ubicación especificada.
        /// </summary>
        /// <param name="filePath">Ruta del archivo donde se guardarán los datos.</param>
        private void ExportarDatosCSV(string filePath)
        {
            var sb = new StringBuilder();

            // Exportar encabezados
            foreach (DataGridViewColumn column in dgvMantenimientos.Columns)
            {
                sb.Append(column.HeaderText + ",");
            }
            sb.AppendLine();

            // Exportar datos de las filas
            foreach (DataGridViewRow row in dgvMantenimientos.Rows)
            {
                if (!row.IsNewRow) // Ignorar la fila de nueva fila
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        sb.Append(cell.Value?.ToString().Replace(",", ";") + ","); // Reemplazar comas para evitar problemas en CSV
                    }
                    sb.AppendLine();
                }
            }

            // Guardar el contenido en el archivo CSV
            System.IO.File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
}
