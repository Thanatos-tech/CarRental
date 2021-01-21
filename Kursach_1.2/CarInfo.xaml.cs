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
using Image = System.Drawing.Image;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для CarInfo.xaml
    /// </summary>
    public partial class CarInfo : Window
    {
        public Image Img { get; set; }
        public byte[] tempImage;
        public CarInfo()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            var x = (CarRental_User)this.Owner;
            Img = x.Image;


        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
