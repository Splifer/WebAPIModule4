using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPIModule4.Models;

[Table("Payment")]
public partial class Payment
{
    [Key]
    [Column("payment_id")]
    [StringLength(100)]
    public string PaymentId { get; set; } = null!;

    [Column("payment_name")]
    public string PaymentName { get; set; } = null!;

    public string? Filter { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("Payment")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("Payment")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
