using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mikolaitis.Api.Authorization.Identity;
using Mikolaitis.Api.Core.Models;

namespace Mikolaitis.Api.Authorization.Tests.Stubs
{
    public class StubUserStore : ICustomUserStore<ApplicationUser>
    {
        public readonly List<ApplicationUser> Users = new List<ApplicationUser>();
        public bool IsApplyUserAuthorizationInvoked { get; private set; }

        public Task ApplyUserAuthorization(ApplicationUser user)
        {
            IsApplyUserAuthorizationInvoked = true;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Users.Clear();
        }

        public Task CreateAsync(ApplicationUser user)
        {
            Users.Add(user);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string login)
        {
            var user = Users.FirstOrDefault(x => x.Email.Equals(login, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(user);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.Password));
        }

        public Task SetEmailAsync(ApplicationUser user, string email)
        {
            user.Email = email;
            return Task.CompletedTask;
        }

        public Task<string> GetEmailAsync(ApplicationUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            var user = Users.FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(user);
        }
    }
}
