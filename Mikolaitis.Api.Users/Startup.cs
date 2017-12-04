using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Mikolaitis.Api.Users;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Mikolaitis.Api.Users
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            var config = new HttpConfiguration();
            DiConfig.Register(config);
            ODataConfig.Register(config);
            WebApiConfig.Register(config);
            FilterConfig.Register(config.Filters);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

    }
}