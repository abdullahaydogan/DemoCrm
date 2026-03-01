using DemoCRM.Core.Const;
using DemoCRM.Persistance.Context;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.useCases.Student.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentRequest, CreateStudentResponse>
    {
        private readonly CrmContext _crmContext;

        public CreateStudentHandler(CrmContext crmContext)
        {
            _crmContext = crmContext;
        }

        public async Task<CreateStudentResponse> Handle(CreateStudentRequest request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                var exists = await _crmContext.Students.AnyAsync(s => s.Email == request.Email, cancellationToken);

                if (exists)
                {
                    throw new ApplicationException($"{ExCodes.StudentAlreadyExists} - {ExMessages.StudentAlreadyExists}");
                }
            }

            var student = new DemoCRM.Core.Entity.Student
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            if (request.CourseIds != null && request.CourseIds.Count > 0)
            {
                var courses = await _crmContext.Courses.Where(c => request.CourseIds.Contains(c.Id)).ToListAsync(cancellationToken);

                foreach (var course in courses)
                {
                    student.Courses.Add(course);
                }
            }

            await _crmContext.Students.AddAsync(student, cancellationToken);
            await _crmContext.SaveChangesAsync(cancellationToken);

            return student.Adapt<CreateStudentResponse>();
        }

    }
}
