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

    public partial class FilterSearch : Window
    {
        
        public FilterSearch()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var v = (CarRental_User)this.Owner;
            List<Car> forSearch = new List<Car>();
            forSearch = v.cars;

            if(fromVolUpDowm.VolumeValue == 0 || toVolUpDown.VolumeValue == 0
                || categoryCombobox.Text == null
                || colorTextbox.Text == null
                || dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() == Convert.ToDateTime("01.01.0001") || dateOfReleaseToPicker.SelectedDate.GetValueOrDefault() == Convert.ToDateTime("01.01.0001")
                || fromMilUpDowm.MileageValue == 0 || toMilUpDown.MileageValue == 0
                || fromPrUpDowm.PriceValue == 0 || toPrUpDown.PriceValue == 0)
            {
                errorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                var selectedCars = forSearch.Where(c => c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
                && c.Category == categoryCombobox.Text
                && c.Color == colorTextbox.Text
                && Convert.ToDateTime(c.ReleaseDate) > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && Convert.ToDateTime(c.ReleaseDate) < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue).ToList();
                v.carbGrid.ItemsSource = selectedCars;
                v.carbGrid.Items.Refresh();
            }




            //using (UserContext db = new UserContext())
            //{
            //    //var user = (CarRental_User)this.Owner;
            //    //var date = new DateTime(0001,1,1);
            //    //MessageBox.Show(dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault().ToString());

            //    //try
            //    //{
            //    //    if(fromVolUpDowm.VolumeValue != 0 && toVolUpDown.VolumeValue == 0)
            //    //    {
            //    //        MessageBox.Show("Введены некорректные данные!");
            //    //    }


            //    //}
            //    //catch
            //    //{
            //    //    MessageBox.Show("Введены некорректные данные!");
            //    //}
            //}




            //using (UserContext db = new UserContext())
            //{
            //    var user = (CarRental_User)this.Owner;

            //    try
            //    {
            //        if (toVolUpDown.VolumeValue != 0 && fromVolUpDowm.VolumeValue != 0)
            //        {
            //            if (categoryCombobox.Text != null)
            //            {

            //                if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now && dateOfReleaseToPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {/////////////////////////////////////////////////////
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //                //////////////////////////////////////////////////////
            //                else if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }

            //                else
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now && dateOfReleaseToPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {/////////////////////////////////////////////////////
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //                //////////////////////////////////////////////////////
            //                else if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }

            //                else
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue


            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume > fromVolUpDowm.VolumeValue && c.EngineVolume < toVolUpDown.VolumeValue



            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }

            //        else if (toVolUpDown.VolumeValue != 0)
            //        {
            //            if (categoryCombobox.Text != null)
            //            {
            //                if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now && dateOfReleaseToPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {/////////////////////////////////////////////////////
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //                //////////////////////////////////////////////////////
            //                else if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }

            //                else
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text

            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text


            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now && dateOfReleaseToPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {/////////////////////////////////////////////////////
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //                //////////////////////////////////////////////////////
            //                else if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue
            //                                                && c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue

            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }

            //                else
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue


            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue



            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.EngineVolume < toVolUpDown.VolumeValue



            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }

            //        else
            //        {

            //            if (categoryCombobox.Text != null)
            //            {
            //                if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now && dateOfReleaseToPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {/////////////////////////////////////////////////////
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where
            //                                                c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where
            //                                                 c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //                //////////////////////////////////////////////////////
            //                else if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }

            //                else
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text

            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text


            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text


            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text


            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text


            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text


            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text


            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now && dateOfReleaseToPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {/////////////////////////////////////////////////////
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() && c.ReleaseDate < dateOfReleaseToPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }
            //                //////////////////////////////////////////////////////
            //                else if (dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault() != DateTime.Now)
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Category == categoryCombobox.Text
            //                                                && c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                                && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()
            //                                               && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.ReleaseDate > dateOfReleaseFromPicker.SelectedDate.GetValueOrDefault()

            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                }

            //                else
            //                {
            //                    if (toMilUpDown.MileageValue != 0 && fromMilUpDowm.MileageValue != 0)
            //                    {///////////////////////////////////
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {   //////////
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            /////////
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage > fromMilUpDowm.MileageValue && c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    /////////////////////////////
            //                    else if (toMilUpDown.MileageValue != 0)
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage < toMilUpDown.MileageValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Mileage < toMilUpDown.MileageValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (toPrUpDown.PriceValue != 0 && fromPrUpDowm.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Price > fromPrUpDowm.PriceValue && c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else if (toPrUpDown.PriceValue != 0)
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Price < toPrUpDown.PriceValue
            //                                                && c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Price < toPrUpDown.PriceValue
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (colorTextbox.Text != null)
            //                            {
            //                                var cars = from c in db.Cars.ToList()
            //                                           where c.Color == colorTextbox.Text
            //                                           select c;

            //                                user.carbGrid.ItemsSource = cars;
            //                                user.carbGrid.Items.Refresh();
            //                            }
            //                            else
            //                            {
            //                                MessageBox.Show("Не задействован ни один фильтр!");
            //                            }
            //                        }
            //                    }
            //                }
            //            }

            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Введены некорректные данные");
            //    }

            //    this.Close();
            //}
        }
    }
}
