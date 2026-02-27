using MediatR;

namespace DemoCRM.Application.useCases.Student.GetStudentByName
{
    public class GetStudentsByNameRequest : IRequest<IQueryable<DemoCRM.Core.Entity.Student>>
    {
        public string? Name { get; set; }
    }
}
