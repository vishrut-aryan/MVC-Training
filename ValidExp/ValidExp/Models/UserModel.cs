using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidExp.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Username is Mandatory")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password should be a minimum of 5 characters")]
        [RegularExpression("[A-Za-z]*", ErrorMessage = "Only Alphabets")]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Email Address is not valid!")]
        [Required(ErrorMessage = "Email Address is Mandatory")]

        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Date of Birth is Mandatory")]
        public string DateofBirth { get; set; }
    }
}