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
using Interface.GameService;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Frame frame;
        static User user;
        public static User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        public static Frame Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
            }
        }
        public MainWindow(User user)
        {
            InitializeComponent();
            Frame = myFrame;
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            User = user;
        }

        private void HamburgerMenuItem_Selected(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Users());
        }

        private void HamburgerMenuItem_Selected_1(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Games());
        }
    }
}
