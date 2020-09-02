using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ClassCliente
    {
        public string Nombre { get; set; }
        public string Apelledo { get; set; }
        public string Mail { get; set; }
        public int Areaid { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public int Perfilid { get; set; }
    }
}
