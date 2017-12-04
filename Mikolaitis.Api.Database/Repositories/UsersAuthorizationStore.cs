using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Mikolaitis.Api.Core.Models;
using Mikolaitis.Api.Core.Services;
using Mikolaitis.Api.Database.Entities;

namespace Mikolaitis.Api.Database.Repositories
{
    public class UsersAuthorizationStore : RepositoryBase, IUsersAuthorizationStore
    {
        public Task RegisterUser(ApplicationUser user)
        {
            Context.Users.Add(new UserEntity
            {
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName
            });
            return Context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserByLogin(string login)
        {
            var user = await Context.Users
                .FirstOrDefaultAsync(x =>
                    x.Email.Equals(login, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                return null;
            }

            return new ApplicationUser
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName
            };
        }

        public async Task ApplyUserAuthorization(ApplicationUser user)
        {
            var foundUser = await Context.Users
                .FirstOrDefaultAsync(x =>
                    x.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase));

            if (foundUser != null)
            {
                foundUser.UserAuthorizations.Add(new UserAuthorizationEntity());
                await Context.SaveChangesAsync();
            }
        }
    }
}
