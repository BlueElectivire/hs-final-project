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
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        User user;
        readonly User u;
        UserList users;
        readonly GameServiceClient srvc;
        public Users()
        {
            InitializeComponent();
            srvc = new GameServiceClient();
            u = MainWindow.User;
            if (!u.IsAdmin)
            {
                update.Visibility = Visibility.Collapsed;
                delete.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users = srvc.GetAllUsers();
            lv.ItemsSource = users;
            button.Content = users.Count;
        }

        private void Lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user = (User)lv.SelectedItem;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Frame.Navigate(new Games(user));
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.User.IsAdmin)
                MainWindow.Frame.Navigate(new Update(user));
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.User.IsAdmin)
            {
                srvc.Delete(user);
                srvc.SaveChanges();
                MainWindow.Frame.Navigate(new Users());
            }
        }
    }
}
