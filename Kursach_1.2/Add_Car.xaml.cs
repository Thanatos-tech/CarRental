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
    /// Логика взаимодействия для Add_Car.xaml
    /// </summary>
    public partial class Add_Car : Window
    {
        public Add_Car()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

                using (UserContext db = new UserContext())
                {
                    db.Cars.Add(new Car
                    {
                        Name = nameTextbox.Text,
                        Model = modelTextbox.Text,
                        EngineVolume = Convert.ToInt32(engineVolumeTextbox.Text),
                        ReleaseDate = dateOfReleasePicker.SelectedDate.GetValueOrDefault().ToShortDateString(),
                        Category = categoryCombobox.Text,
                        Color = colorTextbox.Text,
                        Mileage = Convert.ToInt32(mileageTextbox.Text),
                        Price = Convert.ToInt32(priceTextbox.Text)
                    });
                db.SaveChanges();
                }

            this.Close();
            

        }
    }
}
