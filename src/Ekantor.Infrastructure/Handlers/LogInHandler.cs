using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.UseCases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Handlers
{
    public class LogInHandler : IRequestHandler<LogInCommand, IRequestResult>
    {
        private readonly LogInUseCase _useCase;

        public LogInHandler(LogInUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<IRequestResult> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            return await _useCase.Login(request.LogInViewModel);
        }
    }
}