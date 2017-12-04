using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Mikolaitis.Api.Authorization;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Mikolaitis.Api.Authorization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}