using MediatR;

namespace DemoCRM.Application.useCases.Teacher.GetAllTeacherEntity
{
    public class GetAllTeacherEntityRequest : IRequest<IQueryable<Core.Entity.Teacher>>
    {
    }
}
