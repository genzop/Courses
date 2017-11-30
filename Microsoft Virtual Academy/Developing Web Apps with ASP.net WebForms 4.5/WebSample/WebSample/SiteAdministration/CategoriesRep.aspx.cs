//base libararies
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
    public partial class CategoriesRep : System.Web.UI.Page
    {
        //page level variables
        private readonly IToyCategoryRepository _repository =
            new ToyCategoryRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            //hook the grid view into the repository
            //ToyCategories.SetDefaultSort("Name");
            ToyCategories.SetDataMethodsObject(_repository);

            if (!Page.IsPostBack)
            {
                //Set the default sort for the products - caution datagrid
                //needs to be sorted before pagination can be implemented
                ToyCategories.SetDefaultSort("Name");
            }
        }
    }
}