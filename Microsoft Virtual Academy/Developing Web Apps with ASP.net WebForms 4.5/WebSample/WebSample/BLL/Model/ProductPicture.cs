//base libraries
using System;
using System.Collections.Generic;

//added imports
using System.ComponentModel.DataAnnotations;

namespace WebSample.BLL.Model
{
    public class ProductPicture
    {
        [Key, Display(Name = "Id"), ScaffoldColumn(false)]
        public int PictureID { get; set; }

        [Required, StringLength(100), Display(Name = "Picture Title")]
        public string Title { get; set; }

        [StringLength(10000), Display(Name = "Picture Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required, DataType(DataType.ImageUrl)]
        public string FileLocation { get; set; }
        [Required, DataType(DataType.ImageUrl)]
        public string ThumbFilLocation { get; set; }

        [Required, DataType("Boolean")]
        public bool UseAsLogoPicture { get; set; }

        [Required, Display(Name = "Created on"), DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [Required, Display(Name = "BackgroundColor"), DataType("Color")]
        public string BackgroundColor { get; set; }

        //relational properties
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}