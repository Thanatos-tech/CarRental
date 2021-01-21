using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach_1._2
{
    public class FullUser
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string PassportSerialNumber { get; set; }
        public string Email { get; set; }
        public string RegistrationDate { get; set; }
        public int CountOfRentedCars { get; set; }
        public string Promocode { get; set; }
        public bool Admin { get; set; }
    }
}
