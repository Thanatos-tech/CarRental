using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1._2
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }

        [Required]
        public UserProfile UserProfile { get; set; }

        [Required]
        public Car Car { get; set; }

        [Required]
        public Promocode Promocode { get; set; }

        [Required]
        public Review Review { get; set; }

    }

    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string PassportSerialNumber { get; set; }
        public string Email { get; set; }
        public string RegistrationDate { get; set; }
        public int CountOfRentedCars { get; set; }
        
        //public string LastRentedCar { get; set; }
        public bool Admin { get; set; }
        public User User { get; set; }
    }
}
