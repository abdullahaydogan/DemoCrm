using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Student.UpdateStudent
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentRequest, UpdateStudentResponse>
    {
        private readonly CrmContext _crmContext;

        public UpdateStudentHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<UpdateStudentResponse> Handle(UpdateStudentRequest request, CancellationToken cancellationToken)
        {
            var entity = await _crmContext.Students.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                 ?? throw new ApplicationException( $"{ExCodes.StudentNotFound} - {ExMessages.StudentNotFound}");

                if (request.Name is not null)
                    entity.Name = request.Name;

                if (request.Surname is not null)
                    entity.Surname = request.Surname;

                if (request.PhoneNumber is not null)
                    entity.PhoneNumber = request.PhoneNumber;

                if (request.Email is not null)
                    entity.Email = request.Email;

            await _crmContext.SaveChangesAsync(cancellationToken);

            var response = entity.Adapt<UpdateStudentResponse>();
            return response;


        }
    }
}
