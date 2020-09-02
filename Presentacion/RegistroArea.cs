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
    public partial class RegistroArea : Form
    {
        public RegistroArea()
        {
            InitializeComponent();
        }
        private int n = 0;
        public void Actualizar()
        {
            metodos tabla = new metodos();
           dataGridView1.DataSource = tabla.ListarTablaArea2();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
            try
            {
                if (n != -1)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name =="EDITAR")
                    {

                       NuevaArea Area = new NuevaArea();
                       Area.operacion = "Editar";
                       Area.txtNombreArea.Text= dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                       Area.idArea=dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                       Area.ShowDialog();
                          Actualizar();

                    }
                    #region BotonEliminar
                    else if (dataGridView1.Columns[e.ColumnIndex].Name == "ELIMINAR")
                    {
                        try
                        {
                            if (MessageBox.Show("Desea eliminar el Area?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                metodos tabla = new metodos();

                                tabla._Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                                tabla.EliminarArea();

                               // MessageBox.Show("Se elimino correctamente");
                            }
                            Actualizar();
                        }
                        catch
                        {
                            
                           
                            MessageBox.Show("Area asignada a un Usuario","",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void RegistroArea_Load(object sender, EventArgs e)
        {
            Actualizar();
            Botones();
            dataGridView1.Columns["ID"].Visible = false;
          

        }
        public void Botones()
        {
            DataGridViewImageColumn imgEditar = new DataGridViewImageColumn();
            imgEditar.HeaderText = "EDITAR";
            imgEditar.Name = "EDITAR";
            imgEditar.Image = Presentacion.Properties.Resources.editar;
            imgEditar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imgEditar);



            DataGridViewImageColumn imgEliminar = new DataGridViewImageColumn();
            imgEliminar.HeaderText = "ELIMINAR";
            imgEliminar.Name = "ELIMINAR";
            imgEliminar.Image = Presentacion.Properties.Resources.eliminar;
            imgEliminar.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dataGridView1.Columns.Add(imgEliminar);
        }

        private void btnNuevaArea_Click(object sender, EventArgs e)
        {

            NuevaArea area = new NuevaArea();
            area.operacion="Agregar";

            area.ShowDialog();

            Actualizar();
        }
    }
}
