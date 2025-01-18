namespace CapaPresentacion
{
    partial class frmRegistrarMantenimiento
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
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            chklRepuestos = new CheckedListBox();
            label7 = new Label();
            FechaReparacion = new DateTimePicker();
            label6 = new Label();
            rtxtDiagnostico = new RichTextBox();
            cmbTecnico = new ComboBox();
            cmbCelular = new ComboBox();
            cmbCliente = new ComboBox();
            txtCodigo = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnCancelar = new Button();
            btnRegistrar = new Button();
            btnNuevo = new Button();
            label13 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(chklRepuestos);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(FechaReparacion);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(rtxtDiagnostico);
            groupBox1.Controls.Add(cmbTecnico);
            groupBox1.Controls.Add(cmbCelular);
            groupBox1.Controls.Add(cmbCliente);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 81);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1046, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(606, 249);
            label12.Name = "label12";
            label12.Size = new Size(33, 20);
            label12.TabIndex = 18;
            label12.Text = "$15";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(606, 225);
            label11.Name = "label11";
            label11.Size = new Size(33, 20);
            label11.TabIndex = 17;
            label11.Text = "$10";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(606, 202);
            label10.Name = "label10";
            label10.Size = new Size(33, 20);
            label10.TabIndex = 16;
            label10.Text = "$15";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(606, 181);
            label9.Name = "label9";
            label9.Size = new Size(33, 20);
            label9.TabIndex = 15;
            label9.Text = "$20";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(606, 159);
            label8.Name = "label8";
            label8.Size = new Size(33, 20);
            label8.TabIndex = 14;
            label8.Text = "$30";
            // 
            // chklRepuestos
            // 
            chklRepuestos.BackColor = Color.SteelBlue;
            chklRepuestos.FormattingEnabled = true;
            chklRepuestos.Items.AddRange(new object[] { "Pantalla.", "Batería", "Accesorios", "Botones", "Carcaza" });
            chklRepuestos.Location = new Point(656, 159);
            chklRepuestos.Margin = new Padding(3, 4, 3, 4);
            chklRepuestos.Name = "chklRepuestos";
            chklRepuestos.Size = new Size(248, 114);
            chklRepuestos.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(606, 130);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 12;
            label7.Text = "Repuestos:";
            // 
            // FechaReparacion
            // 
            FechaReparacion.Location = new Point(606, 78);
            FechaReparacion.Margin = new Padding(3, 4, 3, 4);
            FechaReparacion.Name = "FechaReparacion";
            FechaReparacion.Size = new Size(298, 27);
            FechaReparacion.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(606, 54);
            label6.Name = "label6";
            label6.Size = new Size(143, 20);
            label6.TabIndex = 10;
            label6.Text = "Fecha de reparacion";
            // 
            // rtxtDiagnostico
            // 
            rtxtDiagnostico.Location = new Point(30, 332);
            rtxtDiagnostico.Margin = new Padding(3, 4, 3, 4);
            rtxtDiagnostico.Name = "rtxtDiagnostico";
            rtxtDiagnostico.Size = new Size(874, 86);
            rtxtDiagnostico.TabIndex = 9;
            rtxtDiagnostico.Text = "";
            // 
            // cmbTecnico
            // 
            cmbTecnico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTecnico.FormattingEnabled = true;
            cmbTecnico.Location = new Point(93, 211);
            cmbTecnico.Margin = new Padding(3, 4, 3, 4);
            cmbTecnico.Name = "cmbTecnico";
            cmbTecnico.Size = new Size(352, 28);
            cmbTecnico.TabIndex = 8;
            // 
            // cmbCelular
            // 
            cmbCelular.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCelular.FormattingEnabled = true;
            cmbCelular.Location = new Point(93, 155);
            cmbCelular.Margin = new Padding(3, 4, 3, 4);
            cmbCelular.Name = "cmbCelular";
            cmbCelular.Size = new Size(352, 28);
            cmbCelular.TabIndex = 7;
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(93, 99);
            cmbCliente.Margin = new Padding(3, 4, 3, 4);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(352, 28);
            cmbCliente.TabIndex = 6;
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(93, 47);
            txtCodigo.Margin = new Padding(3, 4, 3, 4);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(114, 27);
            txtCodigo.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 291);
            label5.Name = "label5";
            label5.Size = new Size(230, 20);
            label5.TabIndex = 4;
            label5.Text = "Diagnostico y trabajos realizados";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 215);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 3;
            label4.Text = "Tecnico:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 159);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 2;
            label3.Text = "Celular:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 103);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 1;
            label2.Text = "Cliente:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 51);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 0;
            label1.Text = "Codigo:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnCancelar);
            groupBox2.Controls.Add(btnRegistrar);
            groupBox2.Controls.Add(btnNuevo);
            groupBox2.Dock = DockStyle.Bottom;
            groupBox2.Location = new Point(0, 524);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1002, 149);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(737, 55);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(213, 51);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(397, 55);
            btnRegistrar.Margin = new Padding(3, 4, 3, 4);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(213, 51);
            btnRegistrar.TabIndex = 1;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(46, 55);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(213, 51);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(20, 31);
            label13.Name = "label13";
            label13.Size = new Size(361, 46);
            label13.TabIndex = 19;
            label13.Text = "Ingresar Datos Cliente";
            // 
            // frmRegistrarMantenimiento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1002, 673);
            Controls.Add(label13);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmRegistrarMantenimiento";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmRegistrarMantenimiento";
            Load += frmRegistrarMantenimiento_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtCodigo;
        private Label label6;
        private RichTextBox rtxtDiagnostico;
        private ComboBox cmbTecnico;
        private ComboBox cmbCelular;
        private ComboBox cmbCliente;
        private CheckedListBox chklRepuestos;
        private Label label7;
        private DateTimePicker FechaReparacion;
        private GroupBox groupBox2;
        private Button btnCancelar;
        private Button btnRegistrar;
        private Button btnNuevo;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label13;
    }
}