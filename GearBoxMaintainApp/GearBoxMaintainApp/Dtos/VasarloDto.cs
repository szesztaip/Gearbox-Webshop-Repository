using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearBoxMaintainApp.Dtos
{
    internal class VasarloDto
    {
        public Guid id { get; set; }

        public string felhasznalonev { get; set; } = null!;

        public string telefonszam { get; set; } = null!;

        public string jelszo {  get; set; }

        public string email { get; set; } = null!;

        public int jogosultsag { get; set; }
    }
}
