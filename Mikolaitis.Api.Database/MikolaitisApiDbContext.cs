using System.Data.Entity;
using Mikolaitis.Api.Database.Entities;
using Mikolaitis.Api.Database.Migrations;

namespace Mikolaitis.Api.Database
{
    public class MikolaitisApiDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserAuthorizationEntity> UserAuthorizations { get; set; }

        public MikolaitisApiDbContext() : 
            base(@"Server=.\SQLEXPRESS;Database=MikolaitisApiDB;Integrated Security=True;MultipleActiveResultSets=true;")
        {
            Configuration.LazyLoadingEnabled = true;
            //System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<MikolaitisApiDbContext>());
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<MikolaitisApiDbContext, Configuration>());
        }
    }
}
