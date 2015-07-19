using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace Tavisca.WCF.DataAccessLayer
{
    public class FileSystem
    {
        public void SaveEmployee(string jsonString, string id)
        {
            if (File.Exists(@"D:\EmployeeID\ID.Txt"))
                File.AppendAllText(@"D:\EmployeeID\ID.Txt", id + Environment.NewLine);

            else
                File.WriteAllText(@"D:\EmployeeID\ID.Txt", id + Environment.NewLine);

            File.WriteAllText(@"D:\EmployeeInformation\" + id + ".Txt", jsonString);

        }

        //getEmployeeById()

        public string getDetailsById(string id)
        {
            var jsonString = File.ReadAllText(@"D:\EmployeeInformation\" + id);
            return jsonString;
        }

        public List<string> GetAllIds() //gets all ids
        {
            DirectoryInfo directory = new DirectoryInfo(@"D:\EmployeeInformation\");
            var files = directory.GetFiles("*.txt");
            List<string> idList = new List<string>();

            foreach (var file in files)
            {
                idList.Add(file.Name);//generates list of all ids
            }
            return idList;
        }
    }
}