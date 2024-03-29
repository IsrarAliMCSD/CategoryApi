﻿using System;
using System.Collections.Generic;

namespace Core_CategoryApi.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? Detail { get; set; }

    public string? CatUrl { get; set; }

    public string? ImageName { get; set; }

    public string? ImageFormat { get; set; }

    public byte[]? Image { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatdDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; } = new List<SubCategory>();
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
