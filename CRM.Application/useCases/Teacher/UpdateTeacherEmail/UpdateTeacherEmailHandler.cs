using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Teacher.UpdateTeacherEmail
{
    public class UpdateTeacherEmailHandler : IRequestHandler<UpdateTeacherEmailRequest, UpdateTeacherEmailResponse>
    {
        private readonly CrmContext _crmContext;

        public UpdateTeacherEmailHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<UpdateTeacherEmailResponse> Handle(UpdateTeacherEmailRequest request, CancellationToken cancellationToken)
        {
            var teacher = await _crmContext.Teachers.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (teacher == null)           
                throw new ApplicationException($"{ExCodes.TeacherNotFound} - {ExMessages.TeacherNotFound}");
            
            if(teacher.Email == request.Email)
            {
                return new UpdateTeacherEmailResponse
                {
                    Email = request.Email,
                };
            }

            var emailExists = await _crmContext.Teachers.AnyAsync(t => t.Email == request.Email);
            if (emailExists)        
                throw new ApplicationException( $"{ExCodes.TeacherEmailAlreadyExists} - {ExMessages.TeacherEmailAlreadyExists}");

            teacher.Email = request.Email;
            teacher.UpdatedDate = DateTime.UtcNow;

            await _crmContext.SaveChangesAsync();

            return new UpdateTeacherEmailResponse
            {
                Email = request.Email,
            };


        }
    }
}
