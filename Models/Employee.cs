namespace HRSystem.Models
{
    public class Employee : User
    {
        public string EmployeeCode { get; set; }
        public string JobTitle { get; set; }
        public DateTime JoiningDate { get; set; }
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
