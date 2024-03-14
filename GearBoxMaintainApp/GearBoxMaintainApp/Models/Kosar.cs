using System;
using System.Collections.Generic;

namespace GearBoxMaintainApp;

public partial class Kosar
{
    public Guid Id { get; set; }

    public Guid TermekId { get; set; }

    public string TermekNev { get; set; } = null!;

    public int Db { get; set; }

    public int TermekAr { get; set; }

    public Guid KosarId { get; set; }

}
