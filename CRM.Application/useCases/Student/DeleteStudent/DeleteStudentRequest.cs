using MediatR;

namespace DemoCRM.Application.useCases.Student.DeleteStudent
{
    public class DeleteStudentRequest : IRequest<DeleteStudentResponse>
    {
        public int Id { get; set; }
    }
}
