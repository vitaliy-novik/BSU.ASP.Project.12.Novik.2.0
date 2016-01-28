using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class UserPreviewModel
    {
        public const int PhotoCount = 4;

        public string Name { get; set; }

        public List<PhotoEntity> Photos { get; set; }
    }
}