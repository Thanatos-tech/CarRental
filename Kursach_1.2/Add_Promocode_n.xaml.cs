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
    /// Логика взаимодействия для Add_Promocode_n.xaml
    /// </summary>
    public partial class Add_Promocode_n : Window
    {
        List<Promocode> list = new List<Promocode>();
        public Add_Promocode_n()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void addPromocodeButton_Click(object sender, RoutedEventArgs e)
        {
            var x = (CarRental_Adm)this.Owner;

            if (x.editFlag)
            {

                Promocode p = new Promocode()
                {
                    Value = promocodeTextbox.Text,
                    Effect = effectCombobox.Text
                };

                using (UserContext db = new UserContext())
                {
                    list = db.Promocodes.ToList();
                    foreach(Promocode pr in db.Promocodes)
                    {
                        if (pr.Value == list[x.promocodesDatagrid.SelectedIndex + 1].Value)
                        {
                            pr.Value = p.Value;
                            pr.Effect = p.Effect;
                        }
                    }
                    db.SaveChanges();
                    x.refreshPromocodeButton_Click(this, null);

                    
                }

                x.editFlag = false;
                this.Close();
                return;
                
            }
            else
            {
                using (UserContext db = new UserContext())
                {
                    Promocode promocode = new Promocode()
                    {
                        Value = promocodeTextbox.Text,
                        Effect = effectCombobox.Text
                    };

                    db.Promocodes.Add(promocode);
                    db.SaveChanges();

                    x.refreshPromocodeButton_Click(this, null);
                }
                this.Close();
                return;
            }
        }
    }
}
