using FluentValidation;

namespace DemoCRM.Application.useCases.Student.DeleteStudent
{
    public class DeleteStudentValidation : AbstractValidator<DeleteStudentRequest>
    {
        public DeleteStudentValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
