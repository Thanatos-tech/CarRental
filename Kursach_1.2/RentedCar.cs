using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1._2
{
    public class RentedCar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Login { get; set; }
        public DateTime OrderDate { get; set; }
        public int HoursCount { get; set; }
    }
}
