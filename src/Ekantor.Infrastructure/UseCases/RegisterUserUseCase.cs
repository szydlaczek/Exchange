using Exchange.Core.Models;
using Exchange.Infrastructure.Context;
using Exchange.Infrastructure.Identity;
using Exchange.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class RegisterUserUseCase : UseCase, IUseCase
    {
        private readonly ApplicationUserManager _applicationUserManager;

        public RegisterUserUseCase(ApplicationUserManager applicationUserManager, ApplicationDbContext context)
            : base(context)
        {
            _applicationUserManager = applicationUserManager;
        }

        public async Task<IRequestResult> RegisterUser(RegisterViewModel newUser)
        {
            var user = new User();
            user.Id = Guid.NewGuid().ToString();
            user.EmailAddress = newUser.EmailAddress;
            user.UserName = newUser.UserName;
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            UserWallet wallet = new UserWallet(1500);

            user.Wallet = wallet;
            var result = await _applicationUserManager.CreateAsync(user, newUser.Password);
            if (!result.Succeeded)
                return new RequestResult(false, result.Errors.ToList(), null);
            else
                return new RequestResult(true, new List<string>(), null);
        }
    }
}