//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinkedinPortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public user()
        {
            this.profiles = new HashSet<profile>();
        }
    
        public int userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
    
        public virtual ICollection<profile> profiles { get; set; }
    }
}
