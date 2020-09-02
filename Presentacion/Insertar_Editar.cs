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
    public partial class Insertar_Editar : Form
    {
        
        public Insertar_Editar()
        {
            InitializeComponent();
           
            cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPerfil.DropDownStyle = ComboBoxStyle.DropDownList;

        }
       
        //TablaAreaPerfil tabla = new TablaAreaPerfil();
        
        public string Operacion = "";
        public string idCliente;
        private void btnOk_Click(object sender, EventArgs e)
        {
            BorrarCampos();
            if (ValidarCampo())
            {
                try
                {
                    if (Operacion == "Agregar")
                    {
                        metodos tabla = new metodos();
                        tabla._Nombre = txtNombre.Text.Trim();
                        tabla._Apellido = txtApellido.Text.Trim();
                        tabla._Mail = txtMail.Text.Trim();
                        tabla._Areaid = Convert.ToInt32(cmbArea.SelectedValue);
                        tabla._FechaDeNacimiento1 = dateTimePicker1.Value;
                        tabla._Perfilid = Convert.ToInt32(cmbPerfil.SelectedValue);

                        tabla.InsertarRegistro();

                        MessageBox.Show("Guardado correctamente");
                        this.Close();

                    }
                    else if (Operacion == "Editar")
                    {
                        metodos tabla = new metodos();
                   
                        tabla._idC = Convert.ToInt32(idCliente);
                        tabla._Nombre = txtNombre.Text.Trim();
                        tabla._Apellido = txtApellido.Text.Trim();
                        tabla._Mail = txtMail.Text.Trim();
                        tabla._Areaid = Convert.ToInt32(cmbArea.SelectedValue);
                        tabla._FechaDeNacimiento1 = dateTimePicker1.Value;
                        tabla._Perfilid = Convert.ToInt32(cmbPerfil.SelectedValue);

                        tabla.EditarRegistro();

                        MessageBox.Show("Editado correctamente");
                        this.Close();
                    }
                    RegistroDeUsuarios data = new RegistroDeUsuarios();
                    data.MostrarTabla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" error al guardar " + ex);
                }
            }
        }
        public void ListaAreas()
        { 
            metodos tabla = new metodos();
            cmbArea.DataSource = tabla.ListaArea();
            cmbArea.DisplayMember = "DescripcionA";
            cmbArea.ValueMember = "id";
        }
        public void ListaPerfiles()
        {
            metodos tabla = new metodos();
            cmbPerfil.DataSource = tabla.ListaPerfiles();
            cmbPerfil.DisplayMember = "DescripcionP";
            cmbPerfil.ValueMember = "id";
        }

        private void Insertar_Editar_Load(object sender, EventArgs e)
        {
            if (Operacion == "Agregar")
            {
                cmbArea.Text = "";
                cmbPerfil.Text = "";
                
            }
        }
        private bool ValidarCampo()
        {
            bool ok = true;
            string email = txtMail.Text;
            bool verificarMail = email.Contains("@") && email.Contains(".com");

            if (txtNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Ingresar nombre");
            }
           
            if (txtApellido.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtApellido, "Ingresar Apellido");
            }
            if(verificarMail == true)
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(txtMail, "Mail invalido");
            }
            if (txtMail.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtMail, "Ingresar mail");
            }
            
            if (cmbArea.Text=="Seleccionar")
            {
                ok = false;
                errorProvider1.SetError(cmbArea, "Seleccionar Area");
            }
            if (dateTimePicker1.Text == "21/7/2020")
            {
                ok = false;
                errorProvider1.SetError(dateTimePicker1, "Seleccionar Fecha");
            }
            if (cmbPerfil.Text == "Seleccionar")
            {
                ok = false;
                errorProvider1.SetError(cmbPerfil, "Seleccionar Perfil");
            }
            return ok && verificarMail;
           
        }
        private void  BorrarCampos()
        {
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtMail, "");
            errorProvider1.SetError(cmbArea, "");
            errorProvider1.SetError(dateTimePicker1, "");
            errorProvider1.SetError(cmbPerfil, "");
        }


        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 129) || (e.KeyChar >= 131 && e.KeyChar <= 161) || (e.KeyChar >= 170 && e.KeyChar <= 191))
            {
                
               // MessageBox.Show("Solo letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;

            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 129) || (e.KeyChar >= 131 && e.KeyChar <= 161) || (e.KeyChar >= 170 && e.KeyChar <= 191))
            {
                //MessageBox.Show("Solo letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar > 46 && e.KeyChar <= 47)|| (e.KeyChar >= 58 && e.KeyChar <= 63) || (e.KeyChar >= 91 && e.KeyChar <=94 )|| (e.KeyChar >95 && e.KeyChar <= 96)|| (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                //MessageBox.Show("Solo numeros, letras, @, (.)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            //string nombre;
            //    if(!string.Equals(txtNombre.Text,out nombre)
            //{
            
            //}
        }
    }
}
