using System;
using System.Collections.Generic;

namespace Gearbox_Back_End.Models;

public partial class Vasarlo
{
    public Guid Id { get; set; }

    public string FelhasznaloNev { get; set; } = null!;

    public int Telefonszam { get; set; }

    public string Email { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public int Jogosultsag { get; set; }

    public virtual Jogosultsagok JogosultsagNavigation { get; set; } = null!;

    public virtual ICollection<Kosarkapcsolat> Kosarkapcsolats { get; set; } = new List<Kosarkapcsolat>();
}
