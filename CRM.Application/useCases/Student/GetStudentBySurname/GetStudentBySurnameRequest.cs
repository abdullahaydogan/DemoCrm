using MediatR;

namespace DemoCRM.Application.useCases.Student.GetStudentBySurname
{
    public class GetStudentBySurnameRequest : IRequest<IQueryable<Core.Entity.Student>>
    {
        public string? Surname { get; set; }
    }
}
