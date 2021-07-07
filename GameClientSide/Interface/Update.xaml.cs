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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Page
    {
        readonly User user;
        readonly User u;
        readonly GameServiceClient srvc = new GameServiceClient();
        public Update(User user)
        {
            InitializeComponent();
            this.user = user;
            u = MainWindow.User;
            if (!u.IsAdmin)
                MainWindow.Frame.Navigate(new Users());
            grid.DataContext = this.user;
            if (user.IsAdmin)
                admin.SelectedIndex = 0;
            else
                admin.SelectedIndex = 1;
        }
        private bool CheckMail(string mail)
        {
            string[] s = mail.Split('@');
            if (s.Length != 2)
                return false;
            string[] s1 = s[1].Split('.');
            if (s1.Length >= 2 && s1.Length <= 4)
                return true;
            return false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.IsAdmin = (admin.SelectedIndex == 0);
            if (CheckMail(user.Mail))
            {
                srvc.Update(user);
                if (srvc.SaveChanges() > 0)
                    MainWindow.Frame.Navigate(new Users());
                else
                    Error.Visibility = Visibility.Visible;
            }
            else
                Error.Visibility = Visibility.Visible;
        }
    }
}
