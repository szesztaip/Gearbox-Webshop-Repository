using System;
using System.Collections.Generic;

namespace GearBoxMaintainApp;

public partial class Vasarlo
{
    public Guid Id { get; set; }

    public string FelhasznaloNev { get; set; } = null!;

    public string Telefonszam { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public int Jogosultsag { get; set; }

}
