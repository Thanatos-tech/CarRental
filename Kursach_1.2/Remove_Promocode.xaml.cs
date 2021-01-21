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
    /// Логика взаимодействия для Remove_Promocode.xaml
    /// </summary>
    public partial class Remove_Promocode : Window
    {
        public Remove_Promocode()
        {
            InitializeComponent();
        }

        private void removePromocodeButton_Click(object sender, RoutedEventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                Promocode promo = db.Promocodes.Where(p => p.Value == promocodeTextbox.Text).FirstOrDefault();
                db.Promocodes.Remove(promo);
                db.SaveChanges();
            }
            MessageBox.Show("Промокод удален");
            this.Close();
        }
    }
}
