using FluentValidation;

namespace DemoCRM.Application.useCases.Teacher.DeleteTeacher
{
    public class DeleteTeacherValidation : AbstractValidator<DeleteTeacherRequest>
    {
        public DeleteTeacherValidation()
        {
            RuleFor(x => x.Id) .GreaterThan(0).NotEmpty();
        }
    }
}
