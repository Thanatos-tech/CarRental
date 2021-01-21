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
    /// Логика взаимодействия для CarRental_Admin.xaml
    /// </summary>
    public partial class CarRental_Admin : Window
    {
        public CarRental_Admin()
        {
            InitializeComponent();
        }

        private void addAdminButton_Click(object sender, RoutedEventArgs e)
        {
            //Add_Admin add = new Add_Admin();
            //add.Show();
        }

        private void removeAdminButton_Click(object sender, RoutedEventArgs e)
        {
            Remove_Admin remove = new Remove_Admin();
            remove.Show();
        }

        private void allAdminsButton_Click(object sender, RoutedEventArgs e)
        {
            All_Admins admins = new All_Admins();
            admins.Show();
        }

        private void addPromoButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Promocode promo = new Add_Promocode();
            promo.Show();
        }

        private void removePromoButton_Click(object sender, RoutedEventArgs e)
        {
            Remove_Promocode rem = new Remove_Promocode();
            rem.Show();
        }

        private void allUsersLabel_Click(object sender, RoutedEventArgs e)
        {
            UserInfo info = new UserInfo();
            info.Show();
        }

        private void addCarButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Car car = new Add_Car();
            car.Owner = this;
            car.Show();
        }

        private void removeCarButton_Click(object sender, RoutedEventArgs e)
        {
            Remove_Car car = new Remove_Car();
            car.Show();
        }

        private void editCarButton_Click(object sender, RoutedEventArgs e)
        {
            Edit_Car car = new Edit_Car();
            car.Show();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();

            this.Close();
        }
    }
}
