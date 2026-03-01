using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Teacher.CreateTeacher
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacherRequest, CreateTeacherResponse>
    {
        private readonly CrmContext _crmContext;

        public CreateTeacherHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<CreateTeacherResponse> Handle(CreateTeacherRequest request, CancellationToken cancellationToken)
        {
            var existTeacher = await _crmContext.Teachers.AnyAsync(t => t.Email == request.Email);
            if(existTeacher == true)
            {
                throw new ApplicationException( $"{ExCodes.TeacherAlreadyExists} - {ExMessages.TeacherAlreadyExists}");
            }

            var teacher = new Core.Entity.Teacher
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Branch = request.Branch,
                ContactValue = request.ContactValue,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,        
            };

            if(request.CourseIds != null && request.CourseIds.Count > 0)
            {
                var courses = await _crmContext.Courses.Where(c => request.CourseIds.Contains(c.Id)).ToListAsync();
                foreach (var course in courses)
                {
                    course.Teachers.Add(teacher);
                }
            }

            await _crmContext.Teachers.AddAsync(teacher);
            await _crmContext.SaveChangesAsync(cancellationToken);

            return teacher.Adapt<CreateTeacherResponse>();

        }
    }
}
