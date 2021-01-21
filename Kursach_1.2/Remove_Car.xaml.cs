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
    /// Логика взаимодействия для Remove_Car.xaml
    /// </summary>
    public partial class Remove_Car : Window
    {
        public Remove_Car()
        {
            InitializeComponent();
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (UserContext db = new UserContext())
                {
                    Car car = db.Cars.Where(c => c.Name == NameTextbox.Text && c.Model == modelTextbox.Text).FirstOrDefault();
                    db.Cars.Remove(car);
                    db.SaveChanges();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления");
            }
        }
    }
}
