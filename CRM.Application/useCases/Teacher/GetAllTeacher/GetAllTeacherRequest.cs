using MediatR;

namespace DemoCRM.Application.useCases.Teacher.GetAllTeacher
{
    public class GetAllTeacherRequest : IRequest<List<GetAllTeacherResponse>>
    {
    }
}
