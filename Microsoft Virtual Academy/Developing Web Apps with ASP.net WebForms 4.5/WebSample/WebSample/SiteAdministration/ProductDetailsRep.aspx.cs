using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//added imports
using WebSample.BLL.Repository;
using WebSample.BLL.Extesions;

namespace WebSample.SiteAdministration
{
    public partial class ProductDetailsRep : System.Web.UI.Page
    {

        //page level variables
        private readonly IProductRepository _repository = new ProductRepository();

        protected void Page_Init()
        {
            //hook the form view into the repository
            frmProductDetails.SetDataMethodsObject(_repository);
            frmProductDetails.RedirectToRouteOnItemInserted("Products");
            frmProductDetails.RedirectToRouteOnItemDeleted("Products");
            frmProductDetails.RedirectToRouteOnItemCommad("Products");
        }

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


        protected void cmbEditCategories_Init(object sender, EventArgs e)
        {
            //grab a hold of the drop down for listing the categories and hook it up to the repository
            DropDownList cmbEditCategories =
                  (DropDownList)sender;

            cmbEditCategories.SetDataMethodsObject(_repository);
        }


        protected void cmbInsertProductCategory_Init(object sender, EventArgs e)
        {
            //grab a hold of the drop down for listing the categories and hook it up to the repository
            DropDownList cmbInsertProductCategory =
                  (DropDownList)sender;

            cmbInsertProductCategory.SetDataMethodsObject(_repository);
        }
       
    }
}