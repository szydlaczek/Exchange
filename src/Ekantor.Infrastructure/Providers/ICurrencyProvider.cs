using Exchange.Infrastructure.Dtos;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Providers
{
    public interface ICurrencyProvider
    {
        Task<CurrenciesDto> Download();
    }
}