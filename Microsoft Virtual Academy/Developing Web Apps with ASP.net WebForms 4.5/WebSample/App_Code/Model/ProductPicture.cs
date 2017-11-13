using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ProductPicture
{
    public int PictureID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public string FileLocation { get; set; }
    public string ThumbFilLocation { get; set; }
    public bool UseAsLogoPicture { get; set; }
    public DateTime CreatedOn { get; set; }
    public string BackgroundColor { get; set; }

    public int ProductID { get; set; }
    public virtual Product Product { get; set; }

    public ProductPicture() { }
}