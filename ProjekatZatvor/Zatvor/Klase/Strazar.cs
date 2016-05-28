using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
    class Strazar: Uposlenik
    {
        private string trenutniSektor;

        public string TrenutniSektor
        {
            get
            {
                return trenutniSektor;
            }

            set
            {
                trenutniSektor = value;
            }
        }
    }
}
