using ORM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer(new DataContextInitializer());
        }
        public DataContext()
            : base("DataContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
