//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _30July.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Neighborhood
    {
        public int NeighborhoodID { get; set; }
        public string NeighborhoodName { get; set; }
        public Nullable<int> CityID { get; set; }
    
        public virtual City City { get; set; }
    }
}
