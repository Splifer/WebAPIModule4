using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIModule4.Models;

public partial class Dbproject2Context : DbContext
{
    public Dbproject2Context()
    {
    }

    public Dbproject2Context(DbContextOptions<Dbproject2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=connectString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Account__B9BE370F1FEE6395");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.GenderNameNavigation).WithMany(p => p.Accounts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Account_Gender");

            entity.HasOne(d => d.RoleNameNavigation).WithMany(p => p.Accounts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Account_Role");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__4659622934014D54");

            entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Order_Payment");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders).HasConstraintName("FK__Order__product_i__1CF15040");

            entity.HasOne(d => d.Shipping).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Order_Shipping");

            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasConstraintName("FK__Order__user_id__1BFD2C07");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__47027DF5F3C6A64F");

            entity.Property(e => e.ProductId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.BrandNameNavigation).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_Brand");

            entity.HasOne(d => d.Payment).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_Payment");

            entity.HasOne(d => d.Shipping).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_Shipping");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
