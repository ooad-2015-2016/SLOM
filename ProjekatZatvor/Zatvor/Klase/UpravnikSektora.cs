using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
    class UpravnikSektora : Uposlenik
    {
        private string sketor;

        public string Sketor
        {
            get
            {
                return sketor;
            }

            set
            {
                sketor = value;
            }
        }
    }
}
