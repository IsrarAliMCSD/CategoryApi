using System;
using System.Collections.Generic;

namespace Core_CategoryApi.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Detail { get; set; }

    public decimal? ProductPrice { get; set; }
    public string ContentType { get; set; }
    public byte[] ContentData { get; set; }

    public string? ProductUrl { get; set; }

    public string? ImageName { get; set; }

    public string? ImageFormat { get; set; }

    public byte[]? Image { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatdDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }
    public int? CategoryId { get; set; }

    public bool? IsActive { get; set; }
    public virtual Category? Category { get; set; }

}
