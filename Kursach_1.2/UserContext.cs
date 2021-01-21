using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Kursach_1._2
{
    class UserContext : DbContext
    {
        public UserContext() : base("DbConnect") { }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
