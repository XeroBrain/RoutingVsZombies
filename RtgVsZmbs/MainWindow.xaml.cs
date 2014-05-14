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

namespace RtgVsZmbs
{
    using RtgVsZmbs.View;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
          InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
           
                var username = UserField.GetLineText(0);

                var password = PasswordField.Password;

                //TODO: Login Validation
            bool loginValidation = username.Any() && password.Any();

            if (loginValidation)
            {
                var mainWindow = new MainMenueView();
                mainWindow.Show();
                Close();
            }
            else
            {
                InvalidLoginTxt.Visibility = Visibility.Visible;
            }


        }
    }
}
