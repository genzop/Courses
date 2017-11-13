using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ToyCategory
{
    public int CategoryID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public DateTime LastUpdated { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public ToyCategory() { }
}