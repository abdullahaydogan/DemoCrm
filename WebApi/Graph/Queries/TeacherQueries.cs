using DemoCRM.Application.useCases.Teacher.GetAllTeacher;
using DemoCRM.Application.useCases.Teacher.GetAllTeacherEntity;
using DemoCRM.Application.useCases.Teacher.GetTeacherDemo;
using DemoCRM.Application.useCases.Teacher.SearchTeacher;
using DemoCRM.Core.Entity;
using MediatR;

namespace WebApi.Graph.Queries
{
    [QueryType]
    public class TeacherQueries
    {
        public async Task<List<GetAllTeacherResponse>> GetAllTeachers([Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllTeacherRequest());
        }

        public async Task<IQueryable<Teacher>> GetAllTeacherEntites([Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllTeacherEntityRequest());
        }
        public async Task<IQueryable<Teacher>> SearchTeachers(SearchTeacherRequest searchTeacherRequest, [Service] IMediator mediator)
        {
            return await mediator.Send(searchTeacherRequest);
        }

        public Task<GetTeacherDemoResponse> GetTeacherDemo([Service] IMediator mediator)
        {
            return mediator.Send(new GetTeacherDemoRequest());
        }
    }
}
