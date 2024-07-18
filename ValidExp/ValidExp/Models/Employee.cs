using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidExp.Models
{
    public class Designation
    {
        public string DesignationName { get; set; }
    }

    public class Employee
    {
        public int EmpId { get; set; }


        [Required(ErrorMessage = "EmpName is mandatory")]
        public string EmpName { get; set; }

        public string Gender { get; set; } // Radio Button

        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Salary is mandatory")]
        [Range(5000, 50000, ErrorMessage = "Salary between 5000 and 50000")]
        public float Salary { get; set; }


        [Required(ErrorMessage = "Designation is mandatory")]
        [RegularExpression("[A-Za-z]*", ErrorMessage = "Only Alphabets")]
        public string Designation { get; set; }  //  Dropdown Item

        public bool isActive { get; set; }

        public List<Designation> dstlist { get; set; }  //  Dropdown List

    }

}