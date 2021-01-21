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

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для Remove_Admin.xaml
    /// </summary>
    public partial class Remove_Admin : Window
    {
        public Remove_Admin()
        {
            InitializeComponent();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                User buffer = new User();
                var ss = db.Users;
                foreach (User s in ss)
                {
                    if (s.Login == loginTextbox.Text)
                    {
                        s.UserProfile.Admin = false;
                        MessageBox.Show("Администратор удален");
                        break;
                    }
                    db.SaveChanges();
                }

                db.SaveChanges();
                this.Close();
            }

        }
    }
}
