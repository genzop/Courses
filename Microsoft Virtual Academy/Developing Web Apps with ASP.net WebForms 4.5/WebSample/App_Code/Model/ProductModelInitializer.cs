using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

public class ProductModelInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
{
    public ProductModelInitializer() { }

    protected override void Seed(ProductContext context)
    {
        GetCategories().ForEach(c => context.ToyCategories.Add(c));
        GetProducts().ForEach(p => context.Products.Add(p));
    }

    private static List<ToyCategory> GetCategories()
    {
        var toyCategories = new List<ToyCategory>
        {
            new ToyCategory()
            {
                CategoryID = 1,
                Name = "Model Airplanes",
                Description = "RC Battery and JetFuel Propelled Airplanes",
                ShortDescription = "Airplanes",
                LastUpdated = DateTime.Now
            },
            new ToyCategory()
            {
                CategoryID = 2,
                Name = "Model Helicopters",
                Description = "RC Battery and JetFuel Propelled Helicopters",
                ShortDescription = "Helicopters",
                LastUpdated = DateTime.Now
            }
        };

        return toyCategories;
    }

    private static List<Product> GetProducts()
    {
        var products = new List<Product>
        {
            new Product()
            {
                ProductID = 1,
                Name = "Tayco Aerobatics Plane",
                Description = "A light model plane that is very manoevrable and will do some great aerobatics.",
                ShortDescription = "A light model plane.",
                Price = 34,
                UnitsInStock = 4,
                LastUpdated = DateTime.Now,
                CategoryID = 1
            },
            new Product()
            {
                ProductID = 2,
                Name = "Tayco Light Helo",
                Description = "A light but agile helicopter with a range of up 100 meters.",
                ShortDescription = "A light but agile helicopter.",
                Price = 42,
                UnitsInStock = 9,
                LastUpdated = DateTime.Now,
                CategoryID = 2
            }
        };

        return products;
    }
}