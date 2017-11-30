//base libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//added imports
using System.Data.Entity;

namespace WebSample.BLL.Model
{
    public class ProductModelInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.ToyCategories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<ToyCategory> GetCategories()
        {
            var toyCategories = new List<ToyCategory> {
                new ToyCategory
                {
                    CategoryID = 1,
                    Name = "Model Airplanes",
                    Description = "RC Battery and JetFuel Propelled Airplanes. Here you will find aircraft from the smalles battery operated models to jetfuel propelled models",
                    ShortDescription = "RC Battery and JetFuel Propelled Airplanes",
                    LastUpdated = DateTime.Now
                },
                new ToyCategory
                {
                    CategoryID = 2,
                    Name = "Model Helicopters",
                    Description = "RC Battery and JetFuel Propelled Helicopters. Products range from simple handheld models, to helicopters equipped with webcams and jetfuel engines",
                    ShortDescription = "RC Battery and JetFuel Propelled Helicopters",
                    LastUpdated = DateTime.Now
                }
            };

            return toyCategories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    Name = "Tayco Aerobatics Plane",
                    Description = "A light model plane that is very manoevrable and will do some great aerobatics. Age: from 12 years old", 
                    ShortDescription = "A light model plane that is very manoevrable...",
                    Price = 34,
                    UnitsInStock = 4,
                    LastUpdated = DateTime.Now,
                    CategoryID = 1
               },
                 new Product
                {
                    ProductID = 1,
                    Name = "Tayco Light Helo",
                    Description = "A light but agile helicpoter with a range of up 100 meters. Can be equipped with a webcam. Age: from 12 years old", 
                    ShortDescription = "A light but agile helicpoter with a range of up 100 meters...",
                    Price = 42,
                    UnitsInStock = 9,
                    LastUpdated = DateTime.Now,
                    CategoryID = 2
               }
            };

            return products;
        }
        
    }
}