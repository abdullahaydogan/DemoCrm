using MediatR;

namespace DemoCRM.Application.useCases.Teacher.UpdateTeacherEmail
{
    public class UpdateTeacherEmailRequest : IRequest<UpdateTeacherEmailResponse>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
