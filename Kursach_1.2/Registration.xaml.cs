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
using System.Text.RegularExpressions;
using System.Data.Entity.Validation;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        MainWindow window = new MainWindow();
        public Registration()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;



        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            string bufs = firstNameTextbox.Text;
            char[] bufc = bufs.ToCharArray();
            foreach(char c in bufc)
            {
                if (c != '0' && c != '1'&& c != '2' && c != '3' && c != '4' && c != '5' && c != '6' && c != '7' && c != '8' && c != '9')
                {
                    firstNameErrorLabel.Visibility = Visibility.Hidden;
                }
                else
                {
                    firstNameErrorLabel.Visibility = Visibility.Visible;
                }
            }


            bufs = secondNameTextbox.Text;
            bufc = bufs.ToCharArray();
            foreach (char c in bufc)
            {
                if (c != '0' && c != '1' && c != '2' && c != '3' && c != '4' && c != '5' && c != '6' && c != '7' && c != '8' && c != '9')
                {
                    secondNameErrorLabel.Visibility = Visibility.Hidden;
                }
                else
                {
                    secondNameErrorLabel.Visibility = Visibility.Visible;
                }
            }


            bufs = middleNameTextbox.Text;
            bufc = bufs.ToCharArray();
            foreach (char c in bufc)
            {
                if (c != '0' && c != '1' && c != '2' && c != '3' && c != '4' && c != '5' && c != '6' && c != '7' && c != '8' && c != '9')
                {
                    middleNameErrorLabel.Visibility = Visibility.Hidden;
                }
                else
                {
                    middleNameErrorLabel.Visibility = Visibility.Visible;
                }
            }



            bufs = phoneNumberTextbox.Text;
            bufc = bufs.ToCharArray();
            foreach (char c in bufc)
            {
                if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '+')
                {
                    phoneNumberErrorLabel.Visibility = Visibility.Hidden;
                }
                else
                {
                    phoneNumberErrorLabel.Visibility = Visibility.Visible;
                }
            }



            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            bool isItEmail = Regex.IsMatch(emailTextbox.Text, emailPattern);

            if (!isItEmail)
            {
                emailErrorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                emailErrorLabel.Visibility = Visibility.Hidden;
            }


            using (UserContext db = new UserContext())
            {
                foreach(User u in db.Users.Include("UserProfile"))
                {
                    if(u.Login == loginTextbox.Text)
                    {
                        loginErrorLabel.Visibility = Visibility.Visible;
                    }
                }
            }


            if (firstNameErrorLabel.IsVisible == false && secondNameErrorLabel.IsVisible == false && middleNameErrorLabel.IsVisible == false && phoneNumberErrorLabel.IsVisible == false && emailErrorLabel.IsVisible == false && loginErrorLabel.IsVisible == false)
            {
                firstHash(passwordPasswordbox.Password, 25);
                this.Close();
            }


            


        }



        public void firstHash(string userPassword, int numberOfItterations)
        {
            using (UserContext db = new UserContext())
            {
                Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(userPassword, 8, numberOfItterations);
                byte[] hashedPassword = PBKDF2.GetBytes(20);
                byte[] salt = PBKDF2.Salt;

                
                UserProfile profile = new UserProfile {
                    FirstName = firstNameTextbox.Text,
                    SecondName = secondNameTextbox.Text,
                    MiddleName = middleNameTextbox.Text,
                    PhoneNumber = phoneNumberTextbox.Text,
                    DateOfBirth = dateOfBirthPicker.SelectedDate.GetValueOrDefault().ToShortDateString(),
                    PassportSerialNumber = passportSerialNumberTextbox.Text,
                    Email = emailTextbox.Text,
                    RegistrationDate = DateTime.Now.ToShortDateString(),
                    CountOfRentedCars = 0,
                    Admin = false
                };
                Car car = db.Cars.Where(c => c.Id == 1).FirstOrDefault();
                Promocode promo = db.Promocodes.Where(p => p.Id == 1).FirstOrDefault();
                Review rev = db.Reviews.Where(r => r.Id == 1).FirstOrDefault();
                User user = new User
                {
                    Login = loginTextbox.Text,
                    Hash = hashedPassword,
                    Salt = salt,
                    Car = car,
                    Promocode = promo,
                    Review = rev
                };
                profile.User = user;


                db.Users.Add(user);
                db.UserProfiles.Add(profile);
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
}
