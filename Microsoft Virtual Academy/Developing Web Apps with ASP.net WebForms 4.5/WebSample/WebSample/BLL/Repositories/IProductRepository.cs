//base libararies
using System;
using System.Collections.Generic;

//added imports
using System.Web.UI.WebControls;
using WebSample.BLL.Model;

namespace WebSample.BLL.Repository
{

    public interface IProductRepository
    {
        IList<Product> GetProducts(string sortByExpression, int maximumRows,
            int startRowIndex, out int totalRowCount);

        IList<ToyCategory> GetCategories();

        Product GetProduct(int? id);

        int InsertProduct(ModelMethodContext modelMethodContext);
        int UpdateProduct(int ProductID, ModelMethodContext modelMethodContext);
        int DeleteProduct(int ProductID, ModelMethodContext modelMethodContext);
    }
}