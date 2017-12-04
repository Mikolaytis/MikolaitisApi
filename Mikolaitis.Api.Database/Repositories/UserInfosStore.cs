using System;
using System.Linq;
using Mikolaitis.Api.Core.Models;
using Mikolaitis.Api.Core.Services;

namespace Mikolaitis.Api.Database.Repositories
{
    public class UserInfosStore : RepositoryBase, IUserInfosStore
    {
        public IQueryable<UserInfo> GetUserInfos()
        {
            return Context.Users
                .Select(x=> new UserInfo
                {
                    Id = x.Id.ToString(),
                    UserName = x.UserName,
                    AuthorizationsCount = x.UserAuthorizations.Count,
                    LastAuthorizationDate = x.UserAuthorizations
                        .OrderByDescending(a => a.AuthorizationDate)
                        .Select(a=>a.AuthorizationDate)
                        .Cast<DateTime?>()
                        .FirstOrDefault()
                })
                .AsQueryable();
        }
    }
}
