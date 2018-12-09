using System.Threading.Tasks;

namespace Exchange.Core.Models
{
    public interface ISellCurrency
    {
        Task<IOperationResult> SellCurrency(Currency currency, int value);
    }

    public interface IBuyCurrency
    {
        Task<IOperationResult> BuyCurrency(Currency currency, int value);
    }
}