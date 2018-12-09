using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Exchange.Core.Models
{
    public class User : IUser, ISellCurrency, IBuyCurrency
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual UserWallet Wallet { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }

        public async Task<IOperationResult> BuyCurrency(Currency currency, int value)
        {
            var price = (decimal)((value / currency.Unit) * currency.GetLastSellValue());
            if (Wallet.AmountPLN < price)
            {
                return new OperationResult(false, "You don't have enought money", null);
            }

            var walletCurrency = Wallet.Currencies.Where(c => c.CurrencyId == currency.Id).FirstOrDefault();
            if (walletCurrency == null)
            {
                Wallet.Currencies.Add(new UserWalletCurrency(currency, value));
            }
            else
            {
                walletCurrency.ChangeQuantity(value);
            }

            Wallet.SetAmount(-price);
            return await Task.FromResult(new OperationResult(true, string.Empty, null));
        }

        public async Task<IOperationResult> SellCurrency(Currency currency, int value)
        {
            var walletCurrency = Wallet.Currencies.Where(c => c.CurrencyId == currency.Id).FirstOrDefault();
            if (walletCurrency.Quantity < value)
                return new OperationResult(false, "You don't have enought currency", null);
            walletCurrency.ChangeQuantity(-value);
            var price = (value / currency.Unit) * currency.GetLastPurchaseValue();
            Wallet.SetAmount((decimal)price);
            return await Task.FromResult(new OperationResult(true, string.Empty, null));            
        }
    }
}