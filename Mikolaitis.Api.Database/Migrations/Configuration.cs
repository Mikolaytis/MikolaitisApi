using System.Data.Entity.Migrations;

namespace Mikolaitis.Api.Database.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MikolaitisApiDbContext>
    {
        protected override void Seed(MikolaitisApiDbContext context)
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
