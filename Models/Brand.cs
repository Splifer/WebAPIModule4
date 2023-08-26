using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPIModule4.Models;

[Table("Brand")]
public partial class Brand
{
    [Column("brand_id")]
    [StringLength(100)]
    public string BrandId { get; set; } = null!;

    [Key]
    [Column("brand_name")]
    [StringLength(100)]
    public string BrandName { get; set; } = null!;

    public string? Filter { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("BrandNameNavigation")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
