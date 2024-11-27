﻿using System;
using System.Collections.Generic;

namespace FunctionBasedPlanning.DataAccess.Data;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
