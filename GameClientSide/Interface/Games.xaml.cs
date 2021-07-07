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
    /// Interaction logic for Games.xaml
    /// </summary>
    public partial class Games : Page
    {
        readonly GameServiceClient srvc;
        readonly User user;
        public Games()
        {
            InitializeComponent();
            srvc = new GameServiceClient();
        }
        public Games(User user) : this()
        {
            this.user = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScoreList scores;
            if (user != null)
            {
                scores = srvc.GetScoresByUser(user);
                scoreView.ItemsSource = scores;
                button.Content = scores.Count;
            }
            else
            {
                scores = srvc.GetAllScores();
                scoreView.ItemsSource = scores;
                button.Content = scores.Count;
            }
        }
    }
}
