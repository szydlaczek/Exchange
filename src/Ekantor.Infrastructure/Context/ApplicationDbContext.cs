using Exchange.Core.Models;
using System.Data.Entity;

namespace Exchange.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyValue> CurrencyValues { get; set; }
        public DbSet<SystemWallet> SystemWallet { get; set; }
        public DbSet<SystemWalletCurrency> SystemWalletCurrencies { get; set; }
        public DbSet<UserWallet> UserWallets { get; set; }
        public DbSet<UserWalletCurrency> UserWalletCurrencies { get; set; }

        public ApplicationDbContext() : base("Exchange")
        {
            if (!Database.Exists())
                Database.SetInitializer(new ExchangeDbInitializer());
        }
    }
}