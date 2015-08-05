using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserApplicationForm.Model;

namespace UserApplicationForm
{
    public partial class EmployeeViewRemarks : System.Web.UI.UserControl
    {
        string empId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.IsPostBack == false)
            {
                HttpCookie cookie = Request.Cookies["User Credentials"];
                if(cookie!=null) 
                   empId=cookie["EmpId"];
                
                HttpClient client = new HttpClient();
                Pagination pagination = new Pagination();
                var response = client.GetData<Pagination>("http://localhost:53412/EmployeeService.svc/pagination/"+empId+"/1");
                //ViewRemarks.VirtualItemCount = response.Count;
                ViewRemarks.DataSource = response.Remarks;
                ViewRemarks.DataBind();
                DatabindRepeater(ViewRemarks.PageIndex, ViewRemarks.PageSize, response.Count);
            }
        }
        protected void LinkButton1_Click(Object sender, EventArgs e)
        {
              HttpCookie cookie = Request.Cookies["User Credentials"];
                if(cookie!=null) 
                   empId=cookie["EmpId"];
            int pageIndex = Convert.ToInt32((sender as LinkButton).CommandArgument);
            ViewRemarks.PageIndex = pageIndex;
            HttpClient client = new HttpClient();
            Pagination pagination = new Pagination();
            var response = client.GetData<Pagination>("http://localhost:53412/EmployeeService.svc/pagination/"+empId+"/" + ViewRemarks.PageIndex);
            ViewRemarks.DataSource = response.Remarks;
            pageIndex -= 1;                    
            ViewRemarks.DataBind();
            DatabindRepeater(pageIndex, ViewRemarks.PageSize, response.Count);
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
                   empId=cookie["EmpId"];
            ViewRemarks.PageIndex = e.NewPageIndex;
            Pagination pagination = new Pagination();
            HttpClient client = new HttpClient();
            var response = client.GetData<Pagination>("http://localhost:53412/EmployeeService.svc/pagination/"+empId+"/" + ViewRemarks.PageIndex+1);
            
            ViewRemarks.DataSource = response.Remarks;
            ViewRemarks.DataBind();
            DatabindRepeater(ViewRemarks.PageIndex, ViewRemarks.PageSize, response.Count);
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