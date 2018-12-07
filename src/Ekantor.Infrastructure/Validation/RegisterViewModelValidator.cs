using Exchange.Infrastructure.ViewModels;
using FluentValidation;

namespace Exchange.Infrastructure.Validators
{
    public class RegisterUserViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterUserViewModelValidator()
        {
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword)
                .WithMessage("Passwords doesn't match");

            RuleFor(x => x.EmailAddress)
                .NotNull()
                .WithMessage("This field is required")
                .EmailAddress()
                .WithMessage("Pleas enterm email address in valid format");

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("This field is required");

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("This field is required");

            RuleFor(x => x.UserName)
                .NotNull()
                .WithMessage("This field is required");
            RuleFor(x => x.WalletAmount)
                .NotNull()
                .WithMessage("This field is required")
                .GreaterThan(0)
                .WithMessage("Bad amount value");
        }
    }
}