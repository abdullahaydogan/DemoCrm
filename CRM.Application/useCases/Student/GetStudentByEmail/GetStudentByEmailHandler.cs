using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Student.GetStudentByEmail
{
    public class GetStudentByEmailHandler : IRequestHandler<GetStudentByEmailRequest, IQueryable<Core.Entity.Student>>
    {
        private readonly CrmContext _crmContext;

        public GetStudentByEmailHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public Task<IQueryable<Core.Entity.Student>> Handle(GetStudentByEmailRequest request, CancellationToken cancellationToken)
        {
            var query = _crmContext.Students
                .AsNoTracking()
                .Where(s => s.Email == request.Email);
            return Task.FromResult(query);
        }
    }
}
