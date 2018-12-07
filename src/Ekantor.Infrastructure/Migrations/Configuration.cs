namespace Exchange.Infrastructure.Migrations
{
    using Exchange.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exchange.Infrastructure.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Exchange.Infrastructure.Context.ApplicationDbContext context)
        {
            
            
        }
    }
}
