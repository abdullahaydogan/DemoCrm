using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoCRM.Application.useCases.Course.CreateCourse
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseRequest, CreateCourseResponse>
    {
        private readonly CrmContext _crmContext;

        public CreateCourseHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<CreateCourseResponse> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var exists = await _crmContext.Courses.AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (exists)
            {
                throw new ApplicationException($"{ExCodes.CourseAlreadyExists} - {ExMessages.CourseAlreadyExists}");
            }

            var courses = new Core.Entity.Course
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                IsActive = request.IsActive,
                CreatedDate = DateTime.UtcNow
            };

            if(request.TeacherIds != null && request.TeacherIds.Count() != 0)
            {
                var teachers = await _crmContext.Teachers.Where(t => request.TeacherIds.Contains(t.Id)).ToListAsync(cancellationToken);
                foreach ( var teacher in teachers)
                {
                    request.TeacherIds.Add(teacher.Id);
                }
            }

            if(request.StudentIds != null && request.TeacherIds.Count()!= 0)
            {
                var students = await _crmContext.Students.Where(student => request.StudentIds.Contains(student.Id)).ToListAsync(cancellationToken);
                foreach ( var student in students)
                {
                    request.StudentIds.Add(student.Id);
                }
            }

            await _crmContext.Courses.AddAsync(courses, cancellationToken);
            await _crmContext.SaveChangesAsync(cancellationToken);

            return courses.Adapt<CreateCourseResponse>();
        }
    }
}
