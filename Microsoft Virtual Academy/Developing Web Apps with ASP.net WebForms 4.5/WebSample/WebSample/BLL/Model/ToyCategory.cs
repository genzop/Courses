//base libraries
using System;
using System.Collections.Generic;

//added imports
using System.ComponentModel.DataAnnotations;

namespace WebSample.BLL.Model
{
    public class ToyCategory
    {
        [Key, Display(Name = "Id"), ScaffoldColumn(false)]
        public int CategoryID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(10000), Display(Name = "Category Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        //relational definition properties
        public virtual ICollection<Product> Products { get; set; }
    }
}