using DemoCRM.Application.useCases.Teacher.CreateTeacher;
using DemoCRM.Application.useCases.Teacher.DeactivateTeachersByBranch;
using DemoCRM.Application.useCases.Teacher.DeleteTeacher;
using DemoCRM.Application.useCases.Teacher.UpdateTeacher;
using DemoCRM.Application.useCases.Teacher.UpdateTeacherEmail;
using MediatR;

namespace WebApi.Graph.Mutations
{
    [MutationType]
    public class TeacherMutations
    {
        public async Task<CreateTeacherResponse> CreateTeacher([Service] IMediator mediator, CreateTeacherRequest request)
        {
            return await mediator.Send(request);
        }

        public async Task<UpdateTeacherResponse> UpdateTeacher([Service] IMediator mediator, UpdateTeacherRequest request)
        {
            return await mediator.Send(request);
        }

        public async Task<DeleteTeacherResponse> DeleteTeacher([Service] IMediator mediator, DeleteTeacherRequest request)
        {
            return await mediator.Send(request);
        }

        public async Task<DeactivateTeachersByBranchResponse> DeactivateTeachersByBranch([Service] IMediator mediator, DeactivateTeachersByBranchRequest request)
        {
            return await mediator.Send(request);
        }

        public async Task<UpdateTeacherEmailResponse> UpdateTeacherEmail([Service] IMediator mediator, UpdateTeacherEmailRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
