namespace DemoCRM.Application.useCases.Student.GetStudentById
{
    public class GetStudentByIdResponse
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }
}
