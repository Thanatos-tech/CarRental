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
    /// Логика взаимодействия для All_Admins.xaml
    /// </summary>
    public partial class All_Admins : Window
    {
        public All_Admins()
        {
            InitializeComponent();

            using (UserContext db = new UserContext())
            {
                List<User> users = new List<User>();
                foreach (User u in db.Users)
                {
                    if (u.UserProfile.Admin == true)
                    {
                        users.Add(u);
                    }
                }

                adminsDatagrid.ItemsSource = users;
                adminsDatagrid.Items.Refresh();
            }
        }
    }
}
