using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulovky.Lokality
{
    public class LokalityItem
    {
        public string CisloReviru { get; set; }
        public string LokalitaNazov { get; set; }
        public string Popis {  get; set; }
        public string Gps {  get; set; }

        public LokalityItem(string cislo, string lokalita, string popis, string gps)
        {
            CisloReviru = cislo;
            LokalitaNazov = lokalita;
            Popis = popis;
            Gps = gps;
        }

    }
}
