using Exchange.Core.Models;
using Exchange.Infrastructure.Context;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Identity
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>, IUserRoleStore<User>, IUserLockoutStore<User, string>, IUserTwoFactorStore<User, string>, IUserEmailStore<User>
    {
        private readonly ApplicationDbContext _context;

        public UserStore(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            _context.Users.Add(user);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            var user=_context.Users.Where(u => u.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            return Task.FromResult(user);
        }

        public Task<User> FindByIdAsync(string userId)
        {
            var user = _context.Users
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.Id == userId);
            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var user = _context.Users.Where(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            return Task.FromResult(user);
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(User user)
        {
            var email = user.EmailAddress;
            return Task.FromResult(email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            var passwordHash = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault().Password;
            return Task.FromResult(passwordHash);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            var roles = user.Roles.Select(r => r.Name).ToList<string>();
            return Task.FromResult((IList<string>)roles);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(User user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return Task.CompletedTask;
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}