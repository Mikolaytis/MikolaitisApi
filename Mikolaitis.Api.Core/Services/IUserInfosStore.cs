using System.Linq;
using Mikolaitis.Api.Core.Models;

namespace Mikolaitis.Api.Core.Services
{
    /// <summary>
    /// Repository of users
    /// </summary>
    public interface IUserInfosStore
    {
        /// <summary>
        /// Returns IQueryable for OData
        /// </summary>
        IQueryable<UserInfo> GetUserInfos();
    }
}