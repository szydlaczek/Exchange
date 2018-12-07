using Exchange.Infrastructure.Context;

namespace Exchange.Infrastructure.UseCases
{
    public abstract class UseCase
    {
        protected readonly ApplicationDbContext _context;

        protected UseCase(ApplicationDbContext useCase)
        {
            _context = useCase;
        }

        protected UseCase()
        {
        }
    }
}