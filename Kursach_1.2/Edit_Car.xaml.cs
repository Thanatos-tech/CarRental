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
    /// Логика взаимодействия для Edit_Car.xaml
    /// </summary>
    public partial class Edit_Car : Window
    {
        
        public Edit_Car()
        {
            InitializeComponent();

            using (UserContext db = new UserContext())
            {
                List<Car> carss = new List<Car>();
                carss = db.Cars.ToList();
                carsDatagrid.ItemsSource = carss;
                carsDatagrid.Items.Refresh();
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                List<Car> cars = new List<Car>();
                cars = db.Cars.ToList();

                try
                {
                    Add_Car car = new Add_Car();
                    car.Show();
                    car.nameTextbox.Text = cars[carsDatagrid.SelectedIndex].Name;
                    car.modelTextbox.Text = cars[carsDatagrid.SelectedIndex].Model;
                    car.dateOfReleasePicker.SelectedDate = Convert.ToDateTime(cars[carsDatagrid.SelectedIndex].ReleaseDate);
                    car.engineVolumeTextbox.Text = cars[carsDatagrid.SelectedIndex].EngineVolume.ToString();
                    car.categoryCombobox.Text = cars[carsDatagrid.SelectedIndex].Category;
                    car.colorTextbox.Text = cars[carsDatagrid.SelectedIndex].Color;
                    car.mileageTextbox.Text = cars[carsDatagrid.SelectedIndex].Mileage.ToString();
                    car.priceTextbox.Text = cars[carsDatagrid.SelectedIndex].Price.ToString();

                    Car caaaar = db.Cars.Where(c => c.Name == car.nameTextbox.Text && c.Model == car.modelTextbox.Text).FirstOrDefault();
                    db.Cars.Remove(caaaar);
                    db.SaveChanges();
                    carsDatagrid.Items.Refresh();
                }

                catch
                {
                    MessageBox.Show("Выберите машину");
                }
            }
            
        }
    }
}
