//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class department
    {
        public department()
        {
            this.employees = new HashSet<employee>();
        }
    
        public int deptid { get; set; }
        public string deptname { get; set; }
    
        public virtual ICollection<employee> employees { get; set; }
    }
}
