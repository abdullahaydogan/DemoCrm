using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Student.GetAllStudent
{
    public class GetAllStudentHandler : IRequestHandler<GetAllStudentRequest, List<GetAllStudentResponse>>
    {
        private readonly CrmContext _crmContext;

        public GetAllStudentHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<List<GetAllStudentResponse>> Handle(GetAllStudentRequest request, CancellationToken cancellationToken)
        {
            var entity = await _crmContext.Students.AsNoTracking().ToListAsync(cancellationToken)
                ?? throw new ApplicationException($"{ExCodes.StudentNotFound} - {ExMessages.StudentNotFound}");
            var response = entity.Adapt<List<GetAllStudentResponse>>();
            return response;
        }
    }
}
