//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Presentacion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        public int idC { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public int Areaid { get; set; }
        public System.DateTime FechaDeNacimiento { get; set; }
        public Nullable<decimal> Salario { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public Nullable<int> Perfilid { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual Perfiles Perfiles { get; set; }
    }
}
