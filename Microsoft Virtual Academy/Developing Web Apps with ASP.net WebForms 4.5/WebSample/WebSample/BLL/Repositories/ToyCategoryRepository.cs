//base libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//added imports
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using WebSample.BLL.Model;
using WebSample.BLL.Utilities;

namespace WebSample.BLL.Repository
{

    public class ToyCategoryRepository : IToyCategoryRepository
    {
        //internal variables
        private readonly ProductContext _db = new ProductContext();

        public IList<ToyCategory> GetCategories(string sortByExpression, int maximumRows,
            int startRowIndex, out int totalRowCount)
        {
            //count the total number of rows availble in the table - and place it in the out parameter
            totalRowCount = _db.ToyCategories.Count();

            //select from the table based on the input parameters
            var categories = _db.ToyCategories
                .SortBy(sortByExpression)
                .Skip(startRowIndex)
                .Take(maximumRows)
                .ToList();

            return categories;

        }


        public ToyCategory GetCategory([RouteData("id")] int? id)
        {
            //return all category entities with a given id
            return _db.ToyCategories.Find(id);
        }


        public int InsertToyCategory(ModelMethodContext modelMethodContext)
        {

            //create a new model object of type ToyCategory
            var category = new ToyCategory();

            //attempt to save the model - hence forcing binding
            modelMethodContext.TryUpdateModel(category);
            if (!modelMethodContext.ModelState.IsValid)
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
            _db.ToyCategories.Add(category);
            return _db.SaveChanges();
        }


        public int UpdateToyCategory(int CategoryID, ModelMethodContext modelMethodContext)
        {
            //attempt to the find the category with the given ID
            var category = _db.ToyCategories.Find(CategoryID);

            //check if there were any objects returned
            if (category == null)
            {
                //return an error indicating the category was deleted
                modelMethodContext.ModelState.AddModelError("NotFoundError", String.Format("A category with ID {0} could not be found", CategoryID));
                return 0;
            }



            //attempt to update the model if we arrive at this stage
            modelMethodContext.TryUpdateModel(category);
            if (!modelMethodContext.ModelState.IsValid)
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


        public int DeleteToyCategory(int CategoryID, ModelMethodContext modelMethodContext)
        {
            //try and get a hold of the category entity with the given ID
            var category = GetCategory(CategoryID);

            //if it is empty - category was deleted or never existed
            if (category == null)
            {
                return 0;
            }

            //attempt to the delete the category 
            _db.ToyCategories.Remove(category);

            //write the changes to the database
            return _db.SaveChanges();
        }
    }
}