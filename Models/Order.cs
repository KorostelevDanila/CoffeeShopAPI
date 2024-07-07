using System;
using System.Collections.Generic;

namespace CoffeeShopAPI.Models;

public partial class Order
{
    public int Id { get; set; }

    public string Date { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<ProductsInOrder> ProductsInOrders { get; set; } = new List<ProductsInOrder>();

    public virtual User User { get; set; } = null!;
}
