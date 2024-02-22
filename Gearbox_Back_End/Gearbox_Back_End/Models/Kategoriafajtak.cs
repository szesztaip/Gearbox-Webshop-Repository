using System;
using System.Collections.Generic;

namespace Gearbox_Back_End.Models;

public partial class Kategoriafajtak
{
    public int Id { get; set; }

    public string KategoriaNev { get; set; } = null!;

    public virtual ICollection<Termek> Termeks { get; set; } = new List<Termek>();
}
