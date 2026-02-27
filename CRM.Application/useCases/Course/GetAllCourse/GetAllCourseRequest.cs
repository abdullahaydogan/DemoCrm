using MediatR;

namespace DemoCRM.Application.useCases.Course.GetAllCourse
{
    public class GetAllCourseRequest : IRequest<IQueryable<Core.Entity.Course>>
    {
    }
}
