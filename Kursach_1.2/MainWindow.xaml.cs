using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.IO;
using System.Data.Entity.Validation;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public System.Drawing.Image Image1 { get; set; }
        public byte[] imageData1;
        public byte[] imageData2;
        public byte[] imageData3;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            
            using(UserContext db = new UserContext())
            {
                if (!db.Users.Any(u => u.Login == "thanatos"))
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(@"D:\Work\Labs\Labs 4\ООП\КП-бэкап\Kursach_1.2\Cars\Mustang.jpg", FileMode.Open))
                    {
                        imageData1 = new byte[fs.Length];
                        fs.Read(imageData1, 0, imageData1.Length);
                    }

                    using (System.IO.FileStream fs = new System.IO.FileStream(@"D:\Work\Labs\Labs 4\ООП\КП-бэкап\Kursach_1.2\no_image.jpg", FileMode.Open))
                    {
                        imageData2 = new byte[fs.Length];
                        fs.Read(imageData2, 0, imageData2.Length);
                    }

                    using (System.IO.FileStream fs = new System.IO.FileStream(@"D:\Work\Labs\Labs 4\ООП\КП-бэкап\Kursach_1.2\Cars\Golf.jfif", FileMode.Open))
                    {
                        imageData3 = new byte[fs.Length];
                        fs.Read(imageData3, 0, imageData3.Length);
                    }


                    Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes("donatos", 8, 25);
                    byte[] hashedPassword1 = PBKDF2.GetBytes(20);
                    byte[] salt1 = PBKDF2.Salt;

                    Rfc2898DeriveBytes PBKDF3 = new Rfc2898DeriveBytes("thanatos", 8, 25);
                    byte[] hashedPassword2 = PBKDF3.GetBytes(20);
                    byte[] salt2 = PBKDF3.Salt;


                    Promocode promo = new Promocode { Value = null, Effect = null };
                    Promocode promo1 = new Promocode { Value = "holidays30", Effect = "Скидка 30%"};
                    Promocode promo2 = new Promocode { Value = "happy10", Effect = "Скидка 10%"};
                    Promocode promo3 = new Promocode { Value = "freerent", Effect = "1 прокат"};


                    Review rev1 = new Review { Text = null };
                    Review rev2 = new Review { Text = "Очень красивое и удобное приложение." };


                    Car car1 = new Car
                    {
                        Image = imageData2,
                        EngineVolume = 0,
                        Mileage = 0,
                        Price = 0,
                        IsAvailable = false
                    };


                    Car car2 = new Car
                    {
                        Image = imageData1,
                        Name = "Ford",
                        Model = "Mustang GT",
                        Description = "Очень хороший автомобиль. Крайне привлекательный внешний вид, большая мощность. Своих денег стоит.",
                        EngineVolume = 5,
                        ReleaseDate = "23.04.2015",
                        Category = "Спортивные",
                        Color = "Серебристый",
                        Mileage = 25158,
                        Price = 250,
                        IsAvailable = true
                    };


                    Car car3 = new Car
                    {
                        Image = imageData3,
                        Name = "Volkswagen",
                        Model = "Golf GTI 8 Series",
                        Description = "Очень хороший автомобиль. Крайне привлекательный внешний вид, большая мощность. Своих денег стоит.",
                        EngineVolume = 2,
                        ReleaseDate = "21.09.2017",
                        Category = "Эконом",
                        Color = "Белый",
                        Mileage = 7530,
                        Price = 150,
                        IsAvailable = true
                    };


                    UserProfile userProfile1 = new UserProfile
                    {
                        FirstName = "Егор",
                        SecondName = "Сирош",
                        MiddleName = "Александрович",
                        PhoneNumber = "+375297322435",
                        DateOfBirth = "25.06.2001",
                        PassportSerialNumber = "HB1234567",
                        Email = "egor.thanatos@gmail.com",
                        RegistrationDate = "23.04.2020",
                        CountOfRentedCars = 0,
                        Admin = true
                    };

                    UserProfile userProfile2 = new UserProfile
                    {
                        FirstName = "Егор",
                        SecondName = "Сирош",
                        MiddleName = "Александрович",
                        PhoneNumber = "+375297322435",
                        DateOfBirth = "25.06.2001",
                        PassportSerialNumber = "HB1234567",
                        Email = "darkel.elite@mail.ru",
                        RegistrationDate = "23.04.2020",
                        CountOfRentedCars = 0,
                        Admin = false
                    };


                    User user1 = new User
                    {
                        Login = "thanatos",
                        Hash = hashedPassword1,
                        Salt = salt1,
                        UserProfile = userProfile1,
                        Car = car1,
                        Promocode = promo,
                        Review = rev1
                    };

                    User user2 = new User
                    {
                        Login = "donatos",
                        Hash = hashedPassword2,
                        Salt = salt2,
                        UserProfile = userProfile2,
                        Car = car1,
                        Promocode = promo,
                        Review = rev2
                    };



                    db.Users.AddRange(new List<User> { user1, user2 });
                    db.UserProfiles.Add(userProfile1);
                    db.Cars.AddRange(new List<Car> { car1, car2, car3 });
                    db.Promocodes.AddRange(new List<Promocode> { promo, promo1, promo2, promo3 });
                    


                    try
                    {

                        db.SaveChanges();

                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                MessageBox.Show(err.ErrorMessage + "");
                            }
                        }
                    }
                }
                

            }

               
        }

        private void registerItem_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }
        private void loginItem_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Owner = this;
            login.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
