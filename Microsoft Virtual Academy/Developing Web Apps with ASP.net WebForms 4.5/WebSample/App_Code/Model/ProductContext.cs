using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

public class ProductContext : DbContext
{
    public DbSet<ToyCategory> ToyCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductPicture> ProductPictures { get; set; }

    public ProductContext() : base("WebSampleConnectionString") { }    
}