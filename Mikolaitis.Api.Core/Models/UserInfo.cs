using System;

namespace Mikolaitis.Api.Core.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public DateTime? LastAuthorizationDate { get; set; }
        public int AuthorizationsCount { get; set; }
    }
}
