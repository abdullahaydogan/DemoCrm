using MediatR;

namespace DemoCRM.Application.useCases.Course.CreateCourse
{
    public class CreateCourseRequest : IRequest<CreateCourseResponse>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public List<int>? StudentIds { get; set; }
        public List<int>? TeacherIds { get; set; }
    }
}
