using System;
using System.Windows.Forms;
using AccesoDatos;

namespace Presentacion
{
    public partial class NuevaArea : Form
    {
        public NuevaArea()
        {
            InitializeComponent();
        }
        public string operacion = "";
        public string idArea;

        private void NuevaArea_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (operacion == "Agregar")
                {
                    metodos tabla = new metodos();
                    tabla._DescripcionA = txtNombreArea.Text.Trim();
                    tabla.InsertarArea();

                    MessageBox.Show("Guardado correctamente");
                    this.Close();
                }
                else if (operacion == "Editar")
                {
                    metodos tabla = new metodos();
                    
                    tabla._Id = Convert.ToInt32(idArea);
                    tabla._DescripcionA = txtNombreArea.Text.Trim();
                    tabla.EditarArea();

                    MessageBox.Show("Editado correctamente");
                    this.Close();
                }
                RegistroArea registroArea = new RegistroArea();
                registroArea.Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);

            }
        }

        private void txtNombreArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 129) || (e.KeyChar >= 131 && e.KeyChar <= 161) || (e.KeyChar >= 170 && e.KeyChar <= 191))
            {
                //MessageBox.Show("Solo letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;

            }
        }
    }
}
