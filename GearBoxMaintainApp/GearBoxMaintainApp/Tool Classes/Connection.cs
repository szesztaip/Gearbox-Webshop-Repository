using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace GearBoxMaintainApp
{
    internal class Connection
    {
        string location = "https://localhost:7063/";

        public string Url() {
            return location;
        }
    }
}
