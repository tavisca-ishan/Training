using RoleBasedAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UserApplicationForm
{
    public partial class EmployeeViewRemarks : System.Web.UI.UserControl
    {
        string empId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.IsPostBack == false)
            {
                HttpCookie cookie2 = Request.Cookies["User Credentials"];
                if (cookie2 != null)
                {
                    empId = cookie2["empid"];
                }
                var response = Pagination.GetPageRemarks(empId, "1");
                //ViewRemarks.VirtualItemCount = response.Count;
                ViewRemarks.DataSource = response.RequestedPagination.Remarks;
                ViewRemarks.DataBind();
                DatabindRepeater(ViewRemarks.PageIndex, ViewRemarks.PageSize, response.RequestedPagination.Count);
            }
        }
        protected void LinkButton1_Click(Object sender, EventArgs e)
        {
              HttpCookie cookie = Request.Cookies["User Credentials"];
                if(cookie!=null) 
                   empId=cookie["empid"];
            int pageIndex = Convert.ToInt32((sender as LinkButton).CommandArgument);
            ViewRemarks.PageIndex = pageIndex;

            var response = Pagination.GetPageRemarks(empId, ViewRemarks.PageIndex.ToString());
            pageIndex -= 1;
            ViewRemarks.DataSource = response.RequestedPagination.Remarks;
            ViewRemarks.DataBind();
            DatabindRepeater(ViewRemarks.PageIndex, ViewRemarks.PageSize, response.RequestedPagination.Count);
        }
        private void DatabindRepeater(int pageIndex, int pageSize, int count)
        {
            int totalPages = count / pageSize;

            if (count % pageSize != 0)
                totalPages += 1;

            List<ListItem> pages = new List<ListItem>();
            if (totalPages > 1)
            {
                for (int pageCount = 1; pageCount <= totalPages; pageCount++)
                {
                    pages.Add(new ListItem(pageCount.ToString(), pageCount.ToString(), pageCount != (pageIndex + 1)));
                }
            }
            PageRepeater.DataSource = pages;
            PageRepeater.DataBind();
        }

        protected void ViewRemarks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
              HttpCookie cookie = Request.Cookies["User Credentials"];
                if(cookie!=null) 
                   empId=cookie["empid"];
            ViewRemarks.PageIndex = e.NewPageIndex;
           
            var response = Pagination.GetPageRemarks(empId, ViewRemarks.PageIndex.ToString());

            ViewRemarks.DataSource = response.RequestedPagination.Remarks; ;
            ViewRemarks.DataBind();
            DatabindRepeater(ViewRemarks.PageIndex, ViewRemarks.PageSize, response.RequestedPagination.Count);
        }

        protected void ViewRemarks_PageIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ViewRemarks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void PageRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}