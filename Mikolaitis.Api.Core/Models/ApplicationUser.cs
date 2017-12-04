using Microsoft.AspNet.Identity;

namespace Mikolaitis.Api.Core.Models
{
    public class ApplicationUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}