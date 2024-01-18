using System;
using System.Collections.Generic;

namespace Gearbox_Back_End.Models;

public partial class Kosarkapcsolat
{
    public Guid Id { get; set; }

    public Guid VasarloId { get; set; }

    public virtual ICollection<Kosar> Kosars { get; set; } = new List<Kosar>();

    public virtual Vasarlo Vasarlo { get; set; } = null!;
}
