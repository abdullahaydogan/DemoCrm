using MediatR;

namespace DemoCRM.Application.useCases.Teacher.SearchTeacher
{
    public class SearchTeacherRequest : IRequest<IQueryable<DemoCRM.Core.Entity.Teacher>>
    {
        public bool? IsActive { get; set; } = true;
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? ContactValue { get; set; }
        public string? Branch { get; set; }
    }
}
