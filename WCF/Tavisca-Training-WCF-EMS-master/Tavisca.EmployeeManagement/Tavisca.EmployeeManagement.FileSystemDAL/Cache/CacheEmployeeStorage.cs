﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Newtonsoft.Json;
using Tavisca.EmployeeManagement.ErrorSpace;

namespace Tavisca.EmployeeManagement.FileStorage
{
    public class CacheEmployeeStorage : IEmployeeStorage
    {
        public CacheEmployeeStorage(ICacheManager manager)
        {
            _innerStorage = new EmployeeStorage();
            _cacheManager = manager;
        }

        IEmployeeStorage _innerStorage;
        ICacheManager _cacheManager;

        readonly string KEYFORMAT = "emp.{0}";
        readonly string CACHEMANAGER = "employee";

        public Model.Employee Save(Model.Employee employee)
        {
            var result = _innerStorage.Save(employee);
            _cacheManager.Add(string.Format(KEYFORMAT, result.Id), result, CACHEMANAGER);
            return result;
        }

        public Model.Remark AddRemark(string EmployeeId, Model.Remark remark)
        {
            var result = _innerStorage.AddRemark(EmployeeId, remark);
            //_cacheManager.Add(string.Format(KEYFORMAT, result.Id), result, CACHEMANAGER);
            return result;
        }
        public Model.Employee Authenticate(Model.Credentials credentials)
        {
            return _innerStorage.Authenticate(credentials);
        }
        public int UpdatePassword(Model.UpdatePassword change)
        {
            return _innerStorage.UpdatePassword(change);
        }

        public Model.Employee Get(string employeeId)
        {
            Model.Employee result;
            result = _cacheManager.Get(string.Format(KEYFORMAT, employeeId), CACHEMANAGER) as Model.Employee;
            if (result == null)
            {
                result = _innerStorage.Get(employeeId);
                _cacheManager.Add(string.Format(KEYFORMAT, employeeId), result, CACHEMANAGER);
            }
            return result;
        }

        public List<Model.Employee> GetAll()
        {
            return _innerStorage.GetAll();
        }

        public List<Model.Remark> GetRemarks(string EmployeeId)
        {
            return _innerStorage.GetRemarks(EmployeeId);
        }
        public Model.Pagination GetPageRemarks(string employeeId, string pageNumber)
        {
            return _innerStorage.GetPageRemarks(employeeId, pageNumber);
        }
    }
}