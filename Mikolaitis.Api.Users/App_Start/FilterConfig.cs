using System.Web.Http;
using System.Web.Http.Filters;
using Microsoft.Owin.Security.OAuth;

namespace Mikolaitis.Api.Users
{
    public class FilterConfig
    {
        public static void Register(HttpFilterCollection filters)
        {
            filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            filters.Add(new AuthorizeAttribute());
        }
    }
}