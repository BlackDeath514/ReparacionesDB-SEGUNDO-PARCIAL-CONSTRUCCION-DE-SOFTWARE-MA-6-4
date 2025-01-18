namespace CapaPresentacion
{
    partial class frmRegistrarTecnico
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
            txtExpe = new TextBox();
            txtCelularT = new TextBox();
            txtCedulaT = new TextBox();
            txtApellTec = new TextBox();
            txtNombreTec = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            DGVtec = new DataGridView();
            groupBox3 = new GroupBox();
            btnActualizar = new Button();
            btnRegresar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVtec).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtExpe);
            groupBox1.Controls.Add(txtCelularT);
            groupBox1.Controls.Add(txtCedulaT);
            groupBox1.Controls.Add(txtApellTec);
            groupBox1.Controls.Add(txtNombreTec);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(14, 63);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(488, 425);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Tecnico";
            // 
            // txtExpe
            // 
            txtExpe.Location = new Point(187, 235);
            txtExpe.Margin = new Padding(3, 4, 3, 4);
            txtExpe.Name = "txtExpe";
            txtExpe.Size = new Size(276, 27);
            txtExpe.TabIndex = 9;
            // 
            // txtCelularT
            // 
            txtCelularT.Location = new Point(317, 180);
            txtCelularT.Margin = new Padding(3, 4, 3, 4);
            txtCelularT.Name = "txtCelularT";
            txtCelularT.Size = new Size(147, 27);
            txtCelularT.TabIndex = 8;
            // 
            // txtCedulaT
            // 
            txtCedulaT.Location = new Point(102, 180);
            txtCedulaT.Margin = new Padding(3, 4, 3, 4);
            txtCedulaT.Name = "txtCedulaT";
            txtCedulaT.Size = new Size(147, 27);
            txtCedulaT.TabIndex = 7;
            // 
            // txtApellTec
            // 
            txtApellTec.Location = new Point(102, 113);
            txtApellTec.Margin = new Padding(3, 4, 3, 4);
            txtApellTec.Name = "txtApellTec";
            txtApellTec.Size = new Size(362, 27);
            txtApellTec.TabIndex = 6;
            // 
            // txtNombreTec
            // 
            txtNombreTec.Location = new Point(102, 56);
            txtNombreTec.Margin = new Padding(3, 4, 3, 4);
            txtNombreTec.Name = "txtNombreTec";
            txtNombreTec.Size = new Size(362, 27);
            txtNombreTec.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 239);
            label6.Name = "label6";
            label6.Size = new Size(164, 20);
            label6.TabIndex = 4;
            label6.Text = "Tiempo de experiencia:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(256, 184);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 3;
            label5.Text = "Celular:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 184);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 2;
            label4.Text = "Cedula:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 117);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 1;
            label3.Text = "Apellido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 60);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 0;
            label2.Text = "Nombre:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DGVtec);
            groupBox2.Location = new Point(509, 63);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(481, 425);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // DGVtec
            // 
            DGVtec.AllowUserToAddRows = false;
            DGVtec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVtec.Location = new Point(6, 18);
            DGVtec.Margin = new Padding(3, 4, 3, 4);
            DGVtec.Name = "DGVtec";
            DGVtec.RowHeadersWidth = 51;
            DGVtec.Size = new Size(469, 399);
            DGVtec.TabIndex = 0;
            DGVtec.CellClick += DGVtec_CellClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnActualizar);
            groupBox3.Controls.Add(btnRegresar);
            groupBox3.Controls.Add(btnEliminar);
            groupBox3.Controls.Add(btnGuardar);
            groupBox3.Controls.Add(btnNuevo);
            groupBox3.Dock = DockStyle.Bottom;
            groupBox3.Location = new Point(0, 496);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(1002, 177);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(280, 71);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(213, 51);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(760, 71);
            btnRegresar.Margin = new Padding(3, 4, 3, 4);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(213, 51);
            btnRegresar.TabIndex = 3;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegreso_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(526, 71);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(213, 51);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(280, 71);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(213, 51);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(38, 71);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(213, 51);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(321, 32);
            label1.TabIndex = 3;
            label1.Text = "Ingresar Datos Tecnico";
            // 
            // frmRegistrarTecnico
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1002, 673);
            Controls.Add(label1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmRegistrarTecnico";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmRegistrarTecnico";
            Load += frmRegistrarTecnico_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVtec).EndInit();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DataGridView DGVtec;
        private Button btnNuevo;
        private Button btnRegresar;
        private Button btnEliminar;
        private Button btnGuardar;
        private TextBox txtExpe;
        private TextBox txtCelularT;
        private TextBox txtCedulaT;
        private TextBox txtApellTec;
        private TextBox txtNombreTec;
        private Button btnActualizar;
    }
}