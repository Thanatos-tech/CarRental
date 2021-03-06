﻿using System;
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
    public partial class NumericalUpDownVolume : UserControl
    {
        //string val = "";
        public NumericalUpDownVolume()
        {
            InitializeComponent();
        }
        public int VolumeValue
        {
            get { return (int)GetValue(VolumeValueProperty); }
            set { SetValue(VolumeValueProperty, value); }
        }

        public static readonly DependencyProperty VolumeValueProperty = DependencyProperty.Register(
            "VolumeValue",
            typeof(int),
            typeof(NumericalUpDownVolume));            



        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            nums.Text = (Convert.ToInt32(nums.Text) + 1).ToString();
            VolumeValue += 1;
            if(VolumeValue > 8)
            {
                nums.Text = "8";
                VolumeValue = 8;
            }
        }

        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            nums.Text = (Convert.ToInt32(nums.Text) - 1).ToString();
            VolumeValue -= 1;
            if (VolumeValue < 0)
            {
                nums.Text = "0";
                VolumeValue = 0;
            }
        }

        //static bool ValidateValue(object value)
        //{
        //    int currentValue = Convert.ToInt32(value);
        //    if(currentValue < 0 || currentValue > 1000)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //static void ValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs d)
        //{
        //    NumericalUpDownVolume n = (NumericalUpDownVolume)obj;
        //    n.CoerceValue(ValueProperty);
        //}

        //static object CoerceValue(DependencyObject obj, object value)
        //{
        //    NumericalUpDownVolume n = (NumericalUpDownVolume)obj;
        //    int currentValue = (int)value;
        //    if(currentValue < 0)
        //    {
        //        currentValue = 0;
        //        return currentValue as object;
        //    }
        //    else if (currentValue < 1000)
        //    {
        //        currentValue = 1000;
        //        return currentValue as object;
        //    }
        //    else
        //    {
        //        return value;
        //    }
        //}
    }
}
