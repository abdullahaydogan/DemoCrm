using MediatR;

namespace DemoCRM.Application.useCases.Teacher.DeleteTeacher
{
    public class DeleteTeacherRequest : IRequest<DeleteTeacherResponse>
    {
        public int Id { get; set; }
    }
}
