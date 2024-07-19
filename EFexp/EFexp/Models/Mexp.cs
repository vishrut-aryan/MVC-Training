using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFexp.Models
{
    public class DBContext
    {
        public List<Emp> employees { get; set; }
        public List<Stu> students { get; set; }
    }

    public class Emp
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
    }

    public class Stu
    {
        public int RollNo { get; set; }
        public string StuName { get; set; }
    }

    public class exp1
    {
        public void add()
        {
            DBContext db = new DBContext();
            db.employees.Add(new Emp());
            db.students.Add(new Stu());
        }
    }
}