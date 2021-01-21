using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1._2
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public List<User> User { get; set; }
    }
}
