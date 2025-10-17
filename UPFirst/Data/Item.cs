using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UPFirst.Data;

public partial class Item
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal? Price { get; set; }

    //[Display(AutoGenerateField = false)]
    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
}
