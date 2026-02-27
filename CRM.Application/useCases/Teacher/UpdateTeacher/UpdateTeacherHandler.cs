using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Teacher.UpdateTeacher
{
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherRequest, UpdateTeacherResponse>
    {
        private readonly CrmContext _crmContext;

        public UpdateTeacherHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<UpdateTeacherResponse> Handle(UpdateTeacherRequest request, CancellationToken cancellationToken)
        {
            var existTeacher = await _crmContext.Teachers.FirstOrDefaultAsync(t => t.Id.Equals(request.Id));
            if(existTeacher == null)
            {
                throw new ApplicationException($"{ExCodes.TeacherNotFound} - {ExMessages.TeacherNotFound}");
            }

            if(request.Name != null)
                existTeacher.Name = request.Name;
            

            if(request.Surname != null)
                existTeacher.Surname= request.Surname;
 

            if(request.Email != null)
                existTeacher.Email = request.Email;
            

            if(request.ContactValue != null)
               existTeacher.ContactValue = request.ContactValue;


            if (request.IsActive.HasValue && request.IsActive.Value != existTeacher.IsActive)
                existTeacher.IsActive = request.IsActive.Value;

            if (request.Branch != null)
                existTeacher.Branch = request.Branch;
            
            existTeacher.UpdatedDate = DateTime.UtcNow;

            await _crmContext.SaveChangesAsync(cancellationToken);

            var response = existTeacher.Adapt<UpdateTeacherResponse>();
            return response;
        }
    }
}
