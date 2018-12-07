using Exchange.Core.Models;
using Exchange.Infrastructure.Context;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Identity
{
    public class RoleStore : IRoleStore<Role>
    {
        private readonly ApplicationDbContext _context;

        public RoleStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }
}