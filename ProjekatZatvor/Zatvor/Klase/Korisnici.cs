using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Klase
{
    class Korisnici
    {
        private string username;
        private string password;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public Korisnici(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
