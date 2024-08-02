namespace WebAPIClient.Models
{
    public class EmpStudent
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public int RollNo { get; set; }
        public string? StudName { get; set; }
    }
    public class Emp
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
    }
    public class Student
    {
        public int RollNo { get; set; }
        public string? StudName { get; set; }
    }
}
