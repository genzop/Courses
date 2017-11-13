using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public int UnitsInStock { get; set; }
    public string LogoPictureThumbFile { get; set; }
    public DateTime LastUpdated { get; set; }

    public int CategoryID { get; set; }
    public virtual ToyCategory Category { get; set; }
    public virtual ICollection<ProductPicture> Pictures { get; set; }

    public Product() { }
}