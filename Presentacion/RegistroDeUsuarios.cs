using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;



namespace Presentacion
{
    public partial class RegistroDeUsuarios : Form
    {
        //public System.Windows.Forms.ToolStripMenuItem xPar;
        // public RegistroDeUsuarios(ref System.Windows.Forms.ToolStripMenuItem xValor)
        public RegistroDeUsuarios()
        {
            //xPar = xValor;
            InitializeComponent();
        }
        private int n = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarTabla();
            Botones();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[5].HeaderText = "FECHA DE NACIMIENTO";
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 70;
            dataGridView1.Columns[8].Width = 70;

        }

        public void MostrarTabla()
        {
            metodos tabla = new metodos();
            dataGridView1.DataSource = tabla.MostrarTabla();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Insertar_Editar FormAgregar_Editar = new Insertar_Editar();
            FormAgregar_Editar.Operacion = "Agregar";
            FormAgregar_Editar.ListaAreas();
            FormAgregar_Editar.ListaPerfiles();
            FormAgregar_Editar.ShowDialog();
            MostrarTabla();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarTabla();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    metodos tabla = new metodos();
            //    tabla.EditarRegistro();

            //    if (dataGridView1.SelectedRows.Count > 0)
            //    {
            //        Insertar_Editar FormAgregar_Editar = new Insertar_Editar();
            //        FormAgregar_Editar.Operacion = "Editar";
            //        FormAgregar_Editar.ListaAreas();
            //        FormAgregar_Editar.ListaPerfiles();
            //        FormAgregar_Editar.cmbArea.SelectedValue.GetType();
            //        FormAgregar_Editar.cmbPerfil.SelectedValue.GetType();
            //        FormAgregar_Editar.txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //        FormAgregar_Editar.txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //        FormAgregar_Editar.txtMail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //        FormAgregar_Editar.cmbArea.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //        FormAgregar_Editar.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //        FormAgregar_Editar.cmbPerfil.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //        FormAgregar_Editar.idCliente = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            //        FormAgregar_Editar.ShowDialog();
            //        MostrarTabla("");
            //    }

            //    else
            //    {
            //        MessageBox.Show("debe seleccionar una fila");
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("error al editar");
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
            try
            {
                if (n != -1)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Editar")
                    {

                        Insertar_Editar FormAgregar_Editar = new Insertar_Editar();
                        FormAgregar_Editar.Operacion = "Editar";
                        
                        FormAgregar_Editar.ListaAreas();
                        FormAgregar_Editar.ListaPerfiles();
                        
                        FormAgregar_Editar.idCliente = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                        FormAgregar_Editar.txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                        FormAgregar_Editar.txtApellido.Text = dataGridView1.CurrentRow.Cells["APELLIDO"].Value.ToString();
                        FormAgregar_Editar.txtMail.Text = dataGridView1.CurrentRow.Cells["MAIL"].Value.ToString();

                        FormAgregar_Editar.cmbArea.Text = dataGridView1.CurrentRow.Cells["AREA"].Value.ToString();
                        FormAgregar_Editar.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["FECHA_DE_NACIMIENTO"].Value.ToString();
                        FormAgregar_Editar.cmbPerfil.Text = dataGridView1.CurrentRow.Cells["PERFIL"].Value.ToString();

                        FormAgregar_Editar.ShowDialog();

                        MostrarTabla();
                    }
                    else if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
                    {

                        if (MessageBox.Show("Desea eliminar el registro?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            metodos tabla = new metodos();

                            tabla._idC = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                            tabla.EliminarRegistro();
                            MessageBox.Show("se elimino correctamente");
                        }
                        MostrarTabla();
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("error" );
            }
        }

        public void Botones()
        {
            //DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
            //btnModificar.HeaderText = "Editar";
            //btnModificar.Name = "Editar";
            //btnModificar.Text = "Editar";
            //btnModificar.UseColumnTextForButtonValue = true;
            //dataGridView1.Columns.Add(btnModificar);

            //DataGridViewButtonColumn btnEliminar2 = new DataGridViewButtonColumn();
            //btnEliminar2.HeaderText = "Eliminar";
            //btnEliminar2.Name = "Eliminar";
            //btnEliminar2.Text = "Eliminar";
            //btnEliminar2.UseColumnTextForButtonValue = true;
            //dataGridView1.Columns.Add(btnEliminar2);

            DataGridViewImageColumn imgEditar = new DataGridViewImageColumn();
            imgEditar.HeaderText = "Editar";
            imgEditar.Name = "Editar";
            imgEditar.Image = Presentacion.Properties.Resources.editar;
            //imgEditar.Image = Image.FromFile(@"C:\Users\pc\Downloads\Actual\Inicio\Resources\editar.png");
            imgEditar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgEditar.Description = "Zoomed";
            dataGridView1.Columns.Add(imgEditar);

            DataGridViewImageColumn imgEliminar = new DataGridViewImageColumn();
            imgEliminar.HeaderText = "Eliminar";
            imgEliminar.Name = "Eliminar";
            imgEliminar.Image = Presentacion.Properties.Resources.eliminar;
            //imgEliminar.Image = Image.FromFile(@"C:\Users\pc\Downloads\Actual\Inicio\Resources\eliminar.png");
            imgEliminar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgEliminar.Description = "Zoomed";
            dataGridView1.Columns.Add(imgEliminar);
        }

        private void RegistroDeUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            //xPar.Enabled = true;
            //Contenedor contenedor = new Contenedor();
            //contenedor.registroDeAreasToolStripMenuItem.Enabled = true;
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            var aux = new metodos();
            aux.Filtro(dataGridView1, this.txtbuscar.Text.Trim());
        }
    }
}
