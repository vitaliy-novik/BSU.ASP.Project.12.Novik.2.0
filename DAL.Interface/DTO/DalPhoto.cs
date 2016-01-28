using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalPhoto : IEntity
    {
        
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public DateTime LoadDate { get; set; }

        public int UserId { get; set; }

        public List<DalLike> Likes { get; set; }
        public int LikesCount { get; set; }
    }
}
