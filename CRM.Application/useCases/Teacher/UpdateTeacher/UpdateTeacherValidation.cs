using FluentValidation;

namespace DemoCRM.Application.useCases.Teacher.UpdateTeacher
{
    public class UpdateTeacherValidation : AbstractValidator<UpdateTeacherRequest>
    {
        public UpdateTeacherValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            When(x => x.Name != null, () =>
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .MaximumLength(100);
            });

            When(x => x.Surname != null, () =>
            {
                RuleFor(x => x.Surname)
                    .NotEmpty()
                    .MaximumLength(100);
            });

            When(x => x.Branch != null, () =>
            {
                RuleFor(x => x.Branch)
                    .NotEmpty()
                    .MaximumLength(100);
            });

            When(x => x.ContactValue != null, () =>
            {
                RuleFor(x => x.ContactValue)
                    .NotEmpty()
                    .MaximumLength(50);
            });

            //  En az bir alan güncellenmeli
            RuleFor(x => x)
                .Must(x =>
                    x.Name != null ||
                    x.Surname != null ||
                    x.Branch != null ||
                    x.ContactValue != null ||
                    x.IsActive != null
                )
                .WithMessage("At least one field must be provided for update.");
        }
    }
}
