using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
using System.Windows.Forms;

namespace AccesoDatos 
{
    public class metodos
    {
        private ConexionToSql conexion = new ConexionToSql();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader LeerFilas;

        #region  Atributtos Registro

        private int idC;
        private string Nombre;
        private string Apellido;
        private string Mail;
        private int Areaid;
        private System.DateTime FechaDeNacimiento;
        private int Perfilid;

        public int _idC { get => idC; set => idC = value; }
        public string _Nombre{ get => Nombre; set => Nombre = value; }
        public string _Apellido { get => Apellido; set => Apellido = value; }
        public string _Mail { get => Mail; set => Mail = value; }
        public int _Areaid { get => Areaid; set => Areaid = value; }
        public  DateTime _FechaDeNacimiento1 { get => FechaDeNacimiento; set => FechaDeNacimiento = value; }
        public int _Perfilid { get => Perfilid; set => Perfilid = value; }
       
        #endregion

        #region ATRIBUTOS AREA
        private int id;
        private string descripcionA;

        public int _Id { get => id; set => id = value; }
        public string _DescripcionA { get => descripcionA; set => descripcionA = value; }
     
        #endregion
        #region ATRIBUTO SALARIO
        private int idS;
        private Decimal Salario ;

        public int _IdS { get => idS; set => idS = value; }
        public decimal _Salario { get => Salario; set => Salario = value; }
        #endregion



        #region REGISTRO USUARIO
        public DataTable ListaArea()
        {
            DataTable Tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ListaArea";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable ListaPerfiles()
        {
            DataTable Tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ListaPerfiles";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable MostrarTabla()
        {
            DataTable Tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarTablaClientes2";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;
        } 
        public void InsertarRegistro() 
         {
            try
            {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_InsertarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", Nombre);
                comando.Parameters.AddWithValue("@Apellido",Apellido);
                comando.Parameters.AddWithValue("@Mail",Mail);
                comando.Parameters.AddWithValue("@Areaid", Areaid);
                comando.Parameters.AddWithValue("@FechaDeNacimiento", FechaDeNacimiento);
                comando.Parameters.AddWithValue("@Perfilid", Perfilid);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear(); //limpiar los parametros 
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                comando.Connection = conexion.CerrarConexion();
            }
            
         }
        public void EditarRegistro()
        {
            comando.Connection=conexion.AbrirConexion();
            comando.CommandText = "Modificartabla";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idC",idC);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Apellido",Apellido);
            comando.Parameters.AddWithValue("@Mail",Mail);
            comando.Parameters.AddWithValue("@Areaid",Areaid);
            comando.Parameters.AddWithValue("@FechaDeNacimiento",FechaDeNacimiento);
            comando.Parameters.AddWithValue("@Perfilid",Perfilid);
            comando.ExecuteNonQuery();
            comando.Connection = conexion.CerrarConexion();
        }
        public void EliminarRegistro()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarRegistro";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("idC",idC);
            comando.ExecuteNonQuery(); 
            comando.Connection = conexion.CerrarConexion();
        }
        public void Filtro(DataGridView data, string buscar)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "buscarnombre";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Buscar", buscar);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
                data.DataSource = dt;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
        #endregion


        #region METODOS TABLA AREA 
        public void EliminarArea()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarArea";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("id",id);
            comando.ExecuteNonQuery();
            comando.Connection = conexion.CerrarConexion();
        }
        public void EditarArea()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarArea";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@DescripcionA", descripcionA);
            comando.ExecuteNonQuery();
            comando.Connection = conexion.CerrarConexion();
        }
        public void InsertarArea()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "InsertarArea";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@DescripcionA", descripcionA);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear(); //limpiar los parametros 
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                comando.Connection = conexion.CerrarConexion();
            }
        }

      

         public DataTable ListarTablaArea2()
        {
            DataTable Tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ListarTablaArea2";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;
        }

        #endregion

        #region METODOS TABLA SALARIO
        public DataTable MostarTablaSalario()
        {
            DataTable Tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarTablaSalario";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;
        }
        public void ModificartablaSalario()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ModificartablaSalario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idC", idS);
            comando.Parameters.AddWithValue("@Salario",Salario);
            comando.ExecuteNonQuery();
            comando.Connection = conexion.CerrarConexion();
        }
        public void BuscarEnTablaSalario(DataGridView data, string buscar)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "buscarTablaSalario";

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Buscar", buscar);
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
                data.DataSource = dt;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }

        }
        #endregion
        
    }
}

