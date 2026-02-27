using FluentValidation;

namespace CRM.Application.useCases.Student.CreateStudent
{
    public class CreateStudentValidation : AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentValidation() {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(100);
            RuleFor(s => s.Surname).NotEmpty().MaximumLength(100);
            RuleFor(s => s.PhoneNumber).NotEmpty();
            RuleFor(s => s.Email).NotEmpty();
            RuleFor(s => s.DateOfBirth).NotEmpty();
            RuleForEach(s => s.CourseIds).GreaterThan(0);
        }
    }
}
