using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ProfileModel
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public List<Image> Photos { get; set; }
    }
}