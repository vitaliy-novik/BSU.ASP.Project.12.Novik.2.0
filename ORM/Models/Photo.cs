using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Models
{
    public class Photo
    {
        public Photo()
        {
            Likes = new HashSet<Like>();
        }

        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public DateTime LoadDate { get; set; }

        public User User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
