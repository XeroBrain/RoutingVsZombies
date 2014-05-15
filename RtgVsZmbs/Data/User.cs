using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtgVsZmbs.Objects
{
    public class User
    {
        private string _name;

        private Int64 _ID;

        public string _surname { get; set; }

        public string _username { get; set; }

        //TODO: Salt n stuff for save psw gen
        private string _password;

        //TODO: UserEnum
        private bool _isAdmin;
        
        public User(Int64 id, string username, string password, bool usertype)
        {
            _password = password;
            _isAdmin = usertype;
            _username = username;
            _ID = id;
        }
        
    }
}
