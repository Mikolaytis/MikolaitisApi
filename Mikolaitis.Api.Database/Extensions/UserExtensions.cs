using Mikolaitis.Api.Database.Entities;

namespace Mikolaitis.Api.Database.Extensions
{
    public static class UserExtensions
    {
        public static UserEntity AddAuth(this UserEntity entity, int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                entity.UserAuthorizations.Add(new UserAuthorizationEntity());
            }
            return entity;
        }
    }
}
