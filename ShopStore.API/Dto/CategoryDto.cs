using System;
using System.Collections.Generic;
using ShopStore.Data.Models;

namespace ShopStore.API.Dto;

public partial class CategoryDto
{
    public short CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

}
