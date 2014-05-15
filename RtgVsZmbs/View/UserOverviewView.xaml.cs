using System.Collections.Generic;
using System.Windows;
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

        public List<User> UserList
        {
            get { return _userList;}
        }

        private List<User> _userList;

        public void LoadUsers()
        {
            _userList = new List<User>();
            var users = SQLFactory.GetAllUsers();
            foreach(var user in users)
            {
                _userList.Add(user);
            }
        }
    }
}
