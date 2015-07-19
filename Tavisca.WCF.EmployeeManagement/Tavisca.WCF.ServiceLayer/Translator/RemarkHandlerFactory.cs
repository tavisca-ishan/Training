using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.WCF.BusinessLayer.Interfaces;
using Tavisca.WCF.ServiceLayer;
using Tavisca.WCF.BusinessLayer.BusinessModel;
namespace ServiceLayer.Translator
{
    public class RemarkHandlerFactory
    {
        public static IRemarkHandler CreateInstance(string employeeId, DateTime utcTime, string text)
        {
            var remarkHandler = new RemarkModel(employeeId,utcTime,text);
            return remarkHandler;
        }
    }
}
