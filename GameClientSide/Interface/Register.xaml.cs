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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        readonly GameServiceClient srvc;
        readonly User user;
        public Register()
        {
            InitializeComponent();
            srvc = new GameServiceClient();
            user = new User();
            grid.DataContext = user;
        }
        private bool CheckUsername(string username)
        {
            return (srvc.GetUserByUsername(username) == null) && (username.Length > 8 && username.Length < 16);
        }
        private bool CheckPassword(string password)
        {
            if (password.Length < 8)
                return false;
            bool hasCap = false, hasLow = false, hasNum = false;
            char[] c = password.ToCharArray();
            foreach (char ch in c)
            {
                if (ch >= 65 && ch <= 90)
                    hasCap = true;
                else if (ch >= 97 && ch <= 122)
                    hasLow = true;
                else if (ch >= 48 && ch <= 59)
                    hasNum = true;
            }
            return (hasCap && hasLow && hasNum);
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
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            user.Password = password.Password;
            if (CheckUsername(user.Username))
            {
                if (CheckPassword(user.Password))
                {
                    if (CheckMail(user.Mail))
                    {
                        srvc.InsertUser(user);
                        if (srvc.SaveChanges() > 0)
                        {
                            MainWindow mw = new MainWindow(user);
                            mw.Show();
                            this.Close();
                        }
                        else
                            err.Text = "An error has occured";
                    }
                    else
                    {
                        err.Text = "Bad Mail";
                    }
                }
                else
                {
                    err.Text = "Bad Password";
                }
            }
            else
            {
                err.Text = "Bad Username";
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }
    }
}
