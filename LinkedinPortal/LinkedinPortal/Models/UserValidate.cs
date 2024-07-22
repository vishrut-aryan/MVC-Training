using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkedinPortal.Models
{
    [MetadataType(typeof(UserValidate))]
    public partial class user { }

    public partial class UserValidate
    {
        public int userid { get; set; }

        [Required(ErrorMessage = "Username is mandatory")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password should be between 6 and 100 characters")]
        public string password { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage = "Email is not in correct format")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mobile is mandatory")]
        [Phone(ErrorMessage = "Mobile number is not valid")]
        public string mobile { get; set; }
    }
}