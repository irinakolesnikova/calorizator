using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calorizator
{
    [Serializable]
    class _Authorization
    {
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public _Authorization(string _login, string _password)
        {
            login = _login;
            password = _password;
        }


    }
}
