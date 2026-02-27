using DemoCRM.Application.useCases.Student.GetAllStudent;
using DemoCRM.Application.useCases.Student.GetAllStudentEntity;
using DemoCRM.Application.useCases.Student.GetStudentByEmail;
using DemoCRM.Application.useCases.Student.GetStudentById;
using DemoCRM.Application.useCases.Student.GetStudentByName;
using DemoCRM.Application.useCases.Student.GetStudentBySurname;
using DemoCRM.Application.useCases.Student.SearchStudent;
using DemoCRM.Core.Entity;
using MediatR;

namespace WebApi.Graph.Queries
{
    [QueryType]
    public class StudentQueries
    {
        public async Task<List<GetAllStudentResponse>> GetAllStudents([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetAllStudentRequest(), cancellationToken);
        }
        public Task<GetStudentByIdResponse> GetStudentById([Service] IMediator mediator, GetStudentByIdRequest request, CancellationToken cancellationToken)
        {
            return mediator.Send(request, cancellationToken);
        }
        public async Task<IQueryable<Student>> AllStudentEntities([Service] IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetAllStudentEntityRequest());
        }
        public async Task<IQueryable<Student>> GetStudentByName([Service] IMediator medaiator, GetStudentsByNameRequest request, CancellationToken cancellation)
        {
            return await medaiator.Send(request, cancellation);
        }
        public async Task<IQueryable<Student>> SearchStudent([Service] IMediator mediator, SearchStudentRequest request, CancellationToken cancellation)
        {
            return await mediator.Send(request, cancellation);
        }
        public async Task<IQueryable<Student>> GetStudentByEmail([Service] IMediator mediator, GetStudentByEmailRequest request, CancellationToken cancellation)
        {
            return await mediator.Send(new GetStudentByEmailRequest { Email = request.Email }, cancellation);
        }
        public async Task<IQueryable<Student>> GetStudentBySurname([Service] IMediator mediator, GetStudentBySurnameRequest request, CancellationToken cancellation)
        {
            return await mediator.Send(request, cancellation);
        }
    }
}
