using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Course.GetAllCourse
{
    public class GetAllCourseHandler : IRequestHandler<GetAllCourseRequest, IQueryable<Core.Entity.Course>>
    {
        private readonly CrmContext _crmContext;

        public GetAllCourseHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public Task<IQueryable<Core.Entity.Course>> Handle(GetAllCourseRequest request, CancellationToken cancellationToken)
        {
            var query = _crmContext.Courses.AsNoTracking()
                ?? throw new ApplicationException($"{ExCodes.CourseNotFound} - {ExMessages.CourseNotFound}");
            return Task.FromResult(query);
        }
    }
}
