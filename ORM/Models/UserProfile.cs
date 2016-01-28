using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime BirthDate  { get; set; }

        public User User { get; set; }
    }
}