using System;
using System.Collections.Generic;

namespace Gearbox_Back_End.Models;

public partial class Kosar
{
    public Guid Id { get; set; }

    public Guid TermekId { get; set; }

    public string TermekNev { get; set; } = null!;

    public int Db { get; set; }

    public int TermekAr { get; set; }

    public Guid VasarloId { get; set; }

    public virtual Termek Termek { get; set; } = null!;

    public virtual Vasarlo Vasarlo { get; set; } = null!;
}
