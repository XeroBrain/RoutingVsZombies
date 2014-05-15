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
using RtgVsZmbs.Objects;

namespace RtgVsZmbs.View
{
    using System.ComponentModel;

    /// <summary>
    /// Interaction logic for MainMenueView.xaml
    /// </summary>
    public partial class MainMenueView : Window
    {
        private User _currentUser;

        public MainMenueView(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            var logout = new LoginView();
            logout.Show();
            Close();
        }

        private void UeberlebenshandbuchClick(object sender, RoutedEventArgs e)
        {
            var survivalguide = new SurvivalguideView();
            survivalguide.Show();
        }

        private void ScoreClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ClassOverviewButton(object sender, RoutedEventArgs e)
        {
            var userOverview = new UserOverviewView();
            userOverview.Activate();
            userOverview.Show();
        }





    }
}
