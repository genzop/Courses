using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//added imports
using WebSample.BLL.Model;
using System.Web.ModelBinding;
using WebSample.BLL.Utilities;

namespace WebSample.SiteAdministration
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        //create a db context object to operate queries on
        private readonly ProductContext _db = new ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is not posted back and the command query string is
            //new - the switch the form view into Insert mode directy
            if (!Page.IsPostBack &&
                 RouteData.Values["Command"] != null &&
                 RouteData.Values["Command"].ToString().Equals("new", StringComparison.OrdinalIgnoreCase))
            {
                frmProductDetails.ChangeMode(FormViewMode.Insert);
            }
        }

        public Product GetProduct([RouteData("id")] int? id)
        {
            //return all category entities with a given id
            return _db.Products.Find(id);
        }

        public int InsertProduct()
        {
            //create a new model object of type ToyCategory
            var product = new Product();
            _db.Products.Add(product);

            //attempt to save the model - hence forcing binding
            TryUpdateModel(product);
            if (!ModelState.IsValid)
            {
                //model is in an invalid state - stop all operations
                return 0;
            }

            //try and generate a shorter description
            //from the long one and update the date
            product.ShortDescription = StringUtility.truncateDescription(
                product.Description, 80);

            product.LastUpdated = DateTime.Now;

            //write the changes to the database
            return _db.SaveChanges();
        }



        public int UpdateProduct(int ProductID /*This should come directly from the data key names prop of the control*/)
        {
            //attempt to the find the category with the given ID
            var product = _db.Products.Find(ProductID);

            //check if there were any objects returned
            if (product == null)
            {
                //return an error indicating the product was deleted
                ModelState.AddModelError("NotFoundError", String.Format("A product with ID {0} could not be found", ProductID));
                return 0;
            }

            //attempt to update the model if we arrive at this stage
            TryUpdateModel(product);
            if (!ModelState.IsValid)
            {
                //model is in an invalid state - stop all operations
                return 0;
            }

            //NOTE: the model binding will automatically change the 
            //properties that bound to the controls in the form view
            //all we have to do, is generate a shorter description
            //from the long one and update the date
            product.ShortDescription = StringUtility.truncateDescription(
                product.Description, 80);

            product.LastUpdated = DateTime.Now;

            //write the changes to the database
            return _db.SaveChanges();
        }


        public int DeleteProduct(int ProductID /*This should come directly from the data key names prop of the control*/)
        {
            //attempt to the delete the category with the given ID
            _db.Products.Remove(_db.Products.Find(ProductID));

            //write the changes to the database
            return _db.SaveChanges();
        }




        protected void frmProductDetails_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            Response.Redirect(GetRouteUrl("Products", null));
        }


        protected void frmProductDetails_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect(GetRouteUrl("Products", null));
        }


        protected void frmProductDetails_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            //should the user click Cancel - redirect to the products page
            if (e.CommandName.Equals("Cancel"))
            {
                Response.Redirect(GetRouteUrl("Products", null));
            }
        }


        public IEnumerable<ToyCategory> GetCategories()
        {
            //intialize the model
            return _db.ToyCategories;
        }
    }
}