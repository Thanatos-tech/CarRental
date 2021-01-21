using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using Color = System.Windows.Media.Color;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для CarRental_Adm.xaml
    /// </summary>
    public partial class CarRental_Adm : Window
    {

        public System.Drawing.Image Image { get; set; }

        public List<FullUser> users;
        public List<Car> cars;
        public List<Promocode> promocodes;
        public bool editFlag = false;


        public CarRental_Adm()
        {
            
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;


            users = new List<FullUser>();
            cars = new List<Car>();
            promocodes = new List<Promocode>();

            using (UserContext db = new UserContext())
            {
                foreach(User u in db.Users.Include("UserProfile").ToList())
                {
                    users.Add(new FullUser
                    {
                        Login = u.Login,
                        Hash = u.Hash,
                        Salt = u.Salt,
                        FirstName = u.UserProfile.FirstName,
                        SecondName = u.UserProfile.SecondName,
                        MiddleName = u.UserProfile.MiddleName,
                        PhoneNumber = u.UserProfile.PhoneNumber,
                        DateOfBirth = u.UserProfile.DateOfBirth,
                        PassportSerialNumber = u.UserProfile.PassportSerialNumber,
                        Email = u.UserProfile.Email,
                        RegistrationDate = u.UserProfile.RegistrationDate,
                        CountOfRentedCars = u.UserProfile.CountOfRentedCars,
                        Admin = u.UserProfile.Admin
                    });
                }
                usersDatagrid.ItemsSource = users;

                foreach (Car c in db.Cars)
                {
                    if(c.Id != 1)
                    {
                        Stream stream = new MemoryStream(c.Image);
                        var bitmap = new Bitmap(stream);
                        Image = bitmap;


                        DateTime date = DateTime.Now;
                        if (Convert.ToDateTime(c.ReturnDate) <= date)
                        {
                            c.IsAvailable = true;
                        }
                        else
                        {
                            c.IsAvailable = false;
                        }

                        if (c.IsAvailable)
                        {
                            cars.Add(c);
                        }
                    }
                    
                }
                carsDatagrid.ItemsSource = cars;

                foreach (Promocode p in db.Promocodes)
                {
                    if(p.Id != 1)
                    {
                        promocodes.Add(p);
                    }
                }
                promocodesDatagrid.ItemsSource = promocodes;
            }
        }



        private void exitButton_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }


        //////////////////////////////////////////////USERS/////////////////////////////////////////////////


        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            Add_User add = new Add_User();
            add.Owner = this;
            add.Show();
        }

        private void removeUserButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                using (UserContext db = new UserContext())
                {
                    db.Users.Remove(db.Users.ToList()[usersDatagrid.SelectedIndex]);
                    db.UserProfiles.Remove(db.UserProfiles.ToList()[usersDatagrid.SelectedIndex]);
                    db.SaveChanges();

                    refreshButton_Click(this, e);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления");
            }
            
        }

        public void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            using(UserContext db = new UserContext())
            {
                List<FullUser> refreshList = new List<FullUser>();
                foreach(User u in db.Users.Include("UserProfile"))
                {
                    refreshList.Add(new FullUser
                    {
                        Login = u.Login,
                        Hash = u.Hash,
                        Salt = u.Salt,
                        FirstName = u.UserProfile.FirstName,
                        SecondName = u.UserProfile.SecondName,
                        MiddleName = u.UserProfile.MiddleName,
                        PhoneNumber = u.UserProfile.PhoneNumber,
                        DateOfBirth = u.UserProfile.DateOfBirth,
                        PassportSerialNumber = u.UserProfile.PassportSerialNumber,
                        Email = u.UserProfile.Email,
                        RegistrationDate = u.UserProfile.RegistrationDate,
                        CountOfRentedCars = u.UserProfile.CountOfRentedCars,
                        Admin = u.UserProfile.Admin
                    });
                }
                usersDatagrid.ItemsSource = refreshList;
                usersDatagrid.Items.Refresh();
            }
        }

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            
            Add_User add = new Add_User();
            add.Owner = this;
            editFlag = true;

            try
            {
                using (UserContext db = new UserContext())
                {
                    add.firstNameTextbox.Text = db.UserProfiles.ToList()[usersDatagrid.SelectedIndex].FirstName;
                    add.secondNameTextbox.Text = db.UserProfiles.ToList()[usersDatagrid.SelectedIndex].SecondName;
                    add.middleNameTextbox.Text = db.UserProfiles.ToList()[usersDatagrid.SelectedIndex].MiddleName;
                    add.phoneNumberTextbox.Text = db.UserProfiles.ToList()[usersDatagrid.SelectedIndex].PhoneNumber;
                    add.dateOfBirthPicker.SelectedDate = Convert.ToDateTime(db.UserProfiles.ToList()[usersDatagrid.SelectedIndex].DateOfBirth);
                    add.passportSerialNumberTextbox.Text = db.UserProfiles.ToList()[usersDatagrid.SelectedIndex].PassportSerialNumber;
                    add.emailTextbox.Text = db.UserProfiles.ToList()[usersDatagrid.SelectedIndex].Email;
                    add.adminCheckbox.IsChecked = db.UserProfiles.ToList()[usersDatagrid.SelectedIndex].Admin;
                }

                add.loginTextbox.IsEnabled = false;
                add.loginTextbox.BorderBrush = new SolidColorBrush(Colors.Black);
                //add.loginTextbox.BorderThickness;
                add.passwordPasswordbox.IsEnabled = false;

                add.Show();
            }
            catch
            {
                MessageBox.Show("Выберите пользователя");
            }


        }




        //////////////////////////////////////////////CARS/////////////////////////////////////////////////

        private void addCarButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Car_n add = new Add_Car_n();
            add.Owner = this;
            add.Show();
        }

        public void refreshCarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Car> list = new List<Car>();
            using (UserContext db = new UserContext())
            {
                foreach (Car c in db.Cars)
                {
                    if (c.Id != 1)
                    {
                        list.Add(c);
                    }
                }
                carsDatagrid.ItemsSource = list;
                carsDatagrid.Items.Refresh();
            }
        }

        private void removeCarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    db.Cars.Remove(db.Cars.ToList()[carsDatagrid.SelectedIndex+1]);
                    db.SaveChanges();

                    cars = db.Cars.ToList();

                    refreshCarButton_Click(this, null);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления");
            }
        }

        private void editCarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add_Car_n add = new Add_Car_n();
                add.Owner = this;
                editFlag = true;

                using (UserContext db = new UserContext())
                {
                    if(db.Cars.ToList()[carsDatagrid.SelectedIndex + 1].Id == 1)
                    {
                        throw new Exception("Выберите автомобиль");
                    }

                    add.nameTextbox.Text = db.Cars.ToList()[carsDatagrid.SelectedIndex+1].Name;
                    add.modelTextbox.Text = db.Cars.ToList()[carsDatagrid.SelectedIndex+1].Model;
                    add.engineVolumeTextbox.Text = db.Cars.ToList()[carsDatagrid.SelectedIndex+1].EngineVolume.ToString();
                    add.dateOfReleasePicker.SelectedDate = Convert.ToDateTime(db.Cars.ToList()[carsDatagrid.SelectedIndex+1].ReleaseDate);
                    add.categoryCombobox.Text = db.Cars.ToList()[carsDatagrid.SelectedIndex+1].Category;
                    add.colorTextbox.Text = db.Cars.ToList()[carsDatagrid.SelectedIndex+1].Color;
                    add.mileageTextbox.Text = db.Cars.ToList()[carsDatagrid.SelectedIndex+1].Mileage.ToString();
                    add.priceTextbox.Text = db.Cars.ToList()[carsDatagrid.SelectedIndex+1].Price.ToString();
                }

                add.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //////////////////////////////////////////////PROMOCODES/////////////////////////////////////////////////


        private void addPromocodeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add_Promocode_n add = new Add_Promocode_n();
                add.Owner = this;
                add.Show();
            }
            catch
            {
                MessageBox.Show("Ошибка добавления.");
            }
        }

        public void refreshPromocodeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Promocode> list = new List<Promocode>();
                using (UserContext db = new UserContext())
                {
                    foreach (Promocode p in db.Promocodes)
                    {
                        if (p.Id != 1)
                        {
                            list.Add(p);
                        }
                    }
                    promocodesDatagrid.ItemsSource = list;
                    promocodesDatagrid.Items.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка обновления.");
            }
            
        }

        private void removePromocodeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    db.Promocodes.Remove(db.Promocodes.ToList()[promocodesDatagrid.SelectedIndex+1]);
                    db.SaveChanges();

                    refreshPromocodeButton_Click(this, e);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления.");
            }
        }

        private void editPromocodeButton_Click(object sender, RoutedEventArgs e)
        {
            Add_Promocode_n add = new Add_Promocode_n();
            add.Owner = this;
            editFlag = true;

            try
            {
                using (UserContext db = new UserContext())
                {
                    add.promocodeTextbox.Text = db.Promocodes.ToList()[promocodesDatagrid.SelectedIndex + 1].Value;
                    add.effectCombobox.Text = db.Promocodes.ToList()[promocodesDatagrid.SelectedIndex + 1].Effect;
                }
            }
            catch
            {
                MessageBox.Show("Выберите промокод.");
            }

            add.Show();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void debtorsButton_Click(object sender, RoutedEventArgs e)
        {
            List<FullUser> debtors = new List<FullUser>();
            using(UserContext db = new UserContext())
            {
                foreach(User u in db.Users.Include("UserProfile").Include("Car"))
                {
                    if(DateTime.Now.Day > Convert.ToDateTime(u.Car.ReturnDate).Day)
                    {
                        debtors.Add(new FullUser
                        {
                            FirstName = u.UserProfile.FirstName,
                            SecondName = u.UserProfile.SecondName,
                            MiddleName = u.UserProfile.MiddleName,
                            PhoneNumber = u.UserProfile.PhoneNumber,
                            DateOfBirth = u.UserProfile.DateOfBirth,
                            PassportSerialNumber = u.UserProfile.PassportSerialNumber,
                            Email = u.UserProfile.Email,
                            RegistrationDate = u.UserProfile.RegistrationDate,
                            CountOfRentedCars = u.UserProfile.CountOfRentedCars,
                            Login = u.Login
                        });
                    }
                    usersDatagrid.ItemsSource = debtors;
                    usersDatagrid.Items.Refresh();
                }


            }
        }
    }
}
