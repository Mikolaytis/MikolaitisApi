using Mikolaitis.Api.Core.Utils;
using Mikolaitis.Api.Database.Entities;
using Mikolaitis.Api.Database.Extensions;

namespace Mikolaitis.Api.Database.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUsers : DbMigration
    {
        public override void Up()
        {
            using (var db = new MikolaitisApiDbContext())
            {
                var pass = new KeyDerivationFunction().HashPassword("aA12345");
                db.Users.Add(new UserEntity("Сергей", "sergey@apple.com", pass).AddAuth(5));
                db.Users.Add(new UserEntity("Василий", "vasiliy@apple.com", pass));
                db.Users.Add(new UserEntity("Петр", "petr@apple.com", pass));
                db.Users.Add(new UserEntity("Николай", "nikola@apple.com", pass));
                db.Users.Add(new UserEntity("Елена", "elena@apple.com", pass).AddAuth());
                db.Users.Add(new UserEntity("Алена", "alena@apple.com", pass));
                db.Users.Add(new UserEntity("Екатерина", "ekaterina@apple.com", pass));
                db.Users.Add(new UserEntity("Дарья", "daria@apple.com", pass));
                db.Users.Add(new UserEntity("Александр", "alexandr@apple.com", pass).AddAuth());
                db.Users.Add(new UserEntity("Михаил", "mikhail@apple.com", pass));
                db.Users.Add(new UserEntity("Артем", "artem@apple.com", pass));
                db.Users.Add(new UserEntity("Геннадий", "gennadiy@apple.com", pass).AddAuth(2));
                db.Users.Add(new UserEntity("Алексей", "alexey@apple.com", pass));
                db.Users.Add(new UserEntity("Джессика", "jessica@apple.com", pass));
                db.Users.Add(new UserEntity("Мария", "maria@apple.com", pass));
                db.Users.Add(new UserEntity("Наталья", "natali@apple.com", pass));
                db.Users.Add(new UserEntity("Владимир", "vladimir@apple.com", pass).AddAuth(22));
                db.Users.Add(new UserEntity("Руслан", "ruslan@apple.com", pass).AddAuth());
                db.Users.Add(new UserEntity("Виталий", "vitaliy@apple.com", pass).AddAuth(8));
                db.Users.Add(new UserEntity("Виктор", "victor@apple.com", pass));
                db.Users.Add(new UserEntity("Евгений", "yevgeniy@apple.com", pass));
                db.Users.Add(new UserEntity("Никита", "nikita@apple.com", pass));
                db.Users.Add(new UserEntity("Ангелина", "angelina@apple.com", pass));
                db.Users.Add(new UserEntity("Надежда", "nadezhda@apple.com", pass));
                db.Users.Add(new UserEntity("Стас", "stas@apple.com", pass).AddAuth());
                db.Users.Add(new UserEntity("Зоя", "zoya@apple.com", pass));
                db.Users.Add(new UserEntity("Андрей", "andrey@apple.com", pass));
                db.Users.Add(new UserEntity("Оля", "olya@apple.com", pass));
                db.Users.Add(new UserEntity("Максим", "maxim@apple.com", pass));
                db.Users.Add(new UserEntity("Дмитрий", "dmitriy@apple.com", pass).AddAuth(2));
                db.Users.Add(new UserEntity("Люда", "lyuda@apple.com", pass).AddAuth());
                db.Users.Add(new UserEntity("Карина", "karina@apple.com", pass).AddAuth());
                db.Users.Add(new UserEntity("Зинаида", "zinaida@apple.com", pass).AddAuth());
                db.Users.Add(new UserEntity("Кристина", "kristina@apple.com", pass).AddAuth());
                db.Users.Add(new UserEntity("Гоша", "gosha@apple.com", pass).AddAuth());

                db.SaveChanges();
            }
        }

        public override void Down()
        {
        }
    }
}
