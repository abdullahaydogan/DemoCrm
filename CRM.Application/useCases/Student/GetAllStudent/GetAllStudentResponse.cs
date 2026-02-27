namespace DemoCRM.Application.useCases.Student.GetAllStudent
{
    public class GetAllStudentResponse
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public List<string>? Courses { get; set; }
    }
}
