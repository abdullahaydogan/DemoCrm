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
            var entity = _crmContext.Courses.SingleOrDefault(x => x.Name == request.Name)
                ?? throw new ApplicationException($"{ExCodes.CourseAlreadyExists} - {ExMessages.CourseAlreadyExists}");

            var course = request.Adapt<DemoCRM.Core.Entity.Course>();
            course.IsActive = request.IsActive;

            if (request.StudentIds != null && request.StudentIds.Any())
            {
                var students = await _crmContext.Students.Where(s => request.StudentIds.Contains(s.Id)).ToListAsync(cancellationToken);
                course.Students = students;
            }

            _crmContext.Courses.Add(course);
            await _crmContext.SaveChangesAsync(cancellationToken);

            var response = course.Adapt<CreateCourseResponse>();

            return response;
        }
    }
}
