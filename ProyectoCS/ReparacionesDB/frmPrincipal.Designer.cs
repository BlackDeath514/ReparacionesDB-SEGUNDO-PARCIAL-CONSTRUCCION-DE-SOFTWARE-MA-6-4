namespace CapaPresentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnExportar = new Button();
            btnBorrar = new Button();
            dgvMantenimientos = new DataGridView();
            lblIntegrante = new Label();
            groupBox2 = new GroupBox();
            btnRegitrarCliente = new Button();
            btnREquipo = new Button();
            btnMantenimiento = new Button();
            btnRegistrarTecnico = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(btnExportar);
            groupBox1.Controls.Add(btnBorrar);
            groupBox1.Controls.Add(dgvMantenimientos);
            groupBox1.Controls.Add(lblIntegrante);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(877, 505);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnExportar
            // 
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 9F);
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(704, 67);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(48, 28);
            btnExportar.TabIndex = 6;
            btnExportar.Text = "💾";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.Font = new Font("Segoe UI", 9F);
            btnBorrar.ForeColor = Color.White;
            btnBorrar.Location = new Point(757, 67);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(102, 28);
            btnBorrar.TabIndex = 5;
            btnBorrar.Text = "🗑️ Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // dgvMantenimientos
            // 
            dgvMantenimientos.AllowUserToAddRows = false;
            dgvMantenimientos.BackgroundColor = Color.White;
            dgvMantenimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMantenimientos.Location = new Point(237, 101);
            dgvMantenimientos.Name = "dgvMantenimientos";
            dgvMantenimientos.RowHeadersWidth = 51;
            dgvMantenimientos.Size = new Size(621, 394);
            dgvMantenimientos.TabIndex = 1;
            // 
            // lblIntegrante
            // 
            lblIntegrante.AutoSize = true;
            lblIntegrante.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIntegrante.ForeColor = Color.SlateBlue;
            lblIntegrante.Location = new Point(237, 18);
            lblIntegrante.Name = "lblIntegrante";
            lblIntegrante.Size = new Size(371, 47);
            lblIntegrante.TabIndex = 0;
            lblIntegrante.Text = "[🛠️] ReparacionesDB";
            lblIntegrante.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.SteelBlue;
            groupBox2.Controls.Add(btnRegitrarCliente);
            groupBox2.Controls.Add(btnREquipo);
            groupBox2.Controls.Add(btnMantenimiento);
            groupBox2.Controls.Add(btnRegistrarTecnico);
            groupBox2.Dock = DockStyle.Left;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(221, 505);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // btnRegitrarCliente
            // 
            btnRegitrarCliente.FlatStyle = FlatStyle.Flat;
            btnRegitrarCliente.Font = new Font("Segoe UI", 9F);
            btnRegitrarCliente.ForeColor = Color.White;
            btnRegitrarCliente.Location = new Point(18, 38);
            btnRegitrarCliente.Name = "btnRegitrarCliente";
            btnRegitrarCliente.Size = new Size(186, 38);
            btnRegitrarCliente.TabIndex = 4;
            btnRegitrarCliente.Text = "👤  Registrar Cliente";
            btnRegitrarCliente.TextAlign = ContentAlignment.MiddleLeft;
            btnRegitrarCliente.UseVisualStyleBackColor = true;
            btnRegitrarCliente.Click += btnRegistrarCliente_Click;
            // 
            // btnREquipo
            // 
            btnREquipo.FlatStyle = FlatStyle.Flat;
            btnREquipo.Font = new Font("Segoe UI", 9F);
            btnREquipo.ForeColor = Color.White;
            btnREquipo.Location = new Point(18, 92);
            btnREquipo.Name = "btnREquipo";
            btnREquipo.Size = new Size(186, 38);
            btnREquipo.TabIndex = 3;
            btnREquipo.Text = "🖥️  Registrar Equipo";
            btnREquipo.TextAlign = ContentAlignment.MiddleLeft;
            btnREquipo.UseVisualStyleBackColor = true;
            btnREquipo.Click += btnREquipo_Click;
            // 
            // btnMantenimiento
            // 
            btnMantenimiento.FlatStyle = FlatStyle.Flat;
            btnMantenimiento.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMantenimiento.ForeColor = Color.White;
            btnMantenimiento.Location = new Point(18, 202);
            btnMantenimiento.Name = "btnMantenimiento";
            btnMantenimiento.Size = new Size(186, 38);
            btnMantenimiento.TabIndex = 2;
            btnMantenimiento.Text = "🔧  Registrar Mantenimiento";
            btnMantenimiento.TextAlign = ContentAlignment.MiddleLeft;
            btnMantenimiento.UseVisualStyleBackColor = true;
            btnMantenimiento.Click += btnMantenimiento_Click;
            // 
            // btnRegistrarTecnico
            // 
            btnRegistrarTecnico.FlatStyle = FlatStyle.Flat;
            btnRegistrarTecnico.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistrarTecnico.ForeColor = Color.White;
            btnRegistrarTecnico.Location = new Point(18, 147);
            btnRegistrarTecnico.Name = "btnRegistrarTecnico";
            btnRegistrarTecnico.Size = new Size(186, 38);
            btnRegistrarTecnico.TabIndex = 1;
            btnRegistrarTecnico.Text = "🛠️  Registrar Tecnico";
            btnRegistrarTecnico.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistrarTecnico.UseVisualStyleBackColor = true;
            btnRegistrarTecnico.Click += btnRegistrarTecnico_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 505);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPrincipal";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimientos).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnMantenimiento;
        private Button btnRegistrarTecnico;
        private Label lblIntegrante;
        private Button btnREquipo;
        private Button btnRegitrarCliente;
        private DataGridView dgvMantenimientos;
        private Button btnBorrar;
        private Button btnExportar;
    }
}