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
    public partial class AgregarModificarSalario : Form
    {
        public AgregarModificarSalario()
        {
            InitializeComponent();
        }
        Decimal valor;
        public string idArea;
        private void btnOk_Click(object sender, EventArgs e)
        {
            
                metodos metodos1 = new metodos();
                metodos1._IdS = Convert.ToInt32(idArea);
                metodos1._Salario = Convert.ToDecimal(txtSueldo.Text.Trim());
                metodos1.ModificartablaSalario();

                MessageBox.Show("Guardado correctamente");
                this.Close();
            
            
        }


        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                //  MessageBox.Show("Solo numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        //private bool FormatoMoneda()
        //{
        //    bool ok = true;
        

        //    if (!ExpresionesRegulares.RegEX.isDecimal(txtSueldo.Text.Trim()))
        //    {
        //        ok = false;
        //        //MessageBox.Show("El precio debe ser un numero valido, no se permiten letras ni caracteres que no sean numeros");
               
        //    }
        //    return ok ;
        //}

        private void AgregarModificarSalario_Load(object sender, EventArgs e)
        {

        }

        private void txtSueldo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                valor = Decimal.Parse(txtSueldo.Text);
               
            }
            catch(Exception)
            {
                
            }
        }
    }
}
