using ORM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
            Photos = new HashSet<Photo>();
            Likes = new HashSet<Like>();
            Profile = new UserProfile();
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserProfile Profile { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

    }
}
