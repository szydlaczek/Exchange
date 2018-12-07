using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.UseCases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, IRequestResult>
    {
        private readonly RegisterUserUseCase _useCase;

        public RegisterUserHandler(RegisterUserUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<IRequestResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _useCase.RegisterUser(request.NewUser);
        }
    }
}