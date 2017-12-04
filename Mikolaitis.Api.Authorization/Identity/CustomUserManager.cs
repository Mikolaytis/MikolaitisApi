using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Mikolaitis.Api.Core.Models;

namespace Mikolaitis.Api.Authorization.Identity
{
    public class CustomUserManager : UserManager<ApplicationUser>
    {
        private readonly ICustomUserStore<ApplicationUser> _store;

        public CustomUserManager(ICustomUserStore<ApplicationUser> store)
            : base(store)
        {
            _store = store;
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            PasswordHasher = new CustomPasswordHasher();
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };
        }

        public override async Task<ApplicationUser> FindAsync(string userName, string password)
        {
            var user = await base.FindAsync(userName, password);
            if (user != null)
            {
                await _store.ApplyUserAuthorization(user);
            }
            return user;
        }
    }
}