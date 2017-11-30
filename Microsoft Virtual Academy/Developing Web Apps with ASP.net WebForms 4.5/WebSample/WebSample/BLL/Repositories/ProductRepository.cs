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
    public class ProductRepository : IProductRepository
    {
        //internal variables
        private readonly ProductContext _db = new ProductContext();


        public IList<Product> GetProducts(string sortByExpression, int maximumRows,
            int startRowIndex, out int totalRowCount)
        {
            //count the total number of rows availble in the table - and place it in the out parameter
            totalRowCount = _db.Products.Count();

            //select from the table based on the input parameters
            var products = _db.Products
                .SortBy(sortByExpression)
                .Skip(startRowIndex)
                .Take(maximumRows)
                .ToList();

            return products;
        }


        public IList<ToyCategory> GetCategories()
        {
            //return a list of all the categories in the store
            return _db.ToyCategories.ToList();
        }


        public Product GetProduct([RouteData("id")] int? id)
        {
            //return all category entities with a given id
            return _db.Products.Find(id);
        }


        public int InsertProduct(ModelMethodContext modelMethodContext)
        {
            //create a new model object of type ToyCategory
            var product = new Product();

            //attempt to save the model - hence forcing binding
            modelMethodContext.TryUpdateModel(product);
            if (!modelMethodContext.ModelState.IsValid)
            {
                //model is in an invalid state - stop all operations
                return 0;
            }

            //try and generate a shorter description
            //from the long one and update the date
            product.ShortDescription = StringUtility.truncateDescription(
                product.Description, 80);

            //write the changes to the database
            _db.Products.Add(product);
            return _db.SaveChanges();
        }


        public int UpdateProduct(int ProductID, ModelMethodContext modelMethodContext)
        {
            //attempt to the find the category with the given ID
            var product = _db.Products.Find(ProductID);

            //check if there were any objects returned
            if (product == null)
            {
                //return an error indicating the product was deleted
                modelMethodContext.ModelState.AddModelError("NotFoundError", String.Format("A product with ID {0} could not be found", ProductID));
                return 0;
            }

            //attempt to update the model if we arrive at this stage
            modelMethodContext.TryUpdateModel(product);
            if (!modelMethodContext.ModelState.IsValid)
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


            //write the changes to the database
            return _db.SaveChanges();
        }


        public int DeleteProduct(int ProductID, ModelMethodContext modelMethodContext)
        {
            //try and get a hold of the product entity with the given ID
            var product = GetProduct(ProductID);

            //if it is empty - product was deleted or never existed
            if (product == null)
            {
                return 0;
            }

            //attempt to the delete the category 
            _db.Products.Remove(product);

            //write the changes to the database
            return _db.SaveChanges();
        }
    }
}