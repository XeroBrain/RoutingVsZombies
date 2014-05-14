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

        private Int32 _ID;

        private string _surname;

        private string _username;

        //TODO: Salt n stuff for save psw gen
        private string _password;

        //TODO: UserEnum
        private bool _isAdmin;
        
        public User(Int32 id,string name, string surname, string username, string password, bool usertype)
        {
            this._name = name;
            this._surname = surname;
            this._password = password;
            this._isAdmin = usertype;
            this._username = username;
            _ID = id;
        }
    }
}
