﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFexp2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class STUDENTSEntities : DbContext
    {
        public STUDENTSEntities()
            : base("name=STUDENTSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<department> departments { get; set; }
        public DbSet<designation> designations { get; set; }
        public DbSet<employee> employees { get; set; }

        public System.Data.Entity.DbSet<EFexp2.Models.empd> empds { get; set; }
    }
}
