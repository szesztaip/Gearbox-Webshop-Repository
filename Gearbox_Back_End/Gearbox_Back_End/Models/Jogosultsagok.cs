using System;
using System.Collections.Generic;

namespace Gearbox_Back_End.Models;

public partial class Jogosultsagok
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public virtual ICollection<Vasarlo> Vasarlos { get; set; } = new List<Vasarlo>();
}
