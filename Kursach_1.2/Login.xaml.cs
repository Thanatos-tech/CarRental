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
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    /// 

    
    public partial class Login : Window
    {



        //public string login = "";
        public bool isAdmin = false;
        public FullUser authorizedUser = new FullUser();
        public Login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        private void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            ForgetPassword f = new ForgetPassword();
            f.Owner = this.Owner;
            f.Show();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            
            using (UserContext db = new UserContext())
            {
                bool flag = checkPassword(passwordPasswordbox.Password, 25);

                if (flag)
                {
                    if (isAdmin)
                    {
                        CarRental_Adm admin = new CarRental_Adm();

                        admin.Show();
                        this.Owner.Close();
                        this.Close();
                        return;
                    }
                    if (!isAdmin)
                    {
                        CarRental_User user = new CarRental_User();
                        user.welcomeLabel.Content = "Добро пожаловать, " + authorizedUser.FirstName;
                        user.us = authorizedUser;

                        foreach(User u in db.Users.Include("Promocode"))
                        {
                            if(u.Login == authorizedUser.Login)
                            {
                                if(u.Promocode.Id != 1)
                                {
                                    user.usedPromoLabel.Content = "Активный промокод: " + u.Promocode.Effect;
                                    if (u.Promocode.Effect == "Скидка 10%")
                                    {
                                        foreach (Car c in user.cars)
                                        {
                                            c.Price *= 0.9;
                                        }
                                    }
                                    else if (u.Promocode.Effect == "Скидка 20%")
                                    {
                                        foreach (Car c in user.cars)
                                        {
                                            c.Price *= 0.8;
                                        }
                                    }
                                    else if (u.Promocode.Effect == "Скидка 30%")
                                    {
                                        foreach (Car c in user.cars)
                                        {
                                            c.Price *= 0.7;
                                        }
                                    }
                                    else if (u.Promocode.Effect == "1 прокат")
                                    {
                                        foreach (Car c in user.cars)
                                        {
                                            c.Price = 0;
                                        }
                                    }
                                    user.carbGrid.Items.Refresh();
                                }
                            }
                        }

                        //if (authorizedUser.Promocode != null)
                        //{
                        //    Promocode promo = db.Promocodes.Where(p => p.Value == authorizedUser.Promocode).FirstOrDefault();
                        //    if (promo != null)
                        //    {
                        //        user.usedPromoLabel.Content = "Активный промокод: " + promo.Effect;

                        //        if (promo.Effect == "Скидка 10%")
                        //        {
                        //            foreach (Car c in user.cars)
                        //            {
                        //                c.Price *= 0.9;
                        //            }
                        //        }
                        //        else if (promo.Effect == "Скидка 20%")
                        //        {
                        //            foreach (Car c in user.cars)
                        //            {
                        //                c.Price *= 0.8;
                        //            }
                        //        }
                        //        else if (promo.Effect == "Скидка 30%")
                        //        {
                        //            foreach (Car c in user.cars)
                        //            {
                        //                c.Price *= 0.7;
                        //            }
                        //        }
                        //        else if (promo.Effect == "1 прокат")
                        //        {
                        //            foreach (Car c in user.cars)
                        //            {
                        //                c.Price = 0;
                        //            }
                        //        }
                        //        user.carbGrid.Items.Refresh();
                        //    }
                        //}

                        user.firstNameTextbox.Text = authorizedUser.FirstName;
                        user.secondNameTextbox.Text = authorizedUser.SecondName;
                        user.middleNameTextbox.Text = authorizedUser.MiddleName;
                        user.phoneNumberTextbox.Text = authorizedUser.PhoneNumber;
                        user.birthDatePicker.SelectedDate = Convert.ToDateTime(authorizedUser.DateOfBirth);
                        user.passportNumberTextbox.Text = authorizedUser.PassportSerialNumber;
                        user.emailTextbox.Text = authorizedUser.Email;
                        user.LoginLabel.Content = authorizedUser.Login;
                        user.RegistrationDateLabel.Content = authorizedUser.RegistrationDate;
                        user.RentedCarsCountLabel.Content = authorizedUser.CountOfRentedCars;

                        db.SaveChanges();

                        user.Show();

                        foreach (User u in db.Users.Include("UserProfile").Include("Car"))
                        {
                            if (u.Login == authorizedUser.Login)
                            {
                                if(u.Car.Id != 1)
                                {
                                    if (Convert.ToDateTime(u.Car.ReturnDate) < DateTime.Now)
                                    {
                                        MessageBox.Show("Уважаемый пользователь!" + "\n"
                                            + "Мы вынуждены сообщить Вам о том, что срок Вашей последней аренды автомобиля истек и вы не вернули его вовремя." + "\n"
                                            + "В связи с этим в дальнейшем Вы не сможете пользоваться данным приложением до тех пор, пока не погасите задолженность.");

                                        user.Ban();

                                    }
                                    else if (Convert.ToDateTime(u.Car.ReturnDate).Day >= DateTime.Now.Day)
                                    {
                                        user.returnCarButton.Visibility = Visibility.Visible;
                                        user.returnCarButton.IsEnabled = true;
                                    }
                                }
                            }
                        }

                        this.Owner.Close();
                        this.Close();
                        return;
                    }
                }

                MessageBox.Show("Неверный логин или пароль");
            }
        }



        public bool checkPassword(string userPassword, int numberOfItterations)
        {
            UserContext db = new UserContext();

            foreach (User user in db.Users.Include("UserProfile").ToList())
            {
                byte[] userHash = user.Hash;
                byte[] userSalt = user.Salt;

                Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(userPassword, userSalt, numberOfItterations);

                byte[] hashedPassword = PBKDF2.GetBytes(20);

                bool passwordsMach = userHash.SequenceEqual(hashedPassword);

                if (passwordsMach)
                {
                    authorizedUser.Login = user.Login;
                    authorizedUser.Hash = user.Hash;
                    authorizedUser.Salt = user.Salt;
                    authorizedUser.FirstName = user.UserProfile.FirstName;
                    authorizedUser.SecondName = user.UserProfile.SecondName;
                    authorizedUser.MiddleName = user.UserProfile.MiddleName;
                    authorizedUser.PhoneNumber = user.UserProfile.PhoneNumber;
                    authorizedUser.DateOfBirth = user.UserProfile.DateOfBirth;
                    authorizedUser.PassportSerialNumber = user.UserProfile.PassportSerialNumber;
                    authorizedUser.Email = user.UserProfile.Email;
                    authorizedUser.RegistrationDate = user.UserProfile.RegistrationDate;
                    authorizedUser.CountOfRentedCars = user.UserProfile.CountOfRentedCars;
                    authorizedUser.Admin = user.UserProfile.Admin;



                    CarRental_User rent = new CarRental_User();
                    rent.us = authorizedUser;

                    if (user.UserProfile.Admin)
                    {
                        isAdmin = true;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
