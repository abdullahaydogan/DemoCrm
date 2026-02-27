using MediatR;

namespace DemoCRM.Application.useCases.Student.UpdateStudent
{
    public class UpdateStudentRequest : IRequest<UpdateStudentResponse>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }

}
