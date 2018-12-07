using Exchange.Infrastructure.UseCases;
using Exchange.Infrastructure.ViewModels;
using MediatR;

namespace Exchange.Infrastructure.Commands
{
    public class LogInCommand : IRequest<IRequestResult>
    {
        public LogInViewModel LogInViewModel { get; set; }
    }
}