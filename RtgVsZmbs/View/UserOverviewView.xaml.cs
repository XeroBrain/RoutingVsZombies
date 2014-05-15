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
    /// <summary>
    /// Interaction logic for UserOverviewView.xaml
    /// </summary>
    public partial class UserOverviewView : Window
    {
        public UserOverviewView()
        {
            InitializeComponent();
            LoadUsers();
        }

        private List<User> _userList;

        public void LoadUsers()
        {
            _userList = new List<User>();
            var users = SQLFactory.getAllUsers();
            foreach(var user in users)
            {
                _userList.Add(user);
            }
        }
    }
}
