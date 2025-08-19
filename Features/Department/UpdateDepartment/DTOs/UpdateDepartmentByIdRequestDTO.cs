namespace HRSystem.Features.Department.UpdateDepartment.DTOs
{
    public class UpdateDepartmentByIdRequestDTO
    {
        public string? Name { get; set; }
        public int? NumOfEmployees { get; set; }

        public string? Description { get; set; }
    }
}
