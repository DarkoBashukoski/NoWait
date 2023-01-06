using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoWait.Models;

namespace NoWait.Data; 

public class NoWaitContext : IdentityDbContext<ApplicationUser> {
    public NoWaitContext(DbContextOptions<NoWaitContext> options) : base(options) {}

    public DbSet<MenuItem>? MenuItems { get; set;}
    public DbSet<Ingredient>? Ingredients { get; set;}
    public DbSet<Order>? Orders { get; set;}
    public DbSet<Table>? Tables { get; set;}
    public DbSet<Reservation>? Reservations { get; set;}
    public DbSet<Chair>? Charis { get; set; }
    public DbSet<Wall>? Walls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MenuItem>().ToTable("MenuItem");
        modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
        modelBuilder.Entity<Order>().ToTable("Order");
        modelBuilder.Entity<Table>().ToTable("Table");
        modelBuilder.Entity<Reservation>().ToTable("Reservation");
        modelBuilder.Entity<Chair>().ToTable("Chair");
        modelBuilder.Entity<Wall>().ToTable("Wall");
    }
}