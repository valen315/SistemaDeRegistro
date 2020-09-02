using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void Error(string msj)
        {
            lblError1.Text = ("    " + msj);
            lblError1.Visible = true;
        }
        private void Error2(string msj)
        {
            lblError2.Text = ("    " + msj);
            lblError2.Visible = true;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                string claves = Encrypt.GetSHA256(txtPass.Text.Trim());
                if (txtUser.Text != "Usuario")
                {
                    if (txtPass.Text != "Contraseña")
                    {
                        //string claves = Encrypt.GetSHA256(txtPass.Text.Trim());
                        using (Models.UsuariosEntities db = new Models.UsuariosEntities())
                        {
                            var fila = from DS in db.Clientes
                                       where DS.usuario.Equals(txtUser.Text)
                                       && DS.clave == claves
                                       where DS.Perfilid == 2
                                       select DS;
                            var fila2 = from DS in db.Clientes
                                        where DS.usuario == txtUser.Text
                                        && DS.clave == claves
                                        where DS.Perfilid == 3
                                        select DS;

                            if (fila.Count() > 0)
                            {
                                Contenedor principal = new Contenedor();
                                this.Hide();
                                this.Hide();
                                principal.Show();
                                principal.Menu2.Visible = false;
                            }
                            else if (fila2.Count() > 0)
                            {
                                Contenedor principal = new Contenedor();
                                this.Hide();
                                this.Hide();
                                principal.Show();
                                principal.Menu1.Visible = false;
                            }
                            else
                            {
                                Error2("Usuario o contraseña incorrecta");
                            }
                        }
                    }
                    else
                    {
                        Error2("Error campo contraseña vacia");
                    }
                }
                else Error("Error campo usuario vacia ");

            }
            catch (Exception )
            {
                MessageBox.Show("Usuario no registrado" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        private void IniciarSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            lblError1.Visible = false;

        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtUser.ForeColor = Color.Black;
                lineShape1.BorderColor = Color.Black;
                lblError2.Visible = false;
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
                lineShape1.BorderColor = Color.Black;
                lblError1.Visible = false;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.Gray;
                lineShape1.BorderColor = Color.DimGray;
            }

        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = true;
                txtPass.ForeColor = Color.Black;
                lineShape2.BorderColor = Color.Black;
                lblError2.Visible = false;
                //  txtContraseña.Font = new Font("Leelawadee UI",txtContraseña.Font.Size*0.9f); 
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.UseSystemPasswordChar = false;
                txtPass.ForeColor = Color.Gray;
                lineShape2.BorderColor = Color.DimGray;

            }
        }
        private void TxtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
               // MessageBox.Show("Solo numeros y/o letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
               // MessageBox.Show("Solo numeros y/o letras ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
        {

        }
    }
}
