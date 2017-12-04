using System;
using System.Threading.Tasks;
using Mikolaitis.Api.Core.Models;
using Mikolaitis.Api.Core.Services;

namespace Mikolaitis.Api.Authorization.Identity
{
    public class CustomUserStore : ICustomUserStore<ApplicationUser>
    {
        private readonly IUsersAuthorizationStore _usersAuthorizationStore;
        public CustomUserStore(IUsersAuthorizationStore usersAuthorizationStore)
        {
            _usersAuthorizationStore = usersAuthorizationStore;
        }

        public void Dispose()
        {
            _usersAuthorizationStore.Dispose();
        }

        public Task CreateAsync(ApplicationUser applicationUser)
        {
            return _usersAuthorizationStore.RegisterUser(applicationUser);
        }

        public Task<ApplicationUser> FindByNameAsync(string login)
        {
            return _usersAuthorizationStore.GetUserByLogin(login);
        }

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return _usersAuthorizationStore.GetUserByLogin(email);
        }

        public Task<string> GetEmailAsync(ApplicationUser user)
        {
            return Task.FromResult(user.Email);
        }
        
        public Task ApplyUserAuthorization(ApplicationUser user)
        {
            return _usersAuthorizationStore.ApplyUserAuthorization(user);
        }

        #region PasswordStore
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
        #endregion

        #region NotImplemented
        public Task UpdateAsync(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
        
        public Task SetEmailAsync(ApplicationUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}