using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Teacher.GetTeacherDemo
{
    public class GetTeacherDemoHandler : IRequestHandler<GetTeacherDemoRequest, GetTeacherDemoResponse>
    {
        private readonly CrmContext _crmContext;

        public GetTeacherDemoHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<GetTeacherDemoResponse> Handle(GetTeacherDemoRequest request, CancellationToken cancellationToken)
        {
            var result = await _crmContext.Teachers.Select(t => t.Name).ToListAsync(cancellationToken);

            return new GetTeacherDemoResponse
            {
                TeacherNames = result
            };
        }
    }
}
