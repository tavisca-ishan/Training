using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.WCF.BusinessLayer.Interfaces;
using Newtonsoft.Json;
using Tavisca.WCF.DataAccessLayer;
namespace Tavisca.WCF.BusinessLayer.BusinessModel
{
    public class RemarkModel : IRemarkHandler
    {
        public RemarkModel(string employeeId, DateTime utcTime, string text)
        {
            this.Id = employeeId;
            this.UtcTime = utcTime;
            this.RemarkText = text;
        }
        public string Id { get; set; }
        public DateTime UtcTime { get; set; }
        public string RemarkText { get; set; }

        public string GenerateDateTime()
        {
            DateTime remarkTime = DateTime.UtcNow;
            return remarkTime.ToString();
        }
        public static void AddRemarkInFile(RemarkModel remark, string employeeId)
        {
            var jsonString = JsonConvert.SerializeObject(remark);
            FileSystem getFile = new FileSystem();
            EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(getFile.getDetailsById(employeeId));
            employeeModel.Remark = jsonString; 
            jsonString = JsonConvert.SerializeObject(employeeModel);
            getFile.SaveEmployee(jsonString, employeeId);
        }

       
    }
}
