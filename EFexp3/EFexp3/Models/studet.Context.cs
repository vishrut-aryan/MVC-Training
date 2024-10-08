﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFexp3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Data.Entity.Core.Objects;
    
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
        public DbSet<USERDETAIL> USERDETAILS { get; set; }
    
        public virtual int SP_ADDUSER1(USERDETAIL u1)
        {
            var nAMEParameter = u1.USERNAME != null ?
                new ObjectParameter("NAME", u1.USERNAME) :
                new ObjectParameter("NAME", typeof(string));
    
            var pASSParameter = u1.PASSWORD != null ?
                new ObjectParameter("PASS", u1.PASSWORD) :
                new ObjectParameter("PASS", typeof(string));
    
            var eMAILParameter = u1.EMAIL != null ?
                new ObjectParameter("EMAIL", u1.EMAIL) :
                new ObjectParameter("EMAIL", typeof(string));
    
            var mOBParameter = u1.MOBILE != null ?
                new ObjectParameter("MOB", u1.MOBILE) :
                new ObjectParameter("MOB", typeof(string));
    
            var dOBParameter = u1.DATEOFBIRTH.HasValue ?
                new ObjectParameter("DOB", u1.DATEOFBIRTH) :
                new ObjectParameter("DOB", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ADDUSER1",nAMEParameter, pASSParameter, eMAILParameter, mOBParameter, dOBParameter);
        }
    }
}
