using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPIModule4.Models;

[Table("Role")]
public partial class Role
{
    [Column("role_id")]
    [StringLength(100)]
    public string RoleId { get; set; } = null!;

    [Key]
    [Column("role_name")]
    [StringLength(100)]
    public string RoleName { get; set; } = null!;

    public string? Filter { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("RoleNameNavigation")]
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
