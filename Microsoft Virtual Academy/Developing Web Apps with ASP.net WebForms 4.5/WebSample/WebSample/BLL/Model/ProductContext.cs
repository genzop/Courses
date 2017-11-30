//base libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//added imports
using System.Data.Entity;

namespace WebSample.BLL.Model
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("WebSampleConnectionString")
        {
        }

        //properties to retrieve table entities
        public DbSet<ToyCategory> ToyCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
    }
}