using DemoCRM.Application.useCases.Course.CreateCourse;
using MediatR;

namespace WebApi.Graph.Mutations
{
    [MutationType]
    public class CourseMutations
    {
        public async Task<CreateCourseResponse> CreateCourseAsync( [Service] IMediator mediator, CreateCourseRequest request)
        {
            return await mediator.Send(request);    
        }
    }
}
