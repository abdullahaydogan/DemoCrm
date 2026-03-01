using CourseEntity = DemoCRM.Core.Entity.Course;
namespace DemoCRM.Application.useCases.Teacher.SearchTeacher
{
    public class SearchTeacherResponse
    {
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? ContactValue { get; set; }
        public string? Branch { get; set; }
        public virtual CourseEntity? Courses { get; set; }

    }
}
