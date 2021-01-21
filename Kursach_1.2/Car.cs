using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kursach_1._2
{
    public class Car
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string ReleaseDate { get; set; }
        public int EngineVolume { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public double Price { get; set; }
        public string RentalDate { get; set; }
        public string ReturnDate { get; set; }
        public bool IsAvailable { get; set; }
        public List<User> Users { get; set; }
    }
}
