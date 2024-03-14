using System;
using System.Collections.Generic;

namespace GearBoxMaintainApp;

public partial class Vasalasiadatok
{
    public Guid Id { get; set; }

    public Guid VasarloId { get; set; }

    public string Megye { get; set; } = null!;

    public Guid KosarId { get; set; }

    public string Telepules { get; set; } = null!;

    public string UtcaHazszam { get; set; } = null!;

}
