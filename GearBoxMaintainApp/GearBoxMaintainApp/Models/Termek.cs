using System;
using System.Collections.Generic;

namespace GearBoxMaintainApp;

public partial class Termek
{
    public Guid Id { get; set; }

    public string Nev { get; set; } = null!;

    public int KategoriaId { get; set; }

    public Guid BesorolasId { get; set; }

    public string Meret { get; set; } = null!;

    public string Leiras { get; set; } = null!;

    public int Db { get; set; }

    public int Ar { get; set; }

    public bool VanEraktaron { get; set; }

    public string Kep { get; set; } = null!;

}
