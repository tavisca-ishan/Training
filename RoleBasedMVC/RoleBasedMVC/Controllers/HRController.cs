using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoleBasedAccess.Model;
using PagedList;

namespace RoleBasedMVC.Controllers
{
    public class HRController : Controller
    {
        //
        // GET: /HR/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddEmployee(Employee employee)
        {
            if (HttpContext.User.IsInRole("hr") == false)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                employee.JoiningDate = DateTime.UtcNow;
                Employee.AddEmployee(employee);
                return View("AddEmployee");
            }

        }

        [Authorize]
        public ActionResult AddRemarks()
        {
            if (HttpContext.User.IsInRole("hr") == false)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var response = GetAllEmployeeResponse.GetEmployeeList();
                List<SelectListItem> allEmployeeList = new List<SelectListItem>();

                foreach (var employee in response.RequestedEmployeeList)
                {
                    allEmployeeList.Add(new SelectListItem { Value = Convert.ToString(employee.Id), Text = employee.Id + ". " + employee.FirstName + "  " + employee.LastName });
                }
                ViewData["EmpList"] = allEmployeeList;
                return View("");
            }
        }

        [Authorize]
        public ActionResult SaveRemarks(Remark remark)
        {
            string employeeId = Request["Employee"];
            remark.CreateTimeStamp = DateTime.UtcNow;
            var response = Remark.AddRemark(employeeId, remark);
            ViewData["StatusMsg"] = response.ResponseStatus.Message;
            return View("SaveRemarks");
        }

        [Authorize]
        public ActionResult ViewRemark(int? pageIndex)
        {
            string employeeId = "3";  //value from cookie
            int pageNumber = (pageIndex ?? 1);
            var response = Pagination.GetPageRemarks(employeeId, Convert.ToString(pageNumber));
            var remarkList = response.RequestedPagination.Remarks;
            var count = response.RequestedPagination.Count;

            var pageSize = 4;
            var pageList = new StaticPagedList<Remark>(remarkList, pageNumber, pageSize, count);
            return View(pageList);

        }
    }
}
