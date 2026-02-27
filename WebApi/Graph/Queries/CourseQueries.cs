using DemoCRM.Application.useCases.Course.GetAllCourse;
using DemoCRM.Application.useCases.Course.GetCourseById;
using DemoCRM.Core.Entity;
using MediatR;

namespace WebApi.Graph.Queries
{
    [QueryType]
    public class CourseQueries
    {
        public async Task<IQueryable<Course>> GetAllCourse([Service] IMediator mediator, CancellationToken cancellation)
        {
            return await mediator.Send(new GetAllCourseRequest(), cancellation);
        }

        public async Task<IQueryable<Course> > GetCourseById([Service] IMediator mediator, CancellationToken cancellation)
        {
           return await mediator.Send(new GetCourseByIdRequest());
        }

    }
}
