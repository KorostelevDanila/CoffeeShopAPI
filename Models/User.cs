using System;
using System.Collections.Generic;

namespace CoffeeShopAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? RegisterDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
