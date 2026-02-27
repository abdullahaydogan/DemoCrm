using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Student.GetStudentByName
{
    public class GetStudentsByNameHandler : IRequestHandler<GetStudentsByNameRequest, IQueryable<DemoCRM.Core.Entity.Student>>
    {
        private readonly CrmContext _crmContext;

        public GetStudentsByNameHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public Task<IQueryable<Core.Entity.Student>> Handle(GetStudentsByNameRequest request, CancellationToken cancellationToken)
        {
            var query = _crmContext.Students
                .AsNoTracking()
                .Where(s => s.Name != null && s.Name.Contains(request.Name))
                    ?? throw new ApplicationException($"{ExCodes.StudentNotFound} - {ExMessages.StudentNotFound}");

            return Task.FromResult(query);
        }
    }
}
