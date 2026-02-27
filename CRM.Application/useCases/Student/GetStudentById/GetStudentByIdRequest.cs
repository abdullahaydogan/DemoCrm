using MediatR;

namespace DemoCRM.Application.useCases.Student.GetStudentById
{
    public class GetStudentByIdRequest : IRequest<GetStudentByIdResponse>
    {

        public int Id { get; set; }
    }
}
