using Izeem.Domain.Entities.Addresses;
using Izeem.Domain.Entities.Assets;
using Izeem.Domain.Entities.Carts;
using Izeem.Domain.Entities.Orders;
using Izeem.Domain.Entities.Payments;
using Izeem.Domain.Entities.Products;
using Izeem.Domain.Entities.Suppliers;
using Izeem.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

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
}