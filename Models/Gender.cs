using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPIModule4.Models;

[Table("Gender")]
public partial class Gender
{
    [Column("gender_id")]
    [StringLength(100)]
    public string GenderId { get; set; } = null!;

    [Key]
    [Column("gender_name")]
    [StringLength(100)]
    public string GenderName { get; set; } = null!;

    [Unicode(false)]
    public string? Filter { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("GenderNameNavigation")]
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
