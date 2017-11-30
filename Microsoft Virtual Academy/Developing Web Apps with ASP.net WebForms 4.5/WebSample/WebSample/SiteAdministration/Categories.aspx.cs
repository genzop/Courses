using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//added imports
using WebSample.BLL.Model;

namespace WebSample.SiteAdministration
{
    public partial class Categories : System.Web.UI.Page
    {
        //create a db context object to operate queries on
        private readonly ProductContext _db = new ProductContext();
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public IQueryable<ToyCategory> GetCategories()
        {
            //return a list of all the categories in the store
            return _db.ToyCategories;
        }
    }
}