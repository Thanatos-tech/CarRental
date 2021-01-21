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
using System.Data.SqlClient;
using System.Data;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Globalization;

namespace Kursach_1._2
{
    public partial class CarRental_User : Window
    {
        //public List<System.Windows.Controls.Image> Images { get; set; }

        public DateTime date = DateTime.Now;
        public FullUser us = new FullUser();
        public string buf;
        public List<Car> cars;

        public List<FullReviewer> reviews;
        public byte[] selectedImage;
        public Image Image { get; set; }

        public DateTime dateCheck = DateTime.Now;

        

        public CarRental_User()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;


            
            


            cars = new List<Car>();
            using (UserContext db = new UserContext())
            {
                foreach (Car c in db.Cars)
                {
                    try
                    {
                        if (c.Image != null && c.Id != 1)
                        {
                            Stream stream = new MemoryStream(c.Image);
                            var bitmap = new Bitmap(stream);
                            Image = bitmap;

                            //if (Convert.ToDateTime(c.ReturnDate) <= date)
                            //{
                            //    c.IsAvailable = true;
                            //}
                            //else
                            //{
                            //    c.IsAvailable = false;
                            //}

                            if (c.IsAvailable)
                            {
                                cars.Add(c);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Изображение == null");
                    }
                    
                    
                    
                }
                db.SaveChanges();
                carbGrid.ItemsSource = cars;
                //carbGrid.Items.Refresh();

            }





            reviews = new List<FullReviewer>();

            using (UserContext db = new UserContext())
            {
                foreach(User u in db.Users.Include("UserProfile").Include("Review"))
                {
                    if(u.Review.Id != 1)
                    {
                        reviews.Add(new FullReviewer
                        {
                            FirstName = u.UserProfile.FirstName,
                            SecondName = u.UserProfile.SecondName,
                            Text = u.Review.Text
                        });
                    }
                }
                reviewGrid.ItemsSource = reviews;
            }

            
           

            //var someVar = (Login)this.Owner;
            //MessageBox.Show(someVar.login);
            
        }


        private void retrunreturnCarButton_Click(object sender, RoutedEventArgs e)
        {
            using(UserContext db = new UserContext())
            {
                Car nullCar = db.Cars.Where(c => c.Id == 1).FirstOrDefault();
                foreach (User user in db.Users.Include("Car"))
                {
                    if(us.Login == user.Login)
                    {
                        user.Car.IsAvailable = true;
                        user.Car = nullCar;
                    }
                }
                db.SaveChanges();
            }
            
        }

        private void searchByModelTextbox_TextChanged(object sender, RoutedEventArgs e)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            using(UserContext db = new UserContext())
            {
                try
                {
                    List<Car> searchCars = new List<Car>();
                    carbGrid.ItemsSource = searchCars;

                    foreach (Car c in cars)
                    {
                        if(c.Id != 1)
                        {
                            if (c.Model.Contains(ti.ToTitleCase(searchByModelTextbox.Text)) == true)
                            {
                                bool flag = true;
                                foreach (Car ca in searchCars)
                                {
                                    if (ca == c)
                                    {
                                        flag = false;
                                        break;
                                    }
                                    else
                                    {
                                        flag = true;
                                    }
                                }
                                if (flag == true)
                                {
                                    searchCars.Add(c);
                                }
                            }
                        }
                        
                    }
                    carbGrid.Items.Refresh();
                }
                catch
                {
                    MessageBox.Show("Ошибка поиска по модели");
                }

                
            }
        }

        //private void searchByNameTextbox_TextChanged(object sender, RoutedEventArgs e)
        //{
        //    TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        //    using (UserContext db = new UserContext())
        //    {
        //        try
        //        {
        //            List<Car> searchCars = new List<Car>();
        //            carbGrid.ItemsSource = searchCars;

        //            foreach (Car c in db.Cars)
        //            {
        //                if (c.Id != 1)
        //                {
        //                    if (c.Name.Contains(ti.ToTitleCase(searchByNameTextbox.Text)) == true)
        //                    {
        //                        bool flag = true;
        //                        foreach (Car ca in searchCars)
        //                        {
        //                            if (ca == c)
        //                            {
        //                                flag = false;
        //                                break;
        //                            }
        //                            else
        //                            {
        //                                flag = true;
        //                            }
        //                        }
        //                        if (flag == true)
        //                        {
        //                            searchCars.Add(c);
        //                        }
        //                    }
        //                }

        //            }
        //            carbGrid.Items.Refresh();
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Ошибка поиска по модели");
        //        }


        //    }
        //}




        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            using(UserContext db= new UserContext())
            {
                

                carbGrid.ItemsSource = cars;
                carbGrid.Items.Refresh();
                reviewGrid.ItemsSource = cars;
                reviewGrid.Items.Refresh();
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddReview add = new AddReview();
            add.Owner = this;


                      


            add.Show();
        }

        private void promocodeButton_Click(object sender, RoutedEventArgs e)
        {

            using (UserContext db = new UserContext())
            {             

                Promocode promo = db.Promocodes.Where(p => p.Id != 1 && p.Value == promocodeTextbox.Text).FirstOrDefault();
                if (promo != null)
                {
                    MessageBox.Show("Промокод применен!");
                    promocodeTextbox.Text = "";
                    foreach(User u in db.Users.Include("Promocode").ToList())
                    {
                        if(u.Login == us.Login)
                        {
                            u.Promocode = promo;
                        }
                        if (u.Promocode.Effect == "Скидка 10%")
                        {
                            foreach (Car c in cars)
                            {
                                c.Price *= 0.9;
                            }
                        }
                        else if (u.Promocode.Effect == "Скидка 20%")
                        {
                            foreach (Car c in cars)
                            {
                                c.Price *= 0.8;
                            }
                        }
                        else if (u.Promocode.Effect == "Скидка 30%")
                        {
                            foreach (Car c in cars)
                            {
                                c.Price *= 0.7;
                            }
                        }
                        else if (u.Promocode.Effect == "1 прокат")
                        {
                            foreach (Car c in cars)
                            {
                                c.Price = 0;
                            }
                        }
                        usedPromoLabel.Content = "Активный промокод: " + u.Promocode.Effect;
                    }

                    refresh_Click(this, e);

                    db.SaveChanges();
                    return;
                }
                else
                {
                    MessageBox.Show("Такого промода нет");
                }     
            } 
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }


        private void filterSearch_Click(object sender, RoutedEventArgs e)
        {
            FilterSearch search = new FilterSearch();
            search.Owner = this;
            search.Show();
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Owner = this;
            order.currentCar = cars[carbGrid.SelectedIndex];
            order.Show();

            

            order.descriptionTextblock.Text = "  " + cars[carbGrid.SelectedIndex].Name
                 + "; "
                 + cars[carbGrid.SelectedIndex].Model
                 + "; "
                 + cars[carbGrid.SelectedIndex].ReleaseDate
                 + "; "
                 + cars[carbGrid.SelectedIndex].EngineVolume
                 + " л" + "; "
                 + cars[carbGrid.SelectedIndex].Category
                 + "; "
                 + cars[carbGrid.SelectedIndex].Color
                 + "; "
                 + cars[carbGrid.SelectedIndex].Mileage
                 + " км";
        }

        private void secondNameChangeButton_Click(object sender, RoutedEventArgs e)
        {
            using(UserContext db = new UserContext())
            {
                foreach(User u in db.Users.Include("UserProfile"))
                {
                    if(u.Login == us.Login)
                    {
                        u.UserProfile.SecondName = secondNameTextbox.Text;
                        us.SecondName = secondNameTextbox.Text;
                    }
                }
                db.SaveChanges();
            }
        }

        private void firstChangeButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User u in db.Users.Include("UserProfile"))
                {
                    if (u.Login == us.Login)
                    {
                        u.UserProfile.FirstName = firstNameTextbox.Text;
                        us.SecondName = firstNameTextbox.Text;
                    }
                }
                db.SaveChanges();
            }
        }

        private void middleChangeButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User u in db.Users.Include("UserProfile"))
                {
                    if (u.Login == us.Login)
                    {
                        u.UserProfile.MiddleName = middleNameTextbox.Text;
                        us.SecondName = middleNameTextbox.Text;
                    }
                }
                db.SaveChanges();
            }
        }

        private void phoneNumberChangeButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User u in db.Users.Include("UserProfile"))
                {
                    if (u.Login == us.Login)
                    {
                        u.UserProfile.PhoneNumber = phoneNumberTextbox.Text;
                        us.SecondName = phoneNumberTextbox.Text;
                    }
                }
                db.SaveChanges();
            }
        }

        private void birthDateButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User u in db.Users.Include("UserProfile"))
                {
                    if (u.Login == us.Login)
                    {
                        u.UserProfile.DateOfBirth = birthDatePicker.SelectedDate.GetValueOrDefault().ToShortDateString();
                        us.DateOfBirth = birthDatePicker.SelectedDate.GetValueOrDefault().ToShortDateString();
                    }
                }
                db.SaveChanges();
            }
        }

        private void passportNumberChangeButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User u in db.Users.Include("UserProfile"))
                {
                    if (u.Login == us.Login)
                    {
                        u.UserProfile.PassportSerialNumber = passportNumberTextbox.Text;
                        us.PassportSerialNumber = passportNumberTextbox.Text;
                    }
                }
                db.SaveChanges();
            }
        }

        private void emailChangeButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User u in db.Users.Include("UserProfile"))
                {
                    if (u.Login == us.Login)
                    {
                        u.UserProfile.Email = emailTextbox.Text;
                        us.Email = emailTextbox.Text;
                    }
                }
                db.SaveChanges();
            }
        }

        public void Ban()
        {
            searchByModelTextbox.IsEnabled = false;
            filterSearch.IsEnabled = false;
            promocodeTextbox.IsEnabled = false;
            promocodeButton.IsEnabled = false;
            carbGrid.IsEnabled = false;
            paymentButton.IsEnabled = true;
            paymentButton.Visibility = Visibility.Visible;
            reviewGrid.IsEnabled = false;
            firstNameTextbox.IsEnabled = false;
            secondNameTextbox.IsEnabled = false;
            middleNameTextbox.IsEnabled = false;
            phoneNumberTextbox.IsEnabled = false;
            birthDatePicker.IsEnabled = false;
            passportNumberTextbox.IsEnabled = false;
            emailTextbox.IsEnabled = false;

            firstChangeButton.IsEnabled = false;
            secondNameChangeButton.IsEnabled = false;
            middleChangeButton.IsEnabled = false;
            phoneNumberChangeButton.IsEnabled = false;
            birthDateButton.IsEnabled = false;
            passportNumberChangeButton.IsEnabled = false;
            emailChangeButton.IsEnabled = false;
        }
    }
}
