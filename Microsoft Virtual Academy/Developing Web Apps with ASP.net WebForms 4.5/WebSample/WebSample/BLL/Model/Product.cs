//base libraries
using System;
using System.Collections.Generic;

//added imports
using System.ComponentModel.DataAnnotations;

namespace WebSample.BLL.Model
{
    public class Product
    {
        [Key, Display(Name="Id"), ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, StringLength(100), Display(Name="Name"),]
        public string Name { get; set; }

        [Required, StringLength(10000), Display(Name="Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name="Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Listing Price"), DataType("Integer"), Range(0, 500)]
        public decimal Price { get; set; }

        [Display(Name = "Units"), DataType("Integer"), Range(0, 100)]
        public int UnitsInStock { get; set; }

        public string LogoPictureThumbFile { get; set; }

        [Display(Name="Stock Last Update"), DataType(DataType.DateTime)]
        public DateTime LastUpdated { get; set; }

        //relational properties - for the categories
        public int CategoryID { get; set; }
        public virtual ToyCategory Category { get; set; }

        //for the pictures
        public virtual ICollection<ProductPicture> Pictures { get; set; }
    }
}