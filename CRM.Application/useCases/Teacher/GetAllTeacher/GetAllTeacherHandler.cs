using DemoCRM.Persistance.Context;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Teacher.GetAllTeacher
{
    public class GetAllTeacherHandler : IRequestHandler<GetAllTeacherRequest, List<GetAllTeacherResponse>>
    {
        private readonly CrmContext _crmContext;

        public GetAllTeacherHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<List<GetAllTeacherResponse>> Handle(GetAllTeacherRequest request, CancellationToken cancellationToken)
        {
            var teachers = await _crmContext.Teachers.Where(t => t.IsActive == true).AsNoTracking().ToListAsync(cancellationToken);
            var response = teachers.Adapt<List<GetAllTeacherResponse>>();

            return response;
        }
     }
}
