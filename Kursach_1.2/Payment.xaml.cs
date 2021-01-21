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
using System.Text.RegularExpressions;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Payment : Window
    {
        public Car currentCar = new Car();
        public Payment()
        {
            InitializeComponent();
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            var v = (Order)this.Owner;

            //using (UserContext db = new UserContext())
            //{
            //    Car rentedCar = db.Cars.Where(c => c.Id == currentCar.Id).FirstOrDefault();

            //    foreach (User u in db.Users.Include("UserProfile"))
            //    {

            //        if (u.Login == v.us.Login)
            //        {
            //            u.UserProfile.CountOfRentedCars++;
            //            v.us.CountOfRentedCars++;
            //            u.Car = rentedCar;
            //            u.Car.RentalDate = DateTime.Now.ToShortDateString();
            //            u.Car.ReturnDate = DateTime.Now.AddDays(daysCount).ToShortDateString();
            //            rentedCar.IsAvailable = false;
            //        }
            //    }

            //    db.SaveChanges();
            //}

            //MessageBox.Show("Вы успешно оформили арендовали автомобиль! \nВсе подробности об аренде были отправлены на вашу почту.");

            //using (UserContext db = new UserContext())
            //{
            //    List<Car> forGrid = new List<Car>();
            //    foreach (Car c in db.Cars)
            //    {
            //        if (c.Id != 1)
            //        {
            //            if (c.IsAvailable == true)
            //            {
            //                forGrid.Add(c);
            //            }
            //        }

            //    }
            //    v.carbGrid.ItemsSource = forGrid;
            //    v.carbGrid.Items.Refresh();
            //}


            Order order = new Order();
            order.Close();

        }
    }
}
