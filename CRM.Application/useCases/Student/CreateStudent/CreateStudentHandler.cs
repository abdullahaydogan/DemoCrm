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
                    throw new ApplicationException(
                        $"{ExCodes.StudentAlreadyExists} - {ExMessages.StudentAlreadyExists}"
                    );
                }
            }

            var student = request.Adapt<DemoCRM.Core.Entity.Student>();

            student.Courses = new List<DemoCRM.Core.Entity.Course>();

            if (request.CourseIds != null && request.CourseIds.Any())
            {
                var courses = await _crmContext.Courses
                    .Where(c => request.CourseIds.Contains(c.Id))
                    .ToListAsync(cancellationToken);

                foreach (var course in courses)
                {
                    student.Courses.Add(course);
                }
            }

            // 4️⃣ Persist
            await _crmContext.Students.AddAsync(student, cancellationToken);
            await _crmContext.SaveChangesAsync(cancellationToken);

            // 5️⃣ Response
            return student.Adapt<CreateStudentResponse>();
        }

    }
}
