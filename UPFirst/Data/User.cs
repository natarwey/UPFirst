using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UPFirst.Data;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    //[Display(AutoGenerateField = false)]
    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
}
