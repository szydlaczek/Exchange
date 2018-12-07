using Exchange.Infrastructure.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Infrastructure.ViewModels
{
    [Validator(typeof(RegisterUserViewModelValidator))]
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string EmailAddress { get; set; }

        public decimal WalletAmount { get; set; }
    }
}