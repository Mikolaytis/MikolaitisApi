using System.Web.Http;
using Mikolaitis.Api.Core.Services;
using Mikolaitis.Api.Database.Repositories;
using Unity;
using Unity.Lifetime;

namespace Mikolaitis.Api.Users
{
    public class DiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IUserInfosStore, UserInfosStore>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}