using MediatR;

namespace DemoCRM.Application.useCases.Teacher.UpdateTeacher
{
    public class UpdateTeacherRequest : IRequest<UpdateTeacherResponse>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Branch { get; set; }
        public string? ContactValue { get; set; }
        public bool? IsActive { get; set; }
        public string? Email { get; set; }
    }
}
