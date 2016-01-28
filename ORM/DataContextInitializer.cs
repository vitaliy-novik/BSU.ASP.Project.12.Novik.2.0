using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ORM
{
    class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext db)
        {
            db.Roles.Add(new Role { Name = "Administrator", Description = "Администратор" });
            db.Roles.Add(new Role { Name = "Moderator", Description = "Модератор" });
            db.Roles.Add(new Role { Name = "User", Description = "Пользователь" });
            db.Roles.Add(new Role { Name = "Guest", Description = "Гость" });
            
            base.Seed(db);
        }
    }
}
