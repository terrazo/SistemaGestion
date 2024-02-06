using SistemaGestionEntities;
using SistemaGestionBussiness;


namespace SistemaGestionUI
{
    public partial class Form1Usuarios : Form
    {
        public Form1Usuarios()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            List<Usuario> usuarios = UsuarioBussiness.GetUsuarios();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = usuarios;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            UsuarioBussiness.CreateUsuario(txtNombre.Text, txtApellido.Text, txtNombreUsuario.Text, txtContraseña.Text, txtMail.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = UsuarioBussiness.GetUsuarios();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = usuarios;
        }
    }
}