using CourseEntity = DemoCRM.Core.Entity.Course;

namespace DemoCRM.Application.useCases.Teacher.GetAllTeacher
{
    public class GetAllTeacherResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; }
        public string? ContactValue { get; set; }
        public virtual CourseEntity? Courses { get; set; }

    }
}
