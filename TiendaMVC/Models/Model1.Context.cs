﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Tienda11Entities : DbContext
    {
        public Tienda11Entities()
            : base("name=Tienda11Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Almacen> Almacen { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoAlmacen> ProductoAlmacen { get; set; }
    }
}
