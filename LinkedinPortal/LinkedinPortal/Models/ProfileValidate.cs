using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkedinPortal.Models
{
    [MetadataType(typeof(ProfileValidate))]
    public partial class profile { }

    public partial class ProfileValidate
    {
        public int profileid { get; set; }

        [Required(ErrorMessage = "First name is mandatory")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Last name is mandatory")]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage = "Email is not in correct format")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mobile is mandatory")]
        [Phone(ErrorMessage = "Mobile number is not valid")]
        public string mobile { get; set; }

        [Required(ErrorMessage = "Headline is mandatory")]
        public string headline { get; set; }

        [Required(ErrorMessage = "Summary is mandatory")]
        [StringLength(500, ErrorMessage = "Summary cannot be longer than 500 characters")]
        public string summary { get; set; }

        [Required(ErrorMessage = "Location is mandatory")]
        public string loc { get; set; }

        [Required(ErrorMessage = "Education is mandatory")]
        public string education { get; set; }

        [Required(ErrorMessage = "Experience is mandatory")]
        public string experience { get; set; }

        [Required(ErrorMessage = "Skills are mandatory")]
        public string skills { get; set; }

        public Nullable<int> userid { get; set; }
    }
}