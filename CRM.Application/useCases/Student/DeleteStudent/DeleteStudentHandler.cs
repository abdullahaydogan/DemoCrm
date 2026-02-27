using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using MediatR;

namespace DemoCRM.Application.useCases.Student.DeleteStudent
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest, DeleteStudentResponse>
    {
        private readonly CrmContext _crmContext;

        public DeleteStudentHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<DeleteStudentResponse> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            var entity = _crmContext.Students.FirstOrDefault(s => s.Id == request.Id)
                ?? throw new ApplicationException($"{ExCodes.StudentNotFound} - {ExMessages.StudentNotFound}");

            _crmContext.Students.Remove(entity);

            await _crmContext.SaveChangesAsync(cancellationToken);
            var response = new DeleteStudentResponse
            {
                IsSuccess = true,
                Message = "Student deleted successfully"
            };
            return response;
        }
    }
}
