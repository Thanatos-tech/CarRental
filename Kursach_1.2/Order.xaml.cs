using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Car currentCar = new Car();
        public int daysCount = 0;
        public string template = "";
        public string holTemplate = "";
        public bool holidaysFlag = false;



        public Order()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void durationCombobox_Selected(object sender, RoutedEventArgs e)
        {
            double num;
            

            if(durationCombobox.SelectedIndex == 0)
            {
                num = currentCar.Price;
                daysCount = 1;
                priceLabel.Content = "Итого: " + currentCar.Price + " BYN";
            }
            else if (durationCombobox.SelectedIndex == 1)
            {
                daysCount = 2;
                num = currentCar.Price * 2;
                priceLabel.Content = "Итого: " + currentCar.Price * 2 + " BYN";
            }
            else if (durationCombobox.SelectedIndex == 2)
            {
                daysCount = 3;
                num = currentCar.Price * 3;
                priceLabel.Content = "Итого: " + currentCar.Price * 3 + " BYN";
            }
            else if (durationCombobox.SelectedIndex == 3)
            {
                daysCount = 4;
                num = currentCar.Price * 4;
                priceLabel.Content = "Итого: " + currentCar.Price * 4 + " BYN";
            }
            else if (durationCombobox.SelectedIndex == 4)
            {
                daysCount = 5;
                num = currentCar.Price * 5;
                priceLabel.Content = "Итого: " + currentCar.Price * 5 + " BYN";
            }
            else if (durationCombobox.SelectedIndex == 5)
            {
                daysCount = 7;
                num = currentCar.Price * 6;
                priceLabel.Content = "Итого: " + currentCar.Price * 6 + " BYN";
            }
            else if (durationCombobox.SelectedIndex == 6)
            {
                daysCount = 14;
                num = currentCar.Price * 10;
                priceLabel.Content = "Итого: " + currentCar.Price * 10 + " BYN";
            }
            else if (durationCombobox.SelectedIndex == 7)
            {
                daysCount = 30;
                num = currentCar.Price * 18;
                priceLabel.Content = "Итого: " + currentCar.Price * 18 + " BYN";
            }
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            var v = (CarRental_User)this.Owner;
            using (UserContext db = new UserContext())
            {
                Car rentedCar = db.Cars.Where(c => c.Id == currentCar.Id).FirstOrDefault();

                foreach (User u in db.Users.Include("UserProfile"))
                {
                    
                    if (u.Login == v.us.Login)
                    {
                        u.UserProfile.CountOfRentedCars++;
                        v.us.CountOfRentedCars++;
                        v.RentedCarsCountLabel.Content = v.us.CountOfRentedCars;
                        u.Car = rentedCar;
                        u.Car.RentalDate = DateTime.Now.ToShortDateString();
                        u.Car.ReturnDate = DateTime.Now.AddDays(daysCount).ToShortDateString();
                        rentedCar.IsAvailable = false;
                    }
                }

                db.SaveChanges();
            }
            
            MessageBox.Show("Вы успешно оформили арендовали автомобиль! \nВсе подробности об оплате были отправлены Вам на почту.");

            using(UserContext db = new UserContext())
            {
                List<Car> forGrid = new List<Car>();
                foreach(Car c in db.Cars)
                {
                    if(c.Id != 1)
                    {
                        if (c.IsAvailable == true)
                        {
                            forGrid.Add(c);
                        }
                    }

                }
                v.carbGrid.ItemsSource = forGrid;
                v.carbGrid.Items.Refresh();
            }


            Order order = new Order();
            order.Close();
        }
    }
}
