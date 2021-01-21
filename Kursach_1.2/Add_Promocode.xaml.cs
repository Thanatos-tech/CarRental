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
    /// Логика взаимодействия для Add_Promocode.xaml
    /// </summary>
    public partial class Add_Promocode : Window
    {
        public Add_Promocode()
        {
            InitializeComponent();
        }

        private void addPromocodeButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                Promocode promocode = new Promocode
                {
                    Value = promocodeTextbox.Text,
                    Effect = effectCombobox.Text
                };
                db.Promocodes.Add(promocode);
                db.SaveChanges();
            }
            MessageBox.Show("Промокод добавлен");
            this.Close();
        }
    }
}
