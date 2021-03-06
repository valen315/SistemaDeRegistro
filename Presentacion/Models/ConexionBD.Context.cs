﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UsuariosEntities : DbContext
    {
        public UsuariosEntities()
            : base("name=UsuariosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual ObjectResult<buscarnombre_Result> buscarnombre(string buscar)
        {
            var buscarParameter = buscar != null ?
                new ObjectParameter("Buscar", buscar) :
                new ObjectParameter("Buscar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscarnombre_Result>("buscarnombre", buscarParameter);
        }
    
        public virtual ObjectResult<buscarTablaSalario_Result> buscarTablaSalario(string buscar)
        {
            var buscarParameter = buscar != null ?
                new ObjectParameter("Buscar", buscar) :
                new ObjectParameter("Buscar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<buscarTablaSalario_Result>("buscarTablaSalario", buscarParameter);
        }
    
        public virtual int EditarArea(Nullable<int> id, string descripcionA)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var descripcionAParameter = descripcionA != null ?
                new ObjectParameter("DescripcionA", descripcionA) :
                new ObjectParameter("DescripcionA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditarArea", idParameter, descripcionAParameter);
        }
    
        public virtual int EliminarArea(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarArea", idParameter);
        }
    
        public virtual int EliminarRegistro(Nullable<int> idC)
        {
            var idCParameter = idC.HasValue ?
                new ObjectParameter("idC", idC) :
                new ObjectParameter("idC", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarRegistro", idCParameter);
        }
    
        public virtual int InsertarArea(string descripcionA)
        {
            var descripcionAParameter = descripcionA != null ?
                new ObjectParameter("DescripcionA", descripcionA) :
                new ObjectParameter("DescripcionA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarArea", descripcionAParameter);
        }
    
        public virtual ObjectResult<ListaArea_Result> ListaArea()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListaArea_Result>("ListaArea");
        }
    
        public virtual ObjectResult<ListaPerfiles_Result> ListaPerfiles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListaPerfiles_Result>("ListaPerfiles");
        }
    
        public virtual ObjectResult<ListarTablaArea_Result> ListarTablaArea()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListarTablaArea_Result>("ListarTablaArea");
        }
    
        public virtual ObjectResult<ListaUsuarios_Result> ListaUsuarios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListaUsuarios_Result>("ListaUsuarios");
        }
    
        public virtual int Modificartabla(Nullable<int> idC, string nombre, string apellido, string mail, Nullable<int> areaid, Nullable<System.DateTime> fechaDeNacimiento, Nullable<int> perfilid)
        {
            var idCParameter = idC.HasValue ?
                new ObjectParameter("idC", idC) :
                new ObjectParameter("idC", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var mailParameter = mail != null ?
                new ObjectParameter("Mail", mail) :
                new ObjectParameter("Mail", typeof(string));
    
            var areaidParameter = areaid.HasValue ?
                new ObjectParameter("Areaid", areaid) :
                new ObjectParameter("Areaid", typeof(int));
    
            var fechaDeNacimientoParameter = fechaDeNacimiento.HasValue ?
                new ObjectParameter("FechaDeNacimiento", fechaDeNacimiento) :
                new ObjectParameter("FechaDeNacimiento", typeof(System.DateTime));
    
            var perfilidParameter = perfilid.HasValue ?
                new ObjectParameter("Perfilid", perfilid) :
                new ObjectParameter("Perfilid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Modificartabla", idCParameter, nombreParameter, apellidoParameter, mailParameter, areaidParameter, fechaDeNacimientoParameter, perfilidParameter);
        }
    
        public virtual int ModificartablaSalario(Nullable<int> idC, Nullable<decimal> salario)
        {
            var idCParameter = idC.HasValue ?
                new ObjectParameter("idC", idC) :
                new ObjectParameter("idC", typeof(int));
    
            var salarioParameter = salario.HasValue ?
                new ObjectParameter("Salario", salario) :
                new ObjectParameter("Salario", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ModificartablaSalario", idCParameter, salarioParameter);
        }
    
        public virtual ObjectResult<MostrarTablaClientes2_Result> MostrarTablaClientes2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MostrarTablaClientes2_Result>("MostrarTablaClientes2");
        }
    
        public virtual ObjectResult<MostrarTablaSalario_Result> MostrarTablaSalario()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MostrarTablaSalario_Result>("MostrarTablaSalario");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_InsertarUsuario(string nombre, string apellido, string mail, Nullable<int> areaid, Nullable<System.DateTime> fechaDeNacimiento, Nullable<int> perfilid)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var mailParameter = mail != null ?
                new ObjectParameter("Mail", mail) :
                new ObjectParameter("Mail", typeof(string));
    
            var areaidParameter = areaid.HasValue ?
                new ObjectParameter("Areaid", areaid) :
                new ObjectParameter("Areaid", typeof(int));
    
            var fechaDeNacimientoParameter = fechaDeNacimiento.HasValue ?
                new ObjectParameter("FechaDeNacimiento", fechaDeNacimiento) :
                new ObjectParameter("FechaDeNacimiento", typeof(System.DateTime));
    
            var perfilidParameter = perfilid.HasValue ?
                new ObjectParameter("Perfilid", perfilid) :
                new ObjectParameter("Perfilid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertarUsuario", nombreParameter, apellidoParameter, mailParameter, areaidParameter, fechaDeNacimientoParameter, perfilidParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
