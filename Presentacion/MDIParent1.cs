using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Contenedor : Form
    {
        private int childFormNumber = 0;

        public Contenedor()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void administracionDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.administracionDeUsuarioToolStripMenuItem.Enabled = false;
            ////this.registroDeAreasToolStripMenuItem.Enabled = false;
            //Presentacion.RegistroDeUsuarios usuario = new Presentacion.RegistroDeUsuarios(ref this.administracionDeUsuarioToolStripMenuItem);
            // usuario.MdiParent = this;
            // usuario.Show();
            
            #region no deja abrir el mismo formulario ,pero si otros
            bool IsOpen = false;
      
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Administracion de Usuario" || f.Text == "Registro de Areas")
                {
                    IsOpen = true;
                    f.Focus();
                    break;

                }
            }
            if (IsOpen == false)
            {
                RegistroDeUsuarios usuario = new RegistroDeUsuarios();
                usuario.MdiParent = this;
                usuario.Show();
                
            }

            

            #endregion
            #region deja de ser visible el 0tro formulario 
            //foreach (Form frm in this.MdiChildren)
            //{
            //    if (!frm.Focused)
            //    {
            //        frm.Visible = false;
            //        frm.Dispose();
            //    }
            //}

            #endregion
        }

        private void registroDeAreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            
            foreach (Form f in Application.OpenForms)
            {
           
                    if (f.Text == "Registro de Areas"|| f.Text == "Administracion de Usuario")
                    {
                        IsOpen = true;
                        f.Focus();
                        break;
                    
                    }
                
            }
            if(IsOpen==false)
            {
                RegistroArea area = new RegistroArea();
                area.MdiParent = this;
                area.Show();
            }
            
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (Form frm in this.MdiChildren)
            //{
            //    if(!frm.Focused)
            //    {
            //        frm.Visible = false;
            //        frm.Dispose();
            //    }
            //}
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Nuevo Usuario")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                Insertar_Editar insertar_ = new Insertar_Editar();
                insertar_.MdiParent = this;
                insertar_.Operacion = "Agregar";
                insertar_.ListaAreas();
                insertar_.ListaPerfiles();
                insertar_.Show();
                RegistroDeUsuarios registroDeUsuarios = new RegistroDeUsuarios();
                registroDeUsuarios.MostrarTabla();
               
            }
           
        }

        private void registroDeSalarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            bool IsOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Registro de Sueldo")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (IsOpen == false)
            {
                RegistroSueldo sueldo = new RegistroSueldo();
                sueldo.MdiParent = this;
                sueldo.Show();
            }
        }

        private void Contenedor_Load(object sender, EventArgs e)
        {
           
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {

                if (f.Text == "Registro de Areas" || f.Text == "Administracion de Usuario"|| f.Text== "Nuevo Usuario")
                {
                    IsOpen = true;
                    f.Focus();
                    MessageBox.Show("Cierre la ventana abierta ");
                    break;

                }

            }
            if (IsOpen == false)
            {
                this.Hide();

                IniciarSesion principal = new IniciarSesion();
                principal.FormClosed += (s, args) => this.Close();
                principal.Show();
            }

            //this.Hide();

            //IniciarSesion principal = new IniciarSesion();
            //principal.FormClosed += (s, args) => this.Close();
            //principal.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void cerrarSesionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
     
            bool IsOpen = false;

            foreach (Form f in Application.OpenForms)
            {

                if (f.Text == "Registro de Sueldo")
                {
                    IsOpen = true;
                    f.Focus();
                    MessageBox.Show("Cierre la ventana abierta ");
                    break;

                }

            }
            if (IsOpen == false)
            {
                this.Hide();

                IniciarSesion principal = new IniciarSesion();
                principal.FormClosed += (s, args) => this.Close();
                principal.Show();
            }
           
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void Contenedor_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
            IniciarSesion principal = new IniciarSesion();
            principal.Close();
        }
    }
}
