using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtgVsZmbs.Objects
{
    public class User
    {
        private string Name;
        private string Surname;

        //TODO: Salt n stuff for save psw gen
        private string Password;

        //TODO: UserEnum
        private bool IsAdmin;
        
        private User(string name, string surname, string password, bool usertype)
        {
            this.Name = name;
            this.Surname = surname;
            this.Password = password;
            this.IsAdmin = usertype;
        }
    }
}
