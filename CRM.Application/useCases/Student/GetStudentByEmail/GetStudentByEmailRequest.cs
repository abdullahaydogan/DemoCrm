using MediatR;

namespace DemoCRM.Application.useCases.Student.GetStudentByEmail
{
    public class GetStudentByEmailRequest : IRequest<IQueryable<DemoCRM.Core.Entity.Student>>
    {
        public string Email { get; set; }
    }
}
