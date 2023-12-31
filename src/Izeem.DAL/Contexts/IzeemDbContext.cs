﻿using Izeem.Domain.Entities.Addresses;
using Izeem.Domain.Entities.Assets;
using Izeem.Domain.Entities.Carts;
using Izeem.Domain.Entities.Orders;
using Izeem.Domain.Entities.Payments;
using Izeem.Domain.Entities.Products;
using Izeem.Domain.Entities.Suppliers;
using Izeem.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System;

namespace Izeem.DAL.Contexts;

public class IzeemDbContext : DbContext
{
    public IzeemDbContext(DbContextOptions<IzeemDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Filtering "IsDeleted" status for entities
        modelBuilder.Entity<Address>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Asset>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Cart>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<CartItem>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Order>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<OrderItem>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Payment>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Product>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Supplier>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Vehicle>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<ProductCategory>().HasQueryFilter(e => !e.IsDeleted);
        #endregion
    }
}