//base libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//added imports
using WebSample.BLL.Extesions;
using WebSample.BLL.Repository;

namespace WebSample.SiteAdministration
{
    public partial class ProductsRep : System.Web.UI.Page
    {
        //page level variables
        private readonly IProductRepository _repository =
            new ProductRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            //hook the grid view into the repository
            //ToyCategories.SetDefaultSort("Name");
            ProductsList.SetDataMethodsObject(_repository);

            if (!Page.IsPostBack)
            {
                //Set the default sort for the products - caution datagrid
                //needs to be sorted before pagination can be implemented
                ProductsList.SetDefaultSort("Name");
            }
        }
    }
}