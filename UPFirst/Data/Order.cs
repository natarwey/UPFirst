using System;
using System.Collections.Generic;

namespace UPFirst.Data;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTimeOffset? Data { get; set; }

    public decimal? PriceTotal { get; set; }

    public virtual User User { get; set; } = null!;
}
