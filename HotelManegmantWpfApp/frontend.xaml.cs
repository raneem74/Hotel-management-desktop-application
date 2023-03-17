using ControlzEx.Standard;
using HotelManegmantWpfApp.Context;
using HotelManegmantWpfApp.Entities;
using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.UI.WebControls;
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

        FrontendContext context = new FrontendContext();

        public int totalAmount = 0;
        foodMenuWindow foodmenuWin = new foodMenuWindow();//new with defualt params
        Finalizebill finalizebill;

        private double finalizedTotalAmount = 0.0;
        private string paymentType;
        private string paymentCardNumber;
        private string MM_YY_Of_Card;
        private string CVC_Of_Card;
        private string CardType;
        public Boolean editClicked = false;
        public Boolean taskFinder = false;
        double totalBill = 0;
        int breakfastQty;
        int lunchQty;
        int dinnerQty;
        bool cleaning;
        bool towel;
        bool surprise;

        public Int32 primartyID = 0;
        public string FPayment, FCnumber, FcardExpOne, FcardExpTwo, FCardCVC;
        private int lunch = 0; private int breakfast = 0; private int dinner = 0;


        ObservableCollection<Reservation> OccupiedList ;
        List<Reservation> ReservedList;
        public Window1()
        {

            InitializeComponent();

            context.reservations.Load();
            dataGridReservation.ItemsSource = context.reservations.Local.ToObservableCollection();

            ReservedList = context.reservations.Where(i => i.check_in == true).ToList();
            var result =context.reservations.Where(i => i.check_in == false);
            OccupiedList = new ObservableCollection<Reservation>(result);

            setOccupiedRoom();
            setReservedRoom();

            //UpdateAvailableRooms();
        

        }


        private void btnFoodAndMenu_Click(object sender, RoutedEventArgs e)
        {
            foodmenuWin = new foodMenuWindow();

            foodmenuWin.Show();
            this.IsEnabled = false;
            foodmenuWin.Topmost = true;

         
             breakfastQty = (int)foodmenuWin.breakfastQTY.Value ;
             lunchQty = (int)foodmenuWin.breakfastQTY.Value;
             dinnerQty = (int)foodmenuWin.dinnerQTY.Value;

            cleaning = foodmenuWin.cleaning;
            towel = foodmenuWin.towel;
            surprise = foodmenuWin.surprise;

            

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
            string BirthDay = ((ComboBoxItem)cmbMonth.SelectedItem).Content.ToString()+"-"+((ComboBoxItem)cmbDay.SelectedItem).Content.ToString()+"-"+txtYear.Text;
            //Reservation reservation = new Reservation()
            //{
            //    first_name = txtFname.Text,
            //    last_name = txtSname.Text,
            //    birth_day = BirthDay,
            //    gender = ((ComboBoxItem)cmbGender.SelectedItem).Content.ToString(),
            //    phone_number = txtPhoneNumber.Text,
            //    email_address = txtEmail.Text,
            //    number_guest = int.Parse(((ComboBoxItem)cmbGstNumber.SelectedItem).Content.ToString()),
            //    street_address = txtAddress.Text,
            //    apt_suite = txtApt.Text,
            //    city = txtCity.Text,
            //    state = ((ComboBoxItem)cmbState.SelectedItem).Content.ToString(),
            //    zip_code = txtZip.Text,
            //    room_type = ((ComboBoxItem)cmbRoomType.SelectedItem).Content.ToString(),
            //    room_floor = ((ComboBoxItem)cmbFloor.SelectedItem).Content.ToString(),
            //    room_number = ((ComboBoxItem)cmbRoomNumber.SelectedItem).Content.ToString(),
            //    total_bill = (float)totalBill,
            //    payment_type = finalizebill.paymentType,
            //    card_type = finalizebill.CardType,
            //    card_number = finalizebill.paymentCardNumber,
            //    card_exp = finalizebill.MM_YY_Of_Card,
            //    card_cvc = finalizebill.CVC_Of_Card,
            //    arrival_time = dpEntryDate.SelectedDate ?? new DateTime(),
            //    leaving_time = dpDepartureDate.SelectedDate ?? new DateTime(),
            //    check_in = chkCheckIn.IsChecked ?? false,
            //    break_fast = breakfastQty,
            //    lunch = lunchQty,
            //    dinner = dinnerQty,
            //    cleaning = cleaning,
            //    towel = towel,
            //    s_surprise = surprise,
            //    supply_status = chkFoodStatus.IsChecked ?? false,
            //    food_bill = foodmenuWin.foodBill
            //};

            Reservation reservation = new Reservation();
            
                reservation.first_name = txtFname.Text;
                reservation.last_name = txtSname.Text;
                reservation.birth_day = BirthDay;
                reservation.gender = ((ComboBoxItem)cmbGender.SelectedItem).Content.ToString();
                reservation.phone_number = txtPhoneNumber.Text;
                reservation.email_address = txtEmail.Text;
                reservation.number_guest = int.Parse(((ComboBoxItem)cmbGstNumber.SelectedItem).Content.ToString());
                reservation.street_address = txtAddress.Text;
                reservation.apt_suite = txtApt.Text;
                reservation.city = txtCity.Text;
                reservation.state = ((ComboBoxItem)cmbState.SelectedItem).Content.ToString();
                reservation.zip_code = txtZip.Text;
                reservation.room_type = ((ComboBoxItem)cmbRoomType.SelectedItem).Content.ToString();
                reservation.room_floor = ((ComboBoxItem)cmbFloor.SelectedItem).Content.ToString();
                reservation.room_number = ((ComboBoxItem)cmbRoomNumber.SelectedItem).Content.ToString();
                reservation.total_bill = (float)totalBill;
                reservation.payment_type = finalizebill.paymentType;
                reservation.card_type = finalizebill.CardType;
                reservation.card_number = finalizebill.paymentCardNumber;
                reservation.card_exp = finalizebill.MM_YY_Of_Card;
                reservation.card_cvc = finalizebill.CVC_Of_Card;
                reservation.arrival_time = dpEntryDate.SelectedDate ?? new DateTime();
                reservation.leaving_time = dpDepartureDate.SelectedDate ?? new DateTime();
                reservation.check_in = chkCheckIn.IsChecked ?? false;
                reservation.break_fast = breakfastQty;
                reservation.lunch = lunchQty;
                reservation.dinner = dinnerQty;
                reservation.cleaning = cleaning;
                reservation.towel = towel;
                reservation.s_surprise = surprise;
                reservation.supply_status = chkFoodStatus.IsChecked ?? false;
                reservation.food_bill = foodmenuWin.foodBill;
           
            context.reservations.Add(reservation);
            context.SaveChanges();

            reset_frontend();
            setOccupiedRoom(reservation.room_number.Trim());
            setReservedRoom();
            //UpdateAvailableRooms();
        }

        private void setOccupiedRoom(string RoomNumber)
        {
            var result = context.reservations.Where(i => i.check_in == false && i.room_number.Trim() != RoomNumber );
            OccupiedList = new ObservableCollection<Reservation>(result);

            lstOccupied.ItemsSource = OccupiedList;
        }

        private void setOccupiedRoom()
        {
            var result = context.reservations.Where(i => i.check_in == false);
            OccupiedList = new ObservableCollection<Reservation>(result);

            lstOccupied.ItemsSource = OccupiedList;
        }
        private void setReservedRoom()
        {
            ReservedList = context.reservations.Where(i => i.check_in == true).ToList();

            lstReserved.ItemsSource = ReservedList;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            Reservation updated = context.reservations.Where(i => i.Id == primartyID).FirstOrDefault();
            
            string BirthDay = ((ComboBoxItem)cmbMonth.SelectedItem).Content.ToString() + "-" + ((ComboBoxItem)cmbDay.SelectedItem).Content.ToString() + "-" + txtYear.Text;

            updated.first_name = txtFname.Text;
            updated.last_name = txtSname.Text;
            updated.birth_day = BirthDay;
            updated.gender = ((ComboBoxItem)cmbGender.SelectedItem).Content.ToString();
            updated.phone_number = txtPhoneNumber.Text;
            updated.email_address = txtEmail.Text;
            updated.number_guest = int.Parse(((ComboBoxItem)cmbGstNumber.SelectedItem).Content.ToString());
            updated.street_address = txtAddress.Text;
            updated.apt_suite = txtApt.Text;
            updated.city = txtCity.Text;
            updated.state = ((ComboBoxItem)cmbState.SelectedItem).Content.ToString();
            updated.zip_code = txtZip.Text;
            updated.room_type = ((ComboBoxItem)cmbRoomType.SelectedItem).Content.ToString();
            updated.room_floor = ((ComboBoxItem)cmbFloor.SelectedItem).Content.ToString();
            updated.room_number = ((ComboBoxItem)cmbRoomNumber.SelectedItem).Content.ToString();
            updated.total_bill = (float)totalBill;
            //updated.payment_type = finalizebill.paymentType;
            //updated.card_type = finalizebill.CardType;
            //updated.card_number = finalizebill.paymentCardNumber;
            //updated.card_exp = finalizebill.MM_YY_Of_Card;
            //updated.card_cvc = finalizebill.CVC_Of_Card;
            updated.arrival_time = dpEntryDate.SelectedDate ?? new DateTime();
            updated.leaving_time = dpDepartureDate.SelectedDate ?? new DateTime();
            updated.check_in = chkCheckIn.IsChecked ?? false;
            updated.break_fast = breakfastQty;
            updated.lunch = lunchQty;
            updated.dinner = dinnerQty;
            updated.cleaning = cleaning;
            updated.towel = towel;
            updated.s_surprise = surprise;
            updated.supply_status = chkFoodStatus.IsChecked ?? false;
            updated.food_bill = foodmenuWin.foodBill;
            context.SaveChanges();
            reset_frontend();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //search button
            //var searchtxt = 
            string SQLCommand = $"Select * from reservations where Id like '%{txtSearch.Text}%' OR last_name like '%{txtSearch.Text}%' OR first_name like '%{txtSearch.Text}%' OR gender like '%{txtSearch.Text}%' OR state like '%{txtSearch.Text}%' OR city like '%{txtSearch.Text}%' OR room_number like '%{txtSearch.Text}%' OR room_type like '%{txtSearch.Text}%' OR email_address like '%{txtSearch.Text}%' OR phone_number like '%{txtSearch.Text}%' ";
            var result = context.reservations.FromSqlRaw <Reservation>(SQLCommand).ToList();
            SearchGrid.ItemsSource = result;

        }
        private void UpdateAvailableRooms()
        {
            var result = OccupiedList.Select(i => i.room_number.Trim()).ToList();
            ObservableCollection<string> cmnRoomNumberSource = new ObservableCollection<string>(result);
            //cmbRoomNumber.ItemsSource = cmnRoomNumberSource;

        }

        private void btnNewReservation_Click(object sender, RoutedEventArgs e)
        {
            btnSubmit.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
            btnDelete.Visibility = Visibility.Hidden;
            btnEditExistingReservation.Visibility = Visibility.Hidden;
            reset_frontend();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (primartyID > 1000)
            {
                Reservation deleted = context.reservations.Where(i => i.Id == primartyID).FirstOrDefault();
                context.reservations.Remove(deleted);
                context.SaveChanges();
                reset_frontend();
            }
        }

        private void cmbReservationTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UpdateAvailableRooms();
            int IDToEdit = int.Parse((cmbReservationTitle.SelectedItem).ToString().Substring(0, 4).Replace(" ", string.Empty));
            var reservationToEdit = context.reservations.Where(i => i.Id == IDToEdit).FirstOrDefault();

            taskFinder = true;
            string ID = reservationToEdit.Id.ToString();
            string first_name = reservationToEdit.first_name.ToString();
            string last_name = reservationToEdit.last_name.ToString();
            string birth_day = reservationToEdit.birth_day.ToString();
            string gender = reservationToEdit.gender.ToString();
            string phone_number = reservationToEdit.phone_number.ToString();
            string email_address = reservationToEdit.email_address.ToString();
            string number_guest = reservationToEdit.number_guest.ToString();
            string street_address = reservationToEdit.street_address.ToString();
            string apt_suite = reservationToEdit.apt_suite.ToString();
            string city = reservationToEdit.city.ToString();
            string state = reservationToEdit.state.ToString();
            string zip_code = reservationToEdit.zip_code.ToString();

            string room_type = reservationToEdit.room_type.ToString();
            string room_floor = reservationToEdit.room_floor.ToString();
            string room_number = reservationToEdit.room_number.ToString();

            string payment_type = reservationToEdit.payment_type.ToString();
            string card_number = reservationToEdit.card_number.ToString();
            string card_exp = reservationToEdit.card_exp.ToString();
            string card_cvc = reservationToEdit.card_cvc.ToString();

            string _cleaning = reservationToEdit.cleaning.ToString();
            string _towel = reservationToEdit.towel.ToString();
            string _surprise = reservationToEdit.s_surprise.ToString();
            if (_cleaning == "True")
            {
                cleaning = true;
            }
            else { cleaning = false; }

            if (_towel == "True")
            {
                towel = true;
            }
            else { towel = false; }
            if (_surprise == "True")
            {
                surprise = true;
            }
            else
            {
                surprise = false;
            }
            
            cmbRoomNumber.SelectedItem = cmbRoomNumber.Items.OfType<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == reservationToEdit.room_number.Trim().ToString());

            FPayment = payment_type; FCnumber = card_number;
            FCardCVC = card_cvc; FcardExpOne = card_exp.Substring(0, card_exp.IndexOf('/'));
            FcardExpTwo = card_exp.Substring(card_exp.Length - Math.Min(2, card_exp.Length));
            string check_in = reservationToEdit.check_in.ToString();

            string supply_status = reservationToEdit.supply_status.ToString();
            string food_billD = reservationToEdit.food_bill.ToString();

            string arrival_date = Convert.ToDateTime(reservationToEdit.arrival_time).ToString("MM-dd-yyyy").Replace(" ", string.Empty);
            dpEntryDate.SelectedDate = Convert.ToDateTime(arrival_date);

            string leaving_date = Convert.ToDateTime(reservationToEdit.leaving_time).ToString("MM-dd-yyyy").Replace(" ", string.Empty);
            dpDepartureDate.SelectedDate = Convert.ToDateTime(leaving_date);
            //dpEntryDate.SelectedDate.ToShortDateString();
            //dpDepartureDate.SelectedDate.ToShortDateString();

            string _breakfast = reservationToEdit.break_fast.ToString();
            string _lunch = reservationToEdit.lunch.ToString();
            string _dinner = reservationToEdit.dinner.ToString();

            double Num;
            bool isNum = double.TryParse(_lunch, out Num);
            if (isNum)
            {
                lunch = Int32.Parse(_lunch);
            }
            else
            {
                lunch = 0;
            }
            isNum = double.TryParse(_breakfast, out Num);
            if (isNum)
            {
                breakfast = Int32.Parse(_breakfast);
            }
            else
            {
                breakfast = 0;
            }
            isNum = double.TryParse(_dinner, out Num);
            if (isNum)
            {
                dinner = Int32.Parse(_dinner);
            }
            else
            {
                dinner = 0;
            }



            foodmenuWin.foodBill = Convert.ToInt32(food_billD);

            if (supply_status == "True")
            {
                chkFoodStatus.IsChecked = true;
            }
            else
            {
                chkFoodStatus.IsChecked = false;
            }


            txtFname.Text = first_name;
            txtSname.Text = last_name;
            txtPhoneNumber.Text = phone_number;
            cmbGender.SelectedItem = cmbGender.Items.OfType<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == reservationToEdit.gender.Trim().ToString());


            //string[] birthDay = reservationToEdit.birth_day.Split(',');
            //cmbDay.SelectedItem = birth_day.Substring(birth_day.IndexOf('-') + 1, 2);
            cmbDay.SelectedItem = cmbDay.Items.OfType<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == reservationToEdit.birth_day.Substring(reservationToEdit.birth_day.IndexOf('-') + 1, 2).Trim().ToString());
            cmbMonth.SelectedItem = cmbMonth.Items.OfType<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == reservationToEdit.birth_day.Substring( 0 , reservationToEdit.birth_day.IndexOf('-')).Trim().ToString());

            txtYear.Text = birth_day.Substring(birth_day.Length - Math.Min(4, birth_day.Length));

            txtEmail.Text = email_address;
            cmbGstNumber.SelectedItem = cmbGstNumber.Items.OfType<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == reservationToEdit.number_guest.ToString());


            txtAddress.Text = street_address;
            txtApt.Text = apt_suite;
            txtCity.Text = city;
            cmbState.SelectedItem = cmbState.Items.OfType<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == reservationToEdit.state.Trim().ToString());


            txtZip.Text = zip_code;
            cmbRoomType.SelectedValue = cmbRoomType.Items.OfType<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == reservationToEdit.room_type.Trim().ToString());


           
            cmbFloor.SelectedItem = cmbFloor.Items.OfType<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == reservationToEdit.room_floor.Trim().ToString());

            //cmbRoomNumber.SelectedItem = room_number.Replace(" ", string.Empty);

            if (check_in == "True")
            {
                chkCheckIn.IsChecked = true;
            }
            else
            {
                chkCheckIn.IsChecked = false;
            }


            primartyID = Convert.ToInt32(ID);
        }
    }
}
