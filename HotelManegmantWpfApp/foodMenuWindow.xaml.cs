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

namespace HotelManegmantWpfApp
{
    /// <summary>
    /// Interaction logic for foodMenuWindow.xaml
    /// </summary>
    public partial class foodMenuWindow : Window
    {
        public foodMenuWindow()
        {
            InitializeComponent();
        }

        internal int foodBill = 0;
        internal int breakfastPrice = 7;
        internal int lunchPrice = 15;
        internal int dinnerPrice = 15;
        internal bool cleaning = false;
        internal bool towel = false;
        internal bool surprise = false;

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.lunchQTY.IsEnabled = true;
            this.lunchQTY.Value = 1;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.lunchQTY.IsEnabled = false;
            this.lunchQTY.Value = 0;

        }

        private void breakfastCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.breakfastQTY.IsEnabled = false;
            this.breakfastQTY.Value = 0;

        }

        private void breakfastCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            this.breakfastQTY.IsEnabled = true;
            this.breakfastQTY.Value = 1;

        }

        private void dinnerCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            this.dinnerQTY.IsEnabled = true;
            this.dinnerQTY.Value = 1;

        }

        private void dinnerCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.dinnerQTY.IsEnabled = false;
            this.dinnerQTY.Value = 0;
        }


        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            int breakfastQty = (int)this.breakfastQTY.Value;
            int lunchQty = (int)this.lunchQTY.Value;
            int dinnerQty = (int)this.dinnerQTY.Value;

            cleaning = (bool)this.cleaningCheckbox.IsChecked;
            towel = (bool)this.towelsCheckbox.IsChecked;
            surprise = (bool)this.surpriseCheckbox.IsChecked;

            if (breakfastQty > 0 || lunchQty > 0 || dinnerQty > 0)
            {
                int bfastTotalPrice = breakfastPrice * breakfastQty;
                int LTotalPricePrice = lunchPrice * lunchQty;
                int dTotalPricePrice = dinnerPrice * dinnerQty;
                foodBill = bfastTotalPrice + LTotalPricePrice + dTotalPricePrice;
            }
            this.Close();
        }
    }
}
