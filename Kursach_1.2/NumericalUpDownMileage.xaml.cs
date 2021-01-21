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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursach_1._2
{
    /// <summary>
    /// Логика взаимодействия для NumericalUpDown.xaml
    /// </summary>
    public partial class NumericalUpDownMileage : UserControl
    {
        //string val = "";
        public NumericalUpDownMileage()
        {
            InitializeComponent();
        }
        public int MileageValue
        {
            get { return (int)GetValue(MileageValueProperty); }
            set { SetValue(MileageValueProperty, value); }
        }

        public static readonly DependencyProperty MileageValueProperty = DependencyProperty.Register(
            "MileageValue",
            typeof(int),
            typeof(NumericalUpDownVolume));            



        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            nums.Text = (Convert.ToInt32(nums.Text) + 5000).ToString();
            MileageValue += 5000;
            if(MileageValue > 100000)
            {
                nums.Text = "100000";
                MileageValue = 100000;
            }
        }

        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            nums.Text = (Convert.ToInt32(nums.Text) - 5000).ToString();
            MileageValue -= 5000;
            if (MileageValue < 0)
            {
                nums.Text = "0";
                MileageValue = 0;
            }
        }
    }
}
