using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace ORMTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext db = new DataContext();
            foreach (var item in db.Roles)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
