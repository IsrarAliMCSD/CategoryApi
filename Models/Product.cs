using System;
using System.Collections.Generic;

namespace Core_CategoryApi.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Detail { get; set; }

    public bool? IsActive { get; set; }
}
