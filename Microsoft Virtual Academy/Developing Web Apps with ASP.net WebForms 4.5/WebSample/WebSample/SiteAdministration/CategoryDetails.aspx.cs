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
    public partial class CategoryDetails : System.Web.UI.Page
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
                frmCategoryDetails.ChangeMode(FormViewMode.Insert);
            }
        }


        public ToyCategory GetCategory([RouteData("id")] int? id)
        {
            //return all category entities with a given id
            return _db.ToyCategories.Find(id);
        }


        public int InsertToyCategory()
        {
            //create a new model object of type ToyCategory
            var category = new ToyCategory();
            _db.ToyCategories.Add(category);

            //attempt to save the model - hence forcing binding
            TryUpdateModel(category);
            if (!ModelState.IsValid)
            {
                //model is in an invalid state - stop all operations
                return 0;
            }

            //try and generate a shorter description
            //from the long one and update the date
            category.ShortDescription = StringUtility.truncateDescription(
                category.Description, 80);

            category.LastUpdated = DateTime.Now;

            //write the changes to the database
            return _db.SaveChanges();
        }


        public int UpdateToyCategory(int CategoryID /*This should come directly from the data key names prop of the control*/)
        {
            //attempt to the find the category with the given ID
            var category = _db.ToyCategories.Find(CategoryID);

            //check if there were any objects returned
            if (category == null)
            {
                //return an error indicating the category was deleted
                ModelState.AddModelError("NotFoundError", String.Format("A category with ID {0} could not be found", CategoryID));
                return 0;
            }



            //attempt to update the model if we arrive at this stage
            TryUpdateModel(category);
            if (!ModelState.IsValid)
            {
                //model is in an invalid state - stop all operations
                return 0;
            }

            //NOTE: the model binding will automatically change the 
            //properties that bound to the controls in the form view
            //all we have to do, is generate a shorter description
            //from the long one and update the date
            category.ShortDescription = StringUtility.truncateDescription(
                category.Description, 80);

            category.LastUpdated = DateTime.Now;

            //write the changes to the database
            return _db.SaveChanges();
        }


        public int DeleteToyCategory(int CategoryID /*This should come directly from the data key names prop of the control*/)
        {
            //attempt to the delete the category with the given ID
            _db.ToyCategories.Remove(_db.ToyCategories.Find(CategoryID));

            //write the changes to the database
            return _db.SaveChanges();
        }


        protected void frmCategoryDetails_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect(GetRouteUrl("Categories", null));
        }


        protected void frmCategoryDetails_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            Response.Redirect(GetRouteUrl("Categories", null));
        }


        protected void frmCategoryDetails_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            //should the user click Cancel - redirect to the categories page
            if (e.CommandName.Equals("Cancel"))
            {
                Response.Redirect(GetRouteUrl("Categories", null));
            }
        }

    }
}