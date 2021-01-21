using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1._2
{
    public class Promocode
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Effect { get; set; }

        public List<User> Users { get; set; }

    }
}
