using Exchange.Infrastructure.Validation;
using FluentValidation.Attributes;

namespace Exchange.Infrastructure.ViewModels
{
    [Validator(typeof(LogInViewModelValidator))]
    public class LogInViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}