using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.UseCases
{
    public class LogOffUseCase : UseCase, IUseCase
    {
        private readonly IAuthenticationManager _authenticationManager;
        public LogOffUseCase(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        public Task LogOff()
        {
            _authenticationManager.SignOut();
            return Task.CompletedTask;
        }
    }
}
