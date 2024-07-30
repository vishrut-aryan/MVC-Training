using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _30July.Models
{
    public class UserDetails
    {
        public int USERID { get; set; }

        [DisplayName("FULLNAME")]
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE { get; set; }
    }
}