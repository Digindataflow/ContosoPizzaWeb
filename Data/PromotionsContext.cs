using System;
using System.Collections.Generic;
using ContosoPizzaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizzaWeb.Data;

public partial class PromotionsContext : DbContext
{
    public PromotionsContext(DbContextOptions<PromotionsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coupon> Coupons { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseSqlite("Data Source=.\\Promotions\\Promotions.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
