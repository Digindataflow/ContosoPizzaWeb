using System;
using System.Collections.Generic;

namespace ContosoPizzaWeb.Models;

public partial class Coupon
{
    public long Id { get; set; }

    public string Description { get; set; } = null!;

    public string? Expiration { get; set; }
}
