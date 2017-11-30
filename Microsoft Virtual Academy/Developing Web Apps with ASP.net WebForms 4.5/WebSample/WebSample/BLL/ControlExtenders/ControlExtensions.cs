//base libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//addd imports
using System.Web.UI.WebControls;

namespace WebSample.BLL.Extesions
{

    public static class ControlExtensions
    {
       
        public static void SetDefaultSort(this GridView gridView, string sortExpression)
        {
            //call to overloaded SetDefaultSort method with hardcoded ascending sort
            SetDefaultSort(gridView, sortExpression, SortDirection.Ascending);
        }

        
        public static void SetDefaultSort(this GridView gridView, string sortExpression, SortDirection sortDirection)
        {
            if (!gridView.Page.IsPostBack)
            {
                gridView.Sort(sortExpression, sortDirection);
            }
        }


        public static void SetDataMethodsObject(this DataBoundControl dataControl, object dataMethodOjbect)
        {
            dataControl.CallingDataMethods += (s, e) => e.DataMethodsObject = dataMethodOjbect;
        }


        public static void RedirectToRouteOnItemInserted(this FormView formView, string routeName)
        {
            //overload the ItemInserted event
            formView.ItemInserted += (s, e) =>
            {
                if (formView.Page.ModelState.IsValid)
                {
                    formView.Page.Response.RedirectToRoute(routeName);
                }
            };
        }


        public static void RedirectToRouteOnItemDeleted(this FormView formView, string routeName)
        {
            //overload the ItemUpdate event
            formView.ItemDeleted += (s, e) =>
            {
                if (formView.Page.ModelState.IsValid)
                {
                    formView.Page.Response.RedirectToRoute(routeName);
                }
            };
        }


        public static void RedirectToRouteOnItemCommad(this FormView formView, string routeName)
        {
            //overload the ItemCommand event
            formView.ItemCommand += (s, e) =>
            {
                if (e.CommandName.Equals("Cancel"))
                {
                    formView.Page.Response.RedirectToRoute(routeName);
                }
            };
        }
    }
}