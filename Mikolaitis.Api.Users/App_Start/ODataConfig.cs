using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Mikolaitis.Api.Core.Models;

namespace Mikolaitis.Api.Users
{
    public class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<UserInfo>("Users");
            config.MapODataServiceRoute("odata", null, builder.GetEdmModel());
            config.EnsureInitialized();
        }
    }
}