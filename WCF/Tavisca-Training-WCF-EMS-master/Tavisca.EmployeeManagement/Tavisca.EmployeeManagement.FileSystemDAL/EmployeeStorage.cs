using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Newtonsoft.Json;
using Tavisca.EmployeeManagement.ErrorSpace;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using System.Data.SqlClient;
using System.Data;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.FileStorage
{
    public class EmployeeStorage : IEmployeeStorage
    {
        readonly string EXTENSION = ".emp";

        public Model.Employee Save(Model.Employee employee)
        {
            try
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
                connect.Open();
                SqlCommand command = new SqlCommand("insert_emp_data", connect);
                command.CommandType = CommandType.StoredProcedure;
                if (employee.Remarks == null)
                {

                    command.Parameters.AddWithValue("@title", employee.Title);
                    command.Parameters.AddWithValue("@firstName", employee.FirstName);
                    command.Parameters.AddWithValue("@lastName", employee.LastName);
                    command.Parameters.AddWithValue("@emailId", employee.Email);
                    command.Parameters.AddWithValue("@phone", employee.Phone);
                    command.Parameters.AddWithValue("@joining_date", employee.JoiningDate);
                    command.Parameters.AddWithValue("@password", employee.Password);
                    command.ExecuteNonQuery();

                }
                connect.Close();
                return employee;

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public Model.Remark AddRemark(string employeeId, Remark remark)
        {
            try
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
                connect.Open();
                SqlCommand commandRemark = new SqlCommand("insert_emp_remark", connect);
                commandRemark.CommandType = CommandType.StoredProcedure;
                if (remark != null)
                {
                    commandRemark.Parameters.AddWithValue("@EmpId", employeeId);
                    commandRemark.Parameters.AddWithValue("@AddRemark", remark.Text);
                    commandRemark.Parameters.AddWithValue("@RemarkTime", remark.CreateTimeStamp);
                    commandRemark.ExecuteNonQuery();
                }
                connect.Close();
                return remark;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public Model.Employee Get(string employeeId)
        {
            try
            {
                Model.Employee emp = new Model.Employee();
                SqlConnection conEmployee = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);

                using (conEmployee)
                {
                    SqlCommand command = new SqlCommand("get_employee", conEmployee);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@emp_id", SqlDbType.Int));
                    command.Parameters["@emp_id"].Value = employeeId;

                    conEmployee.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            emp.Id = reader[0].ToString();
                            emp.Title = reader[1].ToString();
                            emp.FirstName = reader[2].ToString();
                            emp.LastName = reader[3].ToString();
                            emp.Email = reader[4].ToString();
                            emp.Phone = reader[5].ToString();
                            emp.JoiningDate = Convert.ToDateTime(reader[6]);
                            emp.Password = reader[7].ToString();
                        }
                    }
                    else
                        throw new System.Exception("Requested Data not found!");
                    reader.Close();
                }
                conEmployee.Close();

                List<Model.Remark> remarkList = new List<Model.Remark>(); //displaying remarks of employee

                SqlConnection conRemark = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
                conRemark.Open();
                using (conRemark)
                {
                    SqlCommand command = new SqlCommand("get_emp_remark", conRemark);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@emp_id", SqlDbType.Int));
                    command.Parameters["@emp_id"].Value = employeeId;

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            Model.Remark remark = new Model.Remark();
                            remark.Text = reader[1].ToString();
                            remark.CreateTimeStamp = Convert.ToDateTime(reader[2]);
                            remarkList.Add(remark);
                        }
                    }
                    else
                        throw new System.Exception("Requested Data not found!");
                    emp.Remarks = remarkList;
                    reader.Close();
                }
                conEmployee.Close();
                return emp;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public List<Model.Remark> GetRemarks(string employeeId) //get remarks of an employee
        {
            try
            {
                List<Model.Remark> remarkList = new List<Model.Remark>();
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
                using (connect)
                {
                    SqlCommand command = new SqlCommand("get_emp_remark", connect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@emp_id", SqlDbType.Int));
                    command.Parameters["@emp_id"].Value = employeeId;

                    connect.Open();
                    SqlDataReader remarkReader = command.ExecuteReader();
                    if (remarkReader.Read())
                    {
                        while (remarkReader.Read())
                        {
                            Model.Remark remark = new Model.Remark();
                            remark.Text = remarkReader[1].ToString();
                            remark.CreateTimeStamp = Convert.ToDateTime(remarkReader[2]);
                            remarkList.Add(remark);
                        }
                    }
                    else
                        throw new System.Exception("Requested Data not found!");
                    remarkReader.Close();
                }
                connect.Close();
                return remarkList;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public List<Model.Employee> GetAll()
        {
            try
            {
                List<Model.Employee> employeeList = new List<Model.Employee>();
                Model.Employee allEmployee = new Model.Employee();
                SqlConnection conAllEmployee = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
                using (conAllEmployee)
                {
                    SqlCommand command = new SqlCommand("get_all", conAllEmployee);
                    command.CommandType = CommandType.StoredProcedure;
                    conAllEmployee.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        while (reader.Read())
                        {
                            allEmployee.Id = reader[0].ToString();
                            allEmployee.Title = reader[1].ToString();
                            allEmployee.FirstName = reader[2].ToString();
                            allEmployee.LastName = reader[3].ToString();
                            allEmployee.Email = reader[4].ToString();
                            allEmployee.Phone = reader[5].ToString();
                            allEmployee.JoiningDate = Convert.ToDateTime(reader[6]);
                            allEmployee.Password = reader[7].ToString();
                            employeeList.Add(allEmployee);
                        }
                    }
                    else
                        throw new System.Exception("Requested Data not found!");
                    reader.Close();
                }
                conAllEmployee.Close();
                return employeeList;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public Employee Authenticate(Credentials credentials)
        {
            try
            {
                SqlConnection conEmployee = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
                Model.Employee allEmployee = new Model.Employee();
                using (conEmployee)
                {
                    SqlCommand command = new SqlCommand("get_emp_designation", conEmployee);
                    conEmployee.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));
                    command.Parameters["@EmailId"].Value = credentials.EmailId;
                    command.Parameters["@Password"].Value = credentials.Password;

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        allEmployee.Id = reader[0].ToString();
                        allEmployee.Title = reader[1].ToString();
                        allEmployee.FirstName = reader[2].ToString();
                        allEmployee.LastName = reader[3].ToString();
                        allEmployee.Email = reader[4].ToString();
                        allEmployee.Phone = reader[5].ToString();
                        allEmployee.JoiningDate = Convert.ToDateTime(reader[6]);
                    }
                    else
                    {
                        throw new System.Exception("Invalid User Credentials!");
                    }
                    conEmployee.Close();
                }
                return allEmployee;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public int UpdatePassword(UpdatePassword change)
        {
            try
            {
                SqlConnection conEmployee = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
                Model.Employee allEmployee = new Model.Employee();
                using (conEmployee)
                {
                    SqlCommand command = new SqlCommand("change_password", conEmployee);
                    SqlCommand command1 = new SqlCommand("get_emp_password", conEmployee);
                    conEmployee.Open();

                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.NVarChar));
                    command1.Parameters["@EmailId"].Value = change.EmailId;
                    SqlDataReader reader = command1.ExecuteReader();
                    reader.Read();

                    if (reader[0].ToString() == change.OldPassword)
                    {
                        reader.Close();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.NVarChar));
                        command.Parameters.Add(new SqlParameter("@OldPassword", SqlDbType.NVarChar));
                        command.Parameters.Add(new SqlParameter("@NewPassword", SqlDbType.NVarChar));
                        command.Parameters["@EmailId"].Value = change.EmailId;
                        command.Parameters["@OldPassword"].Value = change.OldPassword;
                        command.Parameters["@NewPassword"].Value = change.NewPassword;
                        command.ExecuteNonQuery();
                        conEmployee.Close();
                        return 1;
                    }
                    else
                    {
                        conEmployee.Close();
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return 0;
            }
        }

        public Model.Pagination GetPageRemarks(string employeeId, string pageNumber)
        {
            try
            {
                Model.Pagination pagination = new Model.Pagination();
                SqlConnection conEmployee = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);

                using (conEmployee)
                {
                    SqlCommand command = new SqlCommand("get_remark_count", conEmployee);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.Int));
                    command.Parameters["@EmpId"].Value = employeeId;

                    conEmployee.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        pagination.Count = Convert.ToInt32(reader[0]);
                    }
                    reader.Close();
                }
                conEmployee.Close();
                List<Model.Remark> remarkList = new List<Model.Remark>();
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString);
                using (connect)
                {

                    SqlCommand command = new SqlCommand("paginated_emp_remark", connect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@pageNumber", SqlDbType.Int));
                   
                    command.Parameters["@EmpId"].Value = employeeId;
                    command.Parameters["@pageNumber"].Value = pageNumber;
                    

                    connect.Open();
                    SqlDataReader remarkReader = command.ExecuteReader();
                    while (remarkReader.Read())
                    {
                        Model.Remark remark = new Model.Remark();
                        remark.Text = remarkReader[2].ToString();
                        remark.CreateTimeStamp = Convert.ToDateTime(remarkReader[3]);
                        remarkList.Add(remark);
                    }
                    pagination.Remarks = remarkList;
                    remarkReader.Close();
                }
                connect.Close();
                return pagination;

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }

        }

        private string GetFileName(string employeeId)
        {
            return string.Format(@"{0}\{1}.emp", Configurations.StoragePath, employeeId);
        }
    }
}