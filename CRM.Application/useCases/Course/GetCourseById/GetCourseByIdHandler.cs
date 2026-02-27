using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Course.GetCourseById
{
    public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdRequest, IQueryable<Core.Entity.Course>>
    {
        private readonly CrmContext _crmContext;

        public GetCourseByIdHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public Task<IQueryable<Core.Entity.Course>> Handle(GetCourseByIdRequest request, CancellationToken cancellationToken)
        {
            var query = _crmContext.Courses.AsNoTracking().Where(c => c.Id == request.Id)
                ?? throw new ApplicationException($"{ExCodes.CourseNotFound} - {ExMessages.CourseNotFound}");
            return Task.FromResult(query);
        }
    }
}
