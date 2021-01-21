using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для Add_Car_n.xaml
    /// </summary>
    public partial class Add_Car_n : Window
    {
        Uri fileUri;
        OpenFileDialog openFile;
        byte[] imageData;
        List<Car> list = new List<Car>();
        public Add_Car_n()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(descriptionRichtextbox.Document.ContentStart, descriptionRichtextbox.Document.ContentEnd);
            var x = (CarRental_Adm)this.Owner;


            if (x.editFlag)
            {
                    Car c = new Car()
                    {
                        Image = imageData,
                        Name = nameTextbox.Text,
                        Model = modelTextbox.Text,
                        Description = textRange.Text,
                        ReleaseDate = dateOfReleasePicker.SelectedDate.GetValueOrDefault().ToShortDateString(),
                        EngineVolume = Convert.ToInt32(engineVolumeTextbox.Text),
                        Category = categoryCombobox.Text,
                        Color = colorTextbox.Text,
                        Mileage = Convert.ToInt32(mileageTextbox.Text),
                        Price = Convert.ToDouble(priceTextbox.Text)
                    };

                using (UserContext db = new UserContext())
                {
                    list = db.Cars.ToList();
                    foreach (Car ca in db.Cars)
                    {
                        if (ca.Model == list[x.carsDatagrid.SelectedIndex+1].Model)
                        {
                            ca.Image = c.Image;
                            ca.Name = c.Name;
                            ca.Model = c.Model;
                            ca.Description = c.Description;
                            ca.ReleaseDate = c.ReleaseDate;
                            ca.EngineVolume = c.EngineVolume;
                            ca.Category = c.Category;
                            ca.Color = c.Color;
                            ca.Mileage = c.Mileage;
                            ca.Price = c.Price;
                        }
                    }
                    db.SaveChanges();
                    x.refreshCarButton_Click(this, null);
                }
                x.editFlag = false;
                this.Close();
                return;
            }
            else
            {
                using (UserContext db = new UserContext())
                {

                    Car car = new Car()
                    {
                        Image = imageData,
                        Name = nameTextbox.Text,
                        Model = modelTextbox.Text,
                        Description = textRange.Text,
                        ReleaseDate = dateOfReleasePicker.SelectedDate.GetValueOrDefault().ToShortDateString(),
                        EngineVolume = Convert.ToInt32(engineVolumeTextbox.Text),
                        Category = categoryCombobox.Text,
                        Color = colorTextbox.Text,
                        Mileage = Convert.ToInt32(mileageTextbox.Text),
                        Price = Convert.ToDouble(priceTextbox.Text),
                        IsAvailable = true
                    };

                    db.Cars.Add(car);
                    db.SaveChanges();

                    x.refreshCarButton_Click(this, null);
                }
                this.Close();
            }

            
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                openFile = new OpenFileDialog();

                openFile.ShowDialog();

                using (System.IO.FileStream fs = new System.IO.FileStream(openFile.FileName, FileMode.Open))
                {
                    imageData = new byte[fs.Length];

                    fs.Read(imageData, 0, imageData.Length);
                }
                fileUri = new Uri(openFile.FileName);

                carImage.Source = new BitmapImage(fileUri);
            }
            catch
            {

            }
        }
    }
}
