using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class LoadPhotoModel
    {
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}