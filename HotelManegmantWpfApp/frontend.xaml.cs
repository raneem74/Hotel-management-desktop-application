using HotelManegmantWpfApp.Context;
using HotelManegmantWpfApp.Entities;
using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Controls.ComboBox;
using Control = System.Windows.Controls.Control;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;
using Window = System.Windows.Window;

namespace HotelManegmantWpfApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        public Window1()
        {
            context.reservations.Load();
            InitializeComponent();
        }
        //double foodBill;
        //double breakfastPrice = 7;
        //double lunchPrice = 15;
        //double dinnerPrice = 15;
        //bool? cleaning;
        //bool? towel;
        //bool? surprise;
        FrontendContext context = new FrontendContext();
        
        public int totalAmount = 0;
        foodMenuWindow foodmenuWin;//new with defualt params
        Finalizebill finalizebill;

        private double finalizedTotalAmount = 0.0;
        private string paymentType;
        private string paymentCardNumber;
        private string MM_YY_Of_Card;
        private string CVC_Of_Card;
        private string CardType;
        public Boolean editClicked = false;
        double totalBill = 0;
        int breakfastQty;
        int lunchQty ;
        int dinnerQty;
        bool cleaning;
        bool towel;
        bool surprise;
        private void btnFoodAndMenu_Click(object sender, RoutedEventArgs e)
        {
            foodmenuWin = new foodMenuWindow();

            foodmenuWin.Show();
            this.IsEnabled = false;
            foodmenuWin.Topmost = true;

            //bool? breakfast = foodmenuWin.breakfastCheckbox.IsChecked;
            //bool? lunch = foodmenuWin.lunchCheckbox.IsChecked;
            //bool? dinner = foodmenuWin.dinnerCheckbox.IsChecked;

             breakfastQty = (int)foodmenuWin.breakfastQTY.Value ;
             lunchQty = (int)foodmenuWin.breakfastQTY.Value;
             dinnerQty = (int)foodmenuWin.dinnerQTY.Value;

            cleaning = foodmenuWin.cleaning;
            towel = foodmenuWin.towel;
            surprise = foodmenuWin.surprise;

            //if (breakfastQty > 0 || lunchQty > 0 || dinnerQty > 0)
            //{
            //    double bfastTotalPrice = breakfastPrice * breakfastQty;
            //    double LTotalPricePrice = lunchPrice * lunchQty;
            //    double dTotalPricePrice = dinnerPrice * dinnerQty;
            //    foodBill = bfastTotalPrice + LTotalPricePrice + dTotalPricePrice;
            //}

            foodmenuWin.Closed += (s, args) => { this.IsEnabled = true; };
        }

        private void cmbRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbRoomType.SelectedItem != null)
            {

                string SelectedVal = ((ComboBoxItem)cmbRoomType.SelectedItem).Content.ToString();

                if (SelectedVal == "Single")
                {
                    totalAmount = 149;
                    cmbFloor.SelectedIndex = 0;
                }
                else if (SelectedVal == "Double")
                {
                    totalAmount = 299;
                    cmbFloor.SelectedIndex = 1;
                }
                else if (SelectedVal == "Twin") {
                    totalAmount = 349;
                    cmbFloor.SelectedIndex = 2;
                }
                else if (SelectedVal == "Duplex")
                {
                    totalAmount = 399;
                    cmbFloor.SelectedIndex = 3;
                }
                else if (SelectedVal == "Suite")
                {
                    totalAmount = 499;
                    cmbFloor.SelectedIndex = 4;
                }
            }

            int selectedTemp = 0;
            string selected;
            //var NumberOfGuests = ((ComboBoxItem)cmbGstNumber.SelectedItem).Content.ToString();
            //bool temp = int.TryParse( NumberOfGuests , out selectedTemp);


            if (cmbGstNumber.SelectedItem == null)
            {
                MessageBox.Show("Enter # of guests first", "Error parsing", MessageBoxButton.OK);
            }
            else
            {
                var temp = ((ComboBoxItem)cmbGstNumber.SelectedItem).Content.ToString();
                int.TryParse(temp, out int NumberOfGuests);
                if (NumberOfGuests >= 3)
                {
                    totalAmount += (NumberOfGuests * 5);
                }
            }
        }

        private async void btnEditExistingReservation_Click(object sender, RoutedEventArgs e)
        {
            editClicked = true;

            dpEntryDate.DisplayDateStart = new DateTime(2014, 4, 1);
            dpDepartureDate.DisplayDateStart = new DateTime(2014, 4, 1);

            btnSubmit.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Visible;
            btnDelete.Visibility = Visibility.Visible;
            btnEditExistingReservation.Visibility = Visibility.Visible;
            cmbReservationTitle.Visibility = Visibility.Visible;

            //FillcmbReservaionTitle();

            //context.reservations.Load();
            //Reservation title Combobox fill
            var ReservationTitleData = context.reservations.Local.Select(r => $"{r.Id} , {r.first_name} , {r.last_name} , {r.phone_number}").ToList();
            // Set the ComboBox ItemsSource to the list of anonymous objects
            cmbReservationTitle.ItemsSource = ReservationTitleData;

            reset_frontend();



        }

        internal void FillcmbReservaionTitle()
        {
            //Reservation title Combobox fill
            //context.reservations.Load();
            var ReservationTitleData = context.reservations.Local.Select(r => $"{r.Id} , {r.first_name} , {r.last_name} , {r.phone_number}").ToList();

            // Set the ComboBox ItemsSource to the list of anonymous objects
            cmbReservationTitle.ItemsSource = ReservationTitleData;
        }

        private void reset_frontend()
        {
            try
            {

                
                //cmbReservationTitle.ItemsSource= null;

                txtFname.Text = string.Empty;
                txtSname.Text = string.Empty;
                txtYear.Text = string.Empty;
                txtPhoneNumber.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtApt.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtZip.Text = string.Empty;
                txtAddress.Text = string.Empty;

                chkCheckIn.IsChecked = false;
                chkFoodStatus.IsChecked = false;
                chkSendSMS.IsChecked = false;

                cmbMonth.SelectedItem= null;
                cmbDay.SelectedItem= null;
                cmbGender.SelectedItem= null;
                cmbState.SelectedItem= null;
                cmbGstNumber.SelectedItem= null;
                cmbRoomNumber.SelectedItem= null;
                cmbRoomType.SelectedItem= null;
                cmbFloor.SelectedItem= null;

                dpEntryDate.DisplayDate = (DateTime)dpEntryDate.DisplayDateStart;
                dpDepartureDate.DisplayDate = (DateTime)dpDepartureDate.DisplayDateStart;

                //ClearAllComboBox(this);
                //ClearAllTextBoxes(this);
                //ClearTextBoxes(this);

                //ComboBoxItemsFromDataBase();

            }
            catch (Exception ex)
            {
                MessageBox.Show("try again","Error", MessageBoxButton.OKCancel);
            }
        }

        private void ClearTextBoxes(Window window)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(window); i++)
            {
                var child = VisualTreeHelper.GetChild(window, i);
                if (child is TextBox)
                {
                    ((TextBox)child).Text = string.Empty;
                }
                //else if (child is FrameworkElement)
                //{
                //    ClearTextBoxes((FrameworkElement)child);
                //}
            }
        }

        public void ClearAllComboBox(Control controls)
        {
            foreach (Control control in controls.GetChildObjects())
            {
                if (control == cmbRoomType)
                {
                    continue;
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
                if (control.GetChildObjects().Count() != 0 )
                {
                    ClearAllComboBox(control);
                }
            }
        }
        
        private void btnFinalizeBill_Click(object sender, RoutedEventArgs e)
        {
            if ( foodmenuWin!=null && foodmenuWin.foodBill==0 && !foodmenuWin.cleaning && !foodmenuWin.towel && !foodmenuWin.surprise)
            {
                chkFoodStatus.IsEnabled = true;
                chkFoodStatus.IsChecked = true;
            }
            double tax = totalAmount * 0.07;
            totalBill = tax + foodmenuWin.foodBill + totalAmount; ;

            finalizebill = new Finalizebill();
            finalizebill.currentBillAmount.Content = totalAmount;
            finalizebill.foodBillAmount.Content = foodmenuWin.foodBill ;
            finalizebill.taxAmount.Content = tax;
            finalizebill.totalAmount.Content = totalBill;

            //if (taskFinder)
            //{
            //    finalizebil.paymentComboBox.SelectedItem = FPayment.Replace(" ", string.Empty);
            //    finalizebil.phoneNComboBox.Text = FCnumber;
            //    finalizebil.monthComboBox.SelectedItem = FcardExpOne;
            //    finalizebil.yearComboBox.SelectedItem = FcardExpTwo;
            //    finalizebil.cvcComboBox.Text = FCardCVC;
            //}
            finalizebill.Show();

            //paymentType = finalizebill.paymentType; //.((ComboBoxItem)finalizebill.cmbpayment.SelectedItem).Content.ToString();
            //paymentCardNumber = finalizebill.paymentCardNumber;//.txtCardNum.Text;
            //MM_YY_Of_Card = finalizebill.MM_YY_Of_Card;//.cmbMonth.SelectedItem).Content.ToString()+"-"+ ((ComboBoxItem)finalizebill.cmbYear.SelectedItem).Content.ToString();
            //CVC_Of_Card = finalizebill.CVC_Of_Card;//.CVV.Text;
            //CardType = finalizebill.CardType;//.lblCardtypeContent.Content.ToString();

            finalizebill.Topmost = true;
            this.IsEnabled= false;

            if (!editClicked)
            {
                btnSubmit.Visibility = Visibility.Visible;
            }

            finalizebill.Closed += (s, args) => { this.IsEnabled = true; };

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string BirthDay = ((ComboBoxItem)cmbMonth.SelectedItem).Content.ToString()+"/"+((ComboBoxItem)cmbDay.SelectedItem).Content.ToString()+"/"+txtYear;
            Reservation reservation = new Reservation()
            {
                first_name = txtFname.Text,
                last_name = txtSname.Text,
                birth_day = BirthDay,
                gender = ((ComboBoxItem)cmbGender.SelectedItem).Content.ToString(),
                phone_number = txtPhoneNumber.Text,
                email_address = txtEmail.Text,
                number_guest = int.Parse(((ComboBoxItem)cmbGstNumber.SelectedItem).Content.ToString()),
                street_address = txtAddress.Text,
                apt_suite = txtApt.Text,
                city = txtCity.Text,
                state = ((ComboBoxItem)cmbState.SelectedItem).Content.ToString(),
                zip_code = txtZip.Text,
                room_type = ((ComboBoxItem)cmbRoomType.SelectedItem).Content.ToString(),
                room_floor = ((ComboBoxItem)cmbFloor.SelectedItem).Content.ToString(),
                room_number = ((ComboBoxItem)cmbRoomNumber.SelectedItem).Content.ToString(),
                total_bill = (float)totalBill,
                payment_type = finalizebill.paymentType,
                card_type = finalizebill.CardType,
                card_number = finalizebill.paymentCardNumber,
                card_exp = finalizebill.MM_YY_Of_Card,
                card_cvc = finalizebill.CVC_Of_Card,
                arrival_time = dpEntryDate.SelectedDate ?? new DateTime(),
                leaving_time = dpDepartureDate.SelectedDate ?? new DateTime(),
                check_in = chkCheckIn.IsChecked ?? false,
                break_fast = breakfastQty,
                lunch = lunchQty,
                dinner = dinnerQty,
                cleaning = cleaning,
                towel = towel,
                s_surprise = surprise,
                supply_status = chkFoodStatus.IsChecked ?? false,
                food_bill = foodmenuWin.foodBill
            };
            context.reservations.Add(reservation);
            context.SaveChanges();

        }
    }
}
