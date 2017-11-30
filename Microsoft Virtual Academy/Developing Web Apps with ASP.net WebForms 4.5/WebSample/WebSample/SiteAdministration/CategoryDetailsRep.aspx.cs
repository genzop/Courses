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
    public partial class CategoryDetailsRep : System.Web.UI.Page
    {

        //page level variables
        private readonly IToyCategoryRepository _repository = new ToyCategoryRepository();


        protected void Page_Init()
        {
            //hook the form view into the repository
            frmCategoryDetails.SetDataMethodsObject(_repository);
            frmCategoryDetails.RedirectToRouteOnItemInserted("Categories");
            frmCategoryDetails.RedirectToRouteOnItemDeleted("Categories");
            frmCategoryDetails.RedirectToRouteOnItemCommad("Categories");
        }

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

    }
}