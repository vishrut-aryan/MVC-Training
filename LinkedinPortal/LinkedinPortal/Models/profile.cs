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
    
    public partial class profile
    {
        public profile()
        {
            this.posts = new HashSet<post>();
        }
    
        public int profileid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string headline { get; set; }
        public string summary { get; set; }
        public string loc { get; set; }
        public string education { get; set; }
        public string experience { get; set; }
        public string skills { get; set; }
        public Nullable<int> userid { get; set; }
    
        public virtual ICollection<post> posts { get; set; }
        public virtual user user { get; set; }
    }
}
