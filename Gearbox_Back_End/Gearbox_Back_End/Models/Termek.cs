using System;
using System.Collections.Generic;

namespace Gearbox_Back_End.Models;

public partial class Termek
{
    public string Id { get; set; } = null!;

    public string Nev { get; set; } = null!;

    public string Leiras { get; set; } = null!;

    public int Ar { get; set; }

    public bool VanEraktaron { get; set; }

    public byte[] Kep { get; set; } = null!;

    public virtual ICollection<Kosar> Kosars { get; set; } = new List<Kosar>();
}
