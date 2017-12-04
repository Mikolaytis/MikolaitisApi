using System;
using System.Threading.Tasks;
using Mikolaitis.Api.Core.Models;

namespace Mikolaitis.Api.Core.Services
{
    /// <summary>
    /// Repository for users authorization
    /// </summary>
    public interface IUsersAuthorizationStore : IDisposable
    {
        /// <summary>
        /// Adds user to repository
        /// </summary>
        Task RegisterUser(ApplicationUser user);

        /// <summary>
        /// Returns a user with provided login if it exists
        /// </summary>
        Task<ApplicationUser> GetUserByLogin(string login);

        /// <summary>
        /// Adds authorization record for that user
        /// </summary>
        Task ApplyUserAuthorization(ApplicationUser user);
    }
}
