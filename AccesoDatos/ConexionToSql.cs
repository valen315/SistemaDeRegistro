using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AccesoDatos
{
    public class ConexionToSql
    {
            static private string CadenaConexion = ConfigurationManager.ConnectionStrings["conectarBD"].ConnectionString;
            private SqlConnection Conexion = new SqlConnection(CadenaConexion);
            public SqlConnection AbrirConexion()
            {
                if (Conexion.State == ConnectionState.Closed)
                    Conexion.Open();
                return Conexion;
            }
            public SqlConnection CerrarConexion()
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
                return Conexion;
            }
        
    }
}
