using System.Linq;
using System.Web.OData;
using Mikolaitis.Api.Core.Models;
using Mikolaitis.Api.Core.Services;

namespace Mikolaitis.Api.Users.Controllers
{

    public class UsersController : ODataController
    {
        private const string UsersSort = nameof(UserInfo.UserName) + "," +
                                         nameof(UserInfo.AuthorizationsCount) + "," +
                                         nameof(UserInfo.LastAuthorizationDate);

        private readonly IUserInfosStore _userInfosStore;
        public UsersController(IUserInfosStore usersAuthorizationStore)
        {
            _userInfosStore = usersAuthorizationStore;
        }

        [EnableQuery(AllowedOrderByProperties = UsersSort, PageSize = 20)]
        public IQueryable<UserInfo> Get()
        {
            return _userInfosStore.GetUserInfos();
        }
    }
}
