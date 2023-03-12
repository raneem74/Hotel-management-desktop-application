using HotelManegmantWpfApp.Context;
using HotelManegmantWpfApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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


namespace HotelManegmantWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FrontendContext context = new FrontendContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        internal void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string name = textBox.Name;
            if (textBox.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri(@"assets\"+ $"{name}" +".PNG", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                textBox.Background = textImageBrush;
            }
            else
            {

                textBox.Background = Brushes.White;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = context.Frontends.Where(i => i.UserName == Username.Text.Trim() && i.Password == Password.Text.Trim()).Count();

            if (result>0)
            {
                Window1 frontWin = new Window1();
                this.Close();
                frontWin.Show();
            }
            else
            {
                MessageBoxResult failedLogin = MessageBox.Show("Login failed", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
    }
}
