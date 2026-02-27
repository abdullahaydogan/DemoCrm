using CRM.Application.useCases.Student.CreateStudent;
using DemoCRM.Application.useCases.Student.DeleteStudent;
using DemoCRM.Application.useCases.Student.UpdateStudent;
using MediatR;

namespace WebApi.Graph.Mutations
{
    [MutationType]  
    public class StudentMutations
    {
        public async Task<CreateStudentResponse> CreateStudent([Service] IMediator mediator, CreateStudentRequest request)
        {
            return await mediator.Send(request);
        }
        public Task<DeleteStudentResponse> DeleteStudent([Service] IMediator mediator, DeleteStudentRequest request)
        {
            return mediator.Send(request);
        }
        public Task<UpdateStudentResponse> UpdateStudent([Service] IMediator mediator,UpdateStudentRequest request)
        {
            return mediator.Send(request);
        }
    }
}
