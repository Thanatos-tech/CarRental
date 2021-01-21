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
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Net;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Window
    {
        public ForgetPassword()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void reestablishButton_Click(object sender, RoutedEventArgs e)
        {
            string buf1 = "";
            string buf2 = "";
            string buf3 = "";
            
            
            using (UserContext db = new UserContext())
            {
                try
                {
                    string buf = emailTextbox.Text;
                    foreach (User u in db.Users.Include("UserProfile"))
                    {
                        if (u.UserProfile.Email == buf)
                        {
                            string newpass = GeneratePass();

                            Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(newpass, 8, 25);
                            byte[] hashedPassword = PBKDF2.GetBytes(20);
                            byte[] salt = PBKDF2.Salt;
                            u.Hash = hashedPassword;
                            u.Salt = salt;

                            buf1 = u.UserProfile.FirstName;
                            buf2 = u.Login;
                            buf3 = newpass;
                        }
                    }
                    db.SaveChanges();

                    MailAddress from = new MailAddress("thanatos-0@yandex.by", "CarRental");
                    MailAddress to = new MailAddress(emailTextbox.Text);
                    MailMessage mess = new MailMessage(from, to);
                    mess.Subject = "Восстановление пароля";
                    mess.Body = "Добрый день, " + buf1 + "." + "\n" + "Вот ваш новый пароль от аккаунта " + buf2 + "." + "\n" + buf3;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.yandex.ru";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("thanatos-0@yandex.by", "fgo8vQeD");

                    smtp.Send(mess);

                    MessageBox.Show("Письмо с новым паролем было отправлено Вам на почту");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Аккаунт с данной почтой не существует.");
                }
                

            }
            
        }


        public string GeneratePass()
        {
            string iPass = "";
            string[] arr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "A", "E", "U", "Y", "a", "e", "i", "o", "u", "y" };
            Random rnd = new Random();
            for (int i = 0; i < 8; i = i + 1)
            {
                iPass = iPass + arr[rnd.Next(0, 57)];
            }
            return iPass;
        }

    }
}
