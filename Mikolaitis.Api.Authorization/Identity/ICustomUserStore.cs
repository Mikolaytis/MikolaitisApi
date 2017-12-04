using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Mikolaitis.Api.Authorization.Identity
{
    public interface ICustomUserStore<TUser> :
        IUserStore<TUser>,
        IUserPasswordStore<TUser>,
        IUserEmailStore<TUser>
        where TUser : class, IUser<string>
    {
        Task ApplyUserAuthorization(TUser user);
    }
}
