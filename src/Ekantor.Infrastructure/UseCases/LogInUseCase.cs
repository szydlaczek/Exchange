using Exchange.Infrastructure.Context;
using Exchange.Infrastructure.Identity;
using Exchange.Infrastructure.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class LogInUseCase : UseCase, IUseCase
    {
        private readonly ApplicationSignInManager _signInManager;

        public LogInUseCase(ApplicationSignInManager signInManager, ApplicationDbContext context) : base(context)
        {
            _signInManager = signInManager;
        }

        public async Task<IRequestResult> Login(LogInViewModel logInViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(logInViewModel.UserName, logInViewModel.Password, false, false);
            if (result == SignInStatus.Success)
                return new RequestResult(true, null, null);
            else
                return new RequestResult(false, new List<string>() { "Bad username or password" }, null);
        }
    }
}