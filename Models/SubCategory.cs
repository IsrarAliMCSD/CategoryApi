using System;
using System.Collections.Generic;

namespace Core_CategoryApi.Models;

public partial class SubCategory
{
    public int SubCategoryId { get; set; }

    public string? SubCategoryName { get; set; }

    public string? SubCaegoryDetail { get; set; }

    public int? CategoryId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatdDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Category? Category { get; set; }
}
