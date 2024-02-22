﻿using System;
using System.Collections.Generic;

namespace Gearbox_Back_End.Models;

public partial class Termek
{
    public Guid Id { get; set; }

    public string Nev { get; set; } = null!;

    public int KategoriaId { get; set; }

    public string Leiras { get; set; } = null!;

    public int Db { get; set; }

    public int Ar { get; set; }

    public bool VanEraktaron { get; set; }

    public byte[] Kep { get; set; } = null!;

    public virtual Kategoriafajtak Kategoria { get; set; } = null!;

    public virtual ICollection<Kosar> Kosars { get; set; } = new List<Kosar>();
}
