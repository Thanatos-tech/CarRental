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
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Data.Entity;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для Add_Admin.xaml
    /// </summary>
    public partial class Add_User : Window
    {
        List<FullUser> list = new List<FullUser>();
        public Add_User()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var x = (CarRental_Adm)this.Owner;
            bool flag = false;
            if (adminCheckbox.IsChecked == true)
            {
                flag = true;
            }

            if (x.editFlag)
            {
                try
                {

                    UserProfile u = new UserProfile()
                    {
                        FirstName = firstNameTextbox.Text,
                        SecondName = secondNameTextbox.Text,
                        MiddleName = middleNameTextbox.Text,
                        PhoneNumber = phoneNumberTextbox.Text,
                        DateOfBirth = dateOfBirthPicker.SelectedDate.GetValueOrDefault().ToShortDateString(),
                        PassportSerialNumber = passportSerialNumberTextbox.Text,
                        Email = emailTextbox.Text,
                        Admin = flag
                    };

                    using (UserContext db = new UserContext())
                    {
                        foreach(User user in db.Users.Include("UserProfile"))
                        {
                            list.Add(new FullUser
                            {
                                Login = user.Login,
                                Hash = user.Hash,
                                Salt = user.Salt,
                                FirstName = user.UserProfile.FirstName,
                                SecondName = user.UserProfile.SecondName,
                                MiddleName = user.UserProfile.MiddleName,
                                PhoneNumber = user.UserProfile.PhoneNumber,
                                DateOfBirth = user.UserProfile.DateOfBirth,
                                PassportSerialNumber = user.UserProfile.PassportSerialNumber,
                                Email = user.UserProfile.Email,
                                RegistrationDate = user.UserProfile.RegistrationDate,
                                CountOfRentedCars = user.UserProfile.CountOfRentedCars,
                                Admin = user.UserProfile.Admin
                            });
                        }
                        foreach (User us in db.Users.Include("UserProfile"))
                        {
                            if (us.Login == list[x.usersDatagrid.SelectedIndex].Login)
                            {
                                us.UserProfile.FirstName = u.FirstName;
                                us.UserProfile.SecondName = u.SecondName;
                                us.UserProfile.MiddleName = u.MiddleName;
                                us.UserProfile.PhoneNumber = u.PhoneNumber;
                                us.UserProfile.DateOfBirth = u.DateOfBirth;
                                us.UserProfile.PassportSerialNumber = u.PassportSerialNumber;
                                us.UserProfile.Email = u.Email;
                                us.UserProfile.Admin = u.Admin;
                            }
                        }
                        db.SaveChanges();
                        x.refreshButton_Click(this, null);
                    }

                    x.editFlag = false;
                    this.Close();
                    return;
                }
                catch
                {
                    MessageBox.Show("Выберите пользователя");
                }
                
            }
            else
            {
                using (UserContext db = new UserContext())
                {
                    Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(passwordPasswordbox.Password, 8, 25);
                    byte[] hashedPassword = PBKDF2.GetBytes(20);
                    byte[] salt = PBKDF2.Salt;

                    User user = new User();
                    UserProfile profile = new UserProfile();
                    Car car = db.Cars.Where(c => c.Id == 1).FirstOrDefault();
                    Promocode promo = db.Promocodes.Where(p => p.Id == 1).FirstOrDefault();
                    Review rev = db.Reviews.Where(r => r.Id == 1).FirstOrDefault();

                    user.Login = loginTextbox.Text;
                    user.Hash = hashedPassword;
                    user.Salt = salt;
                    user.Car = car;
                    user.Promocode = promo;
                    user.Review = rev;


                    profile.FirstName = firstNameTextbox.Text;
                    profile.SecondName = secondNameTextbox.Text;
                    profile.MiddleName = middleNameTextbox.Text;
                    profile.PhoneNumber = phoneNumberTextbox.Text;
                    profile.DateOfBirth = dateOfBirthPicker.SelectedDate.GetValueOrDefault().ToShortDateString();
                    profile.PassportSerialNumber = passportSerialNumberTextbox.Text;
                    profile.Email = emailTextbox.Text;
                    profile.Admin = flag;
                    profile.RegistrationDate = DateTime.Now.ToShortDateString();
                    profile.CountOfRentedCars = 0;
                    profile.User = user;



                    db.Users.Add(user);
                    db.UserProfiles.Add(profile);
                    db.SaveChanges();

                    x.refreshButton_Click(this, null);
                }
                this.Close();
                return;
            }
        }
    }
}
