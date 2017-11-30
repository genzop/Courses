//base libraries
using System;
using System.Collections.Generic;

//added imports
using System.Web.UI.WebControls;
using WebSample.BLL.Model;

namespace WebSample.BLL.Repository
{

    public interface IToyCategoryRepository
    {
        IList<ToyCategory> GetCategories(string sortByExpression, int maximumRows,
            int startRowIndex, out int totalRowCount);

        ToyCategory GetCategory(int? id);

        int InsertToyCategory(ModelMethodContext modelMethodContext);
        int UpdateToyCategory(int CategoryID, ModelMethodContext modelMethodContext);
        int DeleteToyCategory(int CategoryID, ModelMethodContext modelMethodContext);
    }
}