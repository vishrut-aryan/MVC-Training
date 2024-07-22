using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFexp3.Models
{
    public partial class UserValidate
    {
        public int USERID { get; set; }
        [Required(ErrorMessage = "User Name is Mandatory")]
        public string USERNAME { get; set; }

        [Required(ErrorMessage = "Password is Mandatory")]
        public string PASSWORD { get; set; }


        [Required(ErrorMessage = "Email is Mandatory")]
        [EmailAddress(ErrorMessage = "EmailId is not in correct format")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Mobile is Mandatory")]
        public string MOBILE { get; set; }
    }
}