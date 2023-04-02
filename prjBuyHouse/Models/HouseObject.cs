using System;
using System.Collections.Generic;

namespace prjBuyHouse.Models;

public partial class HouseObject
{
    public int FId { get; set; }

    public Guid FGuid { get; set; }

    public string FName { get; set; } = null!;

    public decimal FPrice { get; set; }

    public string FDescription { get; set; } = null!;
}
