using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearBoxMaintainApp.Dtos
{
    internal class TermekDto
    {

        public string nev { get; set; } = null!;

        public int kategoria { get; set; }

        public string meret { get; set; } = null!;

        public string leiras { get; set; } = null!;

        public int db { get; set; }

        public int ar { get; set; }

        public bool vanEraktaron { get; set; }

        public string kep { get; set; } = null!;
    }
}
