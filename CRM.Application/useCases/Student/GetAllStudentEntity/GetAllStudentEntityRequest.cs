using MediatR;

namespace DemoCRM.Application.useCases.Student.GetAllStudentEntity
{
    public class GetAllStudentEntityRequest : IRequest<IQueryable<DemoCRM.Core.Entity.Student>>
    {
    }
}
