 using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Student.GetStudentById
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdRequest, GetStudentByIdResponse>
    {
        private readonly CrmContext _crmContext;
        public GetStudentByIdHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }
        public async Task<GetStudentByIdResponse> Handle(GetStudentByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _crmContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                 ?? throw new ApplicationException($"{ExCodes.StudentNotFound} - {ExMessages.StudentNotFound}");

            var response = entity.Adapt<GetStudentByIdResponse>();
            return response;
        }
    }
}
