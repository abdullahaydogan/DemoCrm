using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace DemoCRM.Application.useCases.Student.GetStudentBySurname
{
    public class GetStudentBySurnameHandler : IRequestHandler<GetStudentBySurnameRequest, IQueryable<Core.Entity.Student>>
    {
        private readonly CrmContext _crmContext;

        public GetStudentBySurnameHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public Task<IQueryable<Core.Entity.Student>> Handle(GetStudentBySurnameRequest request, CancellationToken cancellationToken)
        {
            var query = _crmContext.Students.AsNoTracking().Where(s => s.Surname == request.Surname)
                ?? throw new Exception($"{ExCodes.StudentNotFound} - {ExMessages.StudentNotFound}");
            return Task.FromResult(query);
        }
    }
}
