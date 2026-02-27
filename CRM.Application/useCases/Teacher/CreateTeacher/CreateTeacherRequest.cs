using MediatR;

namespace DemoCRM.Application.useCases.Teacher.CreateTeacher
{
    public class CreateTeacherRequest : IRequest<CreateTeacherResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Branch { get; set; }
        public string? ContactValue { get; set; }
    }
}
