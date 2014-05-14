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

namespace RtgVsZmbs.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var username = UserField.GetLineText(0);

                var password = PasswordField.Password;

                if (username.Any() && password.Any())
                {
                    var mainWindow = new MainMenueView(null);
                    mainWindow.Show();
                    Close();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           

            
        }
    }
}
