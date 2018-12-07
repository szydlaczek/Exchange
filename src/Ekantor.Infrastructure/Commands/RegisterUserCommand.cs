using Exchange.Infrastructure.UseCases;
using Exchange.Infrastructure.ViewModels;
using MediatR;

namespace Exchange.Infrastructure.Commands
{
    public class RegisterUserCommand : IRequest<IRequestResult>
    {
        public RegisterViewModel NewUser { get; set; }
    }
}