using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Teacher.GetAllTeacherEntity
{
    public class GetAllTeacherEntityHandler : IRequestHandler<GetAllTeacherEntityRequest, IQueryable<Core.Entity.Teacher>>
    {
        private readonly CrmContext _crmContext;

        public GetAllTeacherEntityHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public Task<IQueryable<Core.Entity.Teacher>> Handle(GetAllTeacherEntityRequest request, CancellationToken cancellationToken)
        {
            var query = _crmContext.Teachers.Where(t => t.IsActive.Equals(true)).AsNoTracking().Include(t => t.Courses).AsQueryable();
            return Task.FromResult(query);
        }
    }
}
