using System;
using System.Collections.Generic;

namespace ShopStore.Terminal.Models;

public partial class Category
{
    public short CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }
}
