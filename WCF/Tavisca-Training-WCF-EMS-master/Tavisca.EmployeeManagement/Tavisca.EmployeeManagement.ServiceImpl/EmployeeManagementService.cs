﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Translator;
using Tavisca.EmployeeManagement.EnterpriseLibrary;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        public EmployeeManagementService(IEmployeeManagementManager manager)
        {
            _manager = manager;
        }

        IEmployeeManagementManager _manager;

        public DataContract.Employee Create(DataContract.Employee employee)
        {
            try
            {
                var result = _manager.Create(employee.ToDomainModel());
                if (result == null) return null;
                return result.ToDataContract();
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                throw newEx;
            }
        }

        public DataContract.Remark AddRemark(string employeeId, DataContract.Remark remark)
        {
            try
            {
                var result = _manager.AddRemark(employeeId, remark.ToDomainModel());
                if (result == null) return null;
                return result.ToDataContract();
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                throw newEx;
            }
        }
        public DataContract.Employee Authenticate(DataContract.Credentials credentials)
        {
            try
            {
                var result = _manager.Authenticate(credentials.ToDomainModel());
                if (result == null) return null;
                return result.ToDataContract();
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                throw newEx;
            }
        }
       public int UpdatePassword(DataContract.UpdatePassword change)
       {
           try
           {
               int result = _manager.UpdatePassword(change.ToDomainModel());
               if (result.Equals(1)) return 1;
               else return 0;
           }
           catch (Exception ex)
           {
               Exception newEx;
               var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
               throw newEx;
           }
       }
        }
    }


