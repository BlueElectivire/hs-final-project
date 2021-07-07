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
using Interface.GameService;

namespace Interface
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        readonly GameServiceClient srvc;
        public Login()
        {
            InitializeComponent();
            srvc = new GameServiceClient();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            User user = srvc.GetUserByUsername(username.Text);
            if (user != null)
            {
                if (user.Password.Equals(password.Password))
                {
                    MainWindow main = new MainWindow(user);
                    main.Show();
                    this.Close();
                }
                else
                {
                    err.Text = "Wrong username or password";
                }
            }
            else
            {
                err.Text = "Wrong username or password";
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.Show();
            this.Close();
        }
    }
}
