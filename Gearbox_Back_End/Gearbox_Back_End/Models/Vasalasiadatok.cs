using System;
using System.Collections.Generic;

namespace Gearbox_Back_End.Models;

public partial class Vasalasiadatok
{
    public Guid Id { get; set; }

    public Guid VasarloId { get; set; }

    public string Megye { get; set; } = null!;

    public Guid KosarId { get; set; }

    public string Telepules { get; set; } = null!;

    public string UtcaHazszam { get; set; } = null!;

    public virtual Kosar Kosar { get; set; } = null!;

    public virtual Vasarlo Vasarlo { get; set; } = null!;
}
