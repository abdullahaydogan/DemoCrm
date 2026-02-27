using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Teacher.DeleteTeacher
{
    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherRequest, DeleteTeacherResponse>
    {
        private readonly CrmContext _crmContext;

        public DeleteTeacherHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<DeleteTeacherResponse> Handle(DeleteTeacherRequest request, CancellationToken cancellationToken)
        {
            var existTeacher = await _crmContext.Teachers.FirstOrDefaultAsync(t => t.Id.Equals(request.Id));

            if(existTeacher == null)
                throw new ApplicationException($"{ExCodes.TeacherNotFound} - {ExMessages.TeacherNotFound}");
            
            _crmContext.Teachers.Remove(existTeacher);
            await _crmContext.SaveChangesAsync(cancellationToken);

            var response = new DeleteTeacherResponse
            {
                Name = existTeacher.Name,
                Surname = existTeacher.Surname,
            };

            return response;

        }
    }
}
