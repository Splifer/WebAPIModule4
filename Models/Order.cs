using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPIModule4.Models;

[Table("Order")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public Guid OrderId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_count")]
    public int? ProductCount { get; set; }

    [Column("order_price", TypeName = "decimal(18, 3)")]
    public decimal? OrderPrice { get; set; }

    [Column("shipping_id")]
    [StringLength(100)]
    public string? ShippingId { get; set; }

    [Column("payment_id")]
    [StringLength(100)]
    public string? PaymentId { get; set; }

    public string? Filter { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("PaymentId")]
    [InverseProperty("Orders")]
    public virtual Payment? Payment { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Orders")]
    public virtual Product? Product { get; set; }

    [ForeignKey("ShippingId")]
    [InverseProperty("Orders")]
    public virtual Shipping? Shipping { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual Account? User { get; set; }
}
