using FluentValidation;

namespace DemoCRM.Application.useCases.Teacher.DeactivateTeachersByBranch
{
    public class DeactivateTeachersByBranchValidation : AbstractValidator<DeactivateTeachersByBranchRequest>
    {
        public DeactivateTeachersByBranchValidation()
        {
            RuleFor(x => x.Branch).NotEmpty();
        }
    }
}
