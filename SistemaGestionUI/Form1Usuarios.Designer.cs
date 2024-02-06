namespace SistemaGestionUI
{
    partial class Form1Usuarios
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            label1 = new Label();
            btnAltaUsuario = new Button();
            txtNombre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtApellido = new TextBox();
            label4 = new Label();
            txtNombreUsuario = new TextBox();
            label5 = new Label();
            txtContraseña = new TextBox();
            label6 = new Label();
            txtMail = new TextBox();
            label7 = new Label();
            textBox1 = new TextBox();
            label8 = new Label();
            textBox2 = new TextBox();
            label9 = new Label();
            textBox3 = new TextBox();
            label10 = new Label();
            textBox4 = new TextBox();
            label11 = new Label();
            textBox5 = new TextBox();
            btnModificarUsuario = new Button();
            txtIdUsuarioAModificar = new NumericUpDown();
            label12 = new Label();
            label13 = new Label();
            txtIdUsuarioABorrar = new NumericUpDown();
            btnBorrarUsuario = new Button();
            btnActualizarListadoUsuarios = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIdUsuarioAModificar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIdUsuarioABorrar).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(242, 247);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(747, 293);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(490, 222);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 1;
            label1.Text = "Listado de Usuarios";
            // 
            // btnAltaUsuario
            // 
            btnAltaUsuario.Location = new Point(605, 52);
            btnAltaUsuario.Name = "btnAltaUsuario";
            btnAltaUsuario.Size = new Size(92, 23);
            btnAltaUsuario.TabIndex = 2;
            btnAltaUsuario.Text = "Alta Usuario";
            btnAltaUsuario.UseVisualStyleBackColor = true;
            btnAltaUsuario.Click += btnAltaUsuario_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(57, 53);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 35);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 35);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 6;
            label3.Text = "Apellido";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(163, 53);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(269, 35);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 8;
            label4.Text = "Nombre Usuario";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(269, 53);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(100, 23);
            txtNombreUsuario.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(375, 35);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 10;
            label5.Text = "Contraseña";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(375, 53);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(100, 23);
            txtContraseña.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(481, 35);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 12;
            label6.Text = "Mail";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(481, 53);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(100, 23);
            txtMail.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(631, 101);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 23;
            label7.Text = "Mail";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(631, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(525, 101);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 21;
            label8.Text = "Contraseña";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(525, 119);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(419, 101);
            label9.Name = "label9";
            label9.Size = new Size(94, 15);
            label9.TabIndex = 19;
            label9.Text = "Nombre Usuario";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(419, 119);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(313, 101);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 17;
            label10.Text = "Apellido";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(313, 119);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 16;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(207, 101);
            label11.Name = "label11";
            label11.Size = new Size(51, 15);
            label11.TabIndex = 15;
            label11.Text = "Nombre";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(207, 119);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 14;
            // 
            // btnModificarUsuario
            // 
            btnModificarUsuario.Location = new Point(755, 118);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Size = new Size(126, 23);
            btnModificarUsuario.TabIndex = 13;
            btnModificarUsuario.Text = "Modificar Usuario";
            btnModificarUsuario.UseVisualStyleBackColor = true;
            // 
            // txtIdUsuarioAModificar
            // 
            txtIdUsuarioAModificar.Location = new Point(57, 120);
            txtIdUsuarioAModificar.Name = "txtIdUsuarioAModificar";
            txtIdUsuarioAModificar.Size = new Size(120, 23);
            txtIdUsuarioAModificar.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(57, 102);
            label12.Name = "label12";
            label12.Size = new Size(123, 15);
            label12.TabIndex = 25;
            label12.Text = "Id Usuario a Modificar";
            label12.Click += label12_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(57, 161);
            label13.Name = "label13";
            label13.Size = new Size(104, 15);
            label13.TabIndex = 27;
            label13.Text = "Id Usuario a Borrar";
            // 
            // txtIdUsuarioABorrar
            // 
            txtIdUsuarioABorrar.Location = new Point(57, 179);
            txtIdUsuarioABorrar.Name = "txtIdUsuarioABorrar";
            txtIdUsuarioABorrar.Size = new Size(120, 23);
            txtIdUsuarioABorrar.TabIndex = 26;
            // 
            // btnBorrarUsuario
            // 
            btnBorrarUsuario.Location = new Point(197, 177);
            btnBorrarUsuario.Name = "btnBorrarUsuario";
            btnBorrarUsuario.Size = new Size(92, 23);
            btnBorrarUsuario.TabIndex = 28;
            btnBorrarUsuario.Text = "Borrar Usuario";
            btnBorrarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnActualizarListadoUsuarios
            // 
            btnActualizarListadoUsuarios.Location = new Point(605, 217);
            btnActualizarListadoUsuarios.Name = "btnActualizarListadoUsuarios";
            btnActualizarListadoUsuarios.Size = new Size(116, 24);
            btnActualizarListadoUsuarios.TabIndex = 29;
            btnActualizarListadoUsuarios.Text = "Actualizar Listado";
            btnActualizarListadoUsuarios.UseVisualStyleBackColor = true;
            btnActualizarListadoUsuarios.Click += button1_Click;
            // 
            // Form1Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 563);
            Controls.Add(btnActualizarListadoUsuarios);
            Controls.Add(btnBorrarUsuario);
            Controls.Add(label13);
            Controls.Add(txtIdUsuarioABorrar);
            Controls.Add(label12);
            Controls.Add(txtIdUsuarioAModificar);
            Controls.Add(label7);
            Controls.Add(textBox1);
            Controls.Add(label8);
            Controls.Add(textBox2);
            Controls.Add(label9);
            Controls.Add(textBox3);
            Controls.Add(label10);
            Controls.Add(textBox4);
            Controls.Add(label11);
            Controls.Add(textBox5);
            Controls.Add(btnModificarUsuario);
            Controls.Add(label6);
            Controls.Add(txtMail);
            Controls.Add(label5);
            Controls.Add(txtContraseña);
            Controls.Add(label4);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label3);
            Controls.Add(txtApellido);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(btnAltaUsuario);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1Usuarios";
            Text = "Form1 Usuarios";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIdUsuarioAModificar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIdUsuarioABorrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button btnAltaUsuario;
        private TextBox txtNombre;
        private Label label2;
        private Label label3;
        private TextBox txtApellido;
        private Label label4;
        private TextBox txtNombreUsuario;
        private Label label5;
        private TextBox txtContraseña;
        private Label label6;
        private TextBox txtMail;
        private Label label7;
        private TextBox textBox1;
        private Label label8;
        private TextBox textBox2;
        private Label label9;
        private TextBox textBox3;
        private Label label10;
        private TextBox textBox4;
        private Label label11;
        private TextBox textBox5;
        private Button btnModificarUsuario;
        private NumericUpDown txtIdUsuarioAModificar;
        private Label label12;
        private Label label13;
        private NumericUpDown txtIdUsuarioABorrar;
        private Button btnBorrarUsuario;
        private Button btnActualizarListadoUsuarios;
    }
}