using System;
using System.Windows.Forms;
using AccesoDatos;

namespace Presentacion
{
    public partial class RegistroSueldo : Form
    {
        public RegistroSueldo()
        {
            InitializeComponent();
        }
        private int n = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
            try
            {
                if (n != -1)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Agregar")
                    {
                        AgregarModificarSalario agregar = new AgregarModificarSalario();
                        agregar.txtNombre.Text= dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                        agregar.txtApellido.Text= dataGridView1.CurrentRow.Cells["APELLIDO"].Value.ToString();
                        agregar.txtMail.Text= dataGridView1.CurrentRow.Cells["MAIL"].Value.ToString();
                        agregar.cmbArea.Text= dataGridView1.CurrentRow.Cells["AREA"].Value.ToString();
                        agregar.txtSueldo.Text= dataGridView1.CurrentRow.Cells["SUELDO"].Value.ToString();
                        agregar.idArea= dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                        agregar.ShowDialog();
                        MostrarTablaSalario();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("error"+ex );
            }
        }
        private void RegistroSueldo_Load(object sender, EventArgs e)
        {
            MostrarTablaSalario();
            Botones();
            dataGridView1.Columns[0].Visible = false;
          
        }
        public void MostrarTablaSalario()
        {
            metodos tabla = new metodos();
            dataGridView1.DataSource = tabla.MostarTablaSalario();
        }
        public void Botones()
        {
            DataGridViewImageColumn imgEditar = new DataGridViewImageColumn();
            imgEditar.HeaderText = "AGREGAR-MODIFICAR SUELDO";
            imgEditar.Name = "Agregar";
            imgEditar.Image = Presentacion.Properties.Resources.editar;
            imgEditar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imgEditar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var aux = new metodos();
            aux.BuscarEnTablaSalario(dataGridView1, this.textBox1.Text.Trim());
        }
    }
}
