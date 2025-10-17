using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UPFirst.Data;

public partial class Basket
{
    public int Id { get; set; }

    [Display(AutoGenerateField = false)]
    public int UserId { get; set; }

    [Display(AutoGenerateField = false)]
    public int ItemId { get; set; }

    public decimal? Quantity { get; set; }

    //public string Item { get; set; } = string.Empty;
    public virtual Item Item { get; set; } = null!;

    //public string User { get; set; } = string.Empty;
    public virtual User User { get; set; } = null!;
}
