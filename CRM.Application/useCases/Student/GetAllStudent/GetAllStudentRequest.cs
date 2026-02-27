using DemoCRM.Core.Entity;
using MediatR;

namespace DemoCRM.Application.useCases.Student.GetAllStudent
{
    public class GetAllStudentRequest : IRequest<List<GetAllStudentResponse>>
    {
    }
}
    