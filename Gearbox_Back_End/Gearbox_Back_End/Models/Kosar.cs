using System;
using System.Collections.Generic;

namespace Gearbox_Back_End.Models;

public partial class Kosar
{
    public string Id { get; set; } = null!;

    public string TermekId { get; set; } = null!;

    public string TermekNev { get; set; } = null!;

    public int TermekAr { get; set; }

    public string VasarloId { get; set; } = null!;

    public virtual Termek Termek { get; set; } = null!;

    public virtual Vasarlo Vasarlo { get; set; } = null!;
}
