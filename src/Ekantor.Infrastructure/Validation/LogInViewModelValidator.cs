using Exchange.Infrastructure.ViewModels;
using FluentValidation;

namespace Exchange.Infrastructure.Validation
{
    public class LogInViewModelValidator : AbstractValidator<LogInViewModel>
    {
        public LogInViewModelValidator()
        {
            RuleFor(x => x.Password).NotNull().WithMessage("Please enter UserName");
            RuleFor(x => x.UserName).NotNull().WithMessage("Please enter UserName");
        }
    }
}