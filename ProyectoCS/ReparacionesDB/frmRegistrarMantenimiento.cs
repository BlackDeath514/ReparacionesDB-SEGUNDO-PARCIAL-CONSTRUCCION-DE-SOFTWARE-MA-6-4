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
    public partial class frmRegistrarMantenimiento : Form
    {
        private Mantenimiento m_celular;
        private frmPrincipal form;

        public frmRegistrarMantenimiento(frmPrincipal ventana)
        {
            form = ventana;
            
            InitializeComponent();
            m_celular = new Mantenimiento();
            chRepuesto();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            form.LlenarMantenimientos();
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnRegistrar.Enabled = true;
            btnCancelar.Enabled = true;
            rtxtDiagnostico.Focus();
            Limpiar();
        }

        private void Limpiar()
        {
            rtxtDiagnostico.Text = string.Empty;
            cmbCelular.SelectedIndex = -1;
            cmbCliente.SelectedIndex = -1;
            cmbTecnico.SelectedIndex = -1;
            FechaReparacion.Value = DateTime.Now.Date;
            for (int i = 0; i < chklRepuestos.Items.Count; i++)
            {
                chklRepuestos.SetItemChecked(i, false);
            }

        }

        private void frmRegistrarMantenimiento_Load(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = false;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = true;
            CargarClientes();
            CargarTecnicos();
            
            if (cmbCliente.Items.Count > 0)
            {
                cmbCliente.SelectedIndex = 0; // Selecciona el primer cliente por defecto
                int clientId = (int)cmbCliente.SelectedValue;
                LoadCellphoneDetails(clientId);
            }
            Limpiar();
        }

        private void CargarTecnicos()
        {
            DataTable dt = m_celular.ObtenerTecnico();
            cmbTecnico.DisplayMember = "NOMBRE_TECNICO";
            cmbTecnico.ValueMember = "ID_TECNICO";
            cmbTecnico.DataSource = dt;
        }
        private void CargarClientes()
        {
            DataTable dt = m_celular.ObtenerClientes();
            cmbCliente.DisplayMember = "NOMBRE_CLIENTE";
            cmbCliente.ValueMember = "ID_CLIENTE";
            cmbCliente.DataSource = dt;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue != null)
            {
                int clientId = (int)cmbCliente.SelectedValue;
                LoadCellphoneDetails(clientId);
            }
        }

        private void LoadCellphoneDetails(int clientId)
        {
            //limpia los datos
            cmbCelular.DataSource = null;
            DataTable dt = m_celular.GetCellphoneDetailsByClientId(clientId);

            cmbCelular.DisplayMember = "DESCRIPCION_CELL";
            cmbCelular.ValueMember = "ID_EQUIPO";
            cmbCelular.DataSource = dt;
        }

        private void chRepuesto()
        {
                // Limpiar 
                chklRepuestos.Items.Clear();

                chklRepuestos.Items.Add(Repuesto.Pantalla, false);
                chklRepuestos.Items.Add(Repuesto.Bateria, false);
                chklRepuestos.Items.Add(Repuesto.Accesorios, false);
                chklRepuestos.Items.Add(Repuesto.Botones, false);
                chklRepuestos.Items.Add(Repuesto.Carcaza, false);
        }

        private void MostrarInformacionMantenimiento(Mantenimiento mantenimiento)
        {
            // Obtener los nombres de cliente y técnico
            string nombreCliente = ((DataRowView)cmbCliente.SelectedItem)["NOMBRE_CLIENTE"].ToString();
            string nombreTecnico = ((DataRowView)cmbTecnico.SelectedItem)["NOMBRE_TECNICO"].ToString();

            // Obtener los detalles del celular
            string descripcionCelular = ((DataRowView)cmbCelular.SelectedItem)["DESCRIPCION_CELL"].ToString();

            // Obtener los repuestos utilizados y sus precios
            StringBuilder repuestosUtilizados = new StringBuilder();
            foreach (var repuesto in mantenimiento.ReMante)
            {
                repuestosUtilizados.AppendLine($"{repuesto}: {(int)repuesto} USD");
            }

            // Calcular el total del mantenimiento
            float totalMantenimiento = mantenimiento.CostoTotal();

            // Crear el mensaje
            string mensaje = $"Nombre del Cliente: {nombreCliente}\n" +
                             $"Nombre del Técnico: {nombreTecnico}\n" +
                             $"Marca y Modelo del Celular: {descripcionCelular}\n" +
                             $"Fecha del Mantenimiento: {mantenimiento.FechaHoy.ToShortDateString()}\n" +
                             $"Detalle del Trabajo Realizado: {mantenimiento.ManDescrip}\n" +
                             $"Repuestos Utilizados:\n{repuestosUtilizados}\n" +
                             $"Total del Cobro por el Mantenimiento: {totalMantenimiento} USD";

            // Mostrar el mensaje en un MessageBox
            MessageBox.Show(mensaje, "Información del Mantenimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FechaReparacion.Text) || string.IsNullOrWhiteSpace(rtxtDiagnostico.Text))
            {
                MessageBox.Show("Tiene que llenar todos los campos.");
                return;
            }


            foreach (var item in chklRepuestos.CheckedItems)
            {
                if (item is Repuesto rSeleccionado)
                {
                    m_celular.ReMante.Add(rSeleccionado);
                }
            }

            m_celular.FechaHoy = FechaReparacion.Value;
            m_celular.ManDescrip = rtxtDiagnostico.Text;
            m_celular.PrecioRep = m_celular.ReMante.Sum(r => (int)r);

            bool result = m_celular.GuardarMante(m_celular);

            if (result)
            {
                MessageBox.Show("Mantenimiento guardado exitosamente");
                MostrarInformacionMantenimiento(m_celular);
            }
            else
            {
                MessageBox.Show("Error al guardar el mantenimiento");
            }
            btnRegistrar.Enabled = false;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = true;

        }
    }
}
