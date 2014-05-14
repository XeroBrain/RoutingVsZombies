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
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data;
using RtgVsZmbs.Objects;

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
            bool loginValidation = false;
            User currentUser= null;
            var username = UserField.GetLineText(0);                          
            var password = GenerateHash(PasswordField.Password);
            using (var connection = new SqlConnection("Data Source=85.183.21.62,1433;"+"Initial Catalog=RoutingVsZombie;"+"User id=RVZLogin;"+"Password=ZombieNation21!;"))
            {
                var dataTable = new DataTable();
                var adapter = new SqlDataAdapter
                                  {
                                      SelectCommand =
                                          new SqlCommand("Select usrid,usrLogin,usrIsAdmin from Users where usrLogin=@Login and usrPassword=@Password", connection)
                                  };
                adapter.SelectCommand.Parameters.Add("@Login", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@Login"].Value = username;
                adapter.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@Password"].Value = password;
                adapter.Fill(dataTable);
                if(dataTable.Rows.Count == 1)
                { 
                    loginValidation = true;
                    currentUser = new User((Int32)dataTable.Rows[0]["usrid"], "", "", (String)dataTable.Rows[0]["usrLogin"], "", (Boolean)dataTable.Rows[0]["usrIsAdmin"]);             
                }           
            }            

            if (loginValidation)
            {                
                var mainWindow = new MainMenueView(currentUser);
                mainWindow.Show();
                Close();
            }
            else
            {
                InvalidLoginTxt.Visibility = Visibility.Visible;
            }


        }
        
        public static string GenerateHash(string text, Encoding enc = null)
        {
            if (enc == null)
                enc = Encoding.UTF8;

            byte[] buffer = enc.GetBytes(text);
            var cryptoTransformSha512 = new SHA512CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSha512.ComputeHash(buffer)).Replace("-", string.Empty);
        }
    }
}
