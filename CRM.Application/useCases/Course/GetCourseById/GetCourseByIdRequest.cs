using MediatR;

namespace DemoCRM.Application.useCases.Course.GetCourseById
{
    public class GetCourseByIdRequest : IRequest<IQueryable<Core.Entity.Course>>
    {
        public int Id { get; set; }
    }
}
