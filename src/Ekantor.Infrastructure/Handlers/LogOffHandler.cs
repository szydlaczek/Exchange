using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.UseCases;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Handlers
{
    public class LogOffHandler : AsyncRequestHandler<LogOffCommand>
    {
        private readonly LogOffUseCase _useCase;

        public LogOffHandler(LogOffUseCase useCase)
        {
            _useCase = useCase;
        }

        protected override async Task Handle(LogOffCommand request, CancellationToken cancellationToken)
        {
            await _useCase.LogOff();
        }
    }
}