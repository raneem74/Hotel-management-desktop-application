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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace HotelManegmantWpfApp
{
    /// <summary>
    /// Interaction logic for Finalizebill.xaml
    /// </summary>
    public partial class Finalizebill : Window
    {
        public Finalizebill()
        {
            InitializeComponent();
        }
        public string paymentType;
        public string paymentCardNumber;
        public string MM_YY_Of_Card;
        public string CVC_Of_Card;
        public string CardType;
        
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            paymentType = ((ComboBoxItem)this.cmbpayment.SelectedItem).Content.ToString();
            paymentCardNumber = this.txtCardNum.Text;
            MM_YY_Of_Card = ((ComboBoxItem)this.cmbMonth.SelectedItem).Content.ToString() + "-" + ((ComboBoxItem)this.cmbYear.SelectedItem).Content.ToString();
            CVC_Of_Card = this.CVV.Text;
            CardType = this.lblCardtypeContent.Content.ToString();
        }

        private void cmbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtCardNum.Text.Substring(0, 1) == "3")
            {
                lblCardtypeContent.Content = "AmericanEx";
            }
            else if (txtCardNum.Text.Substring(0, 1) == "4")
            {
                lblCardtypeContent.Content = "Visa";
            }
            else if (txtCardNum.Text.Substring(0, 1) == "5")
            {
                lblCardtypeContent.Content = "MasterCard";
            }
            else if (txtCardNum.Text.Substring(0, 1) == "6")
            {
                lblCardtypeContent.Content = "Discover";
            }
            else
                lblCardtypeContent.Content = "Unknown";
        }

        private void txtCardNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
