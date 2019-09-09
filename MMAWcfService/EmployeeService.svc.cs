using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataProject.Implementations;
using ReposotoryProject.Contracts;
using ReposotoryProject.Implementations;

namespace MMAWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public void Add(Employee employee)
        {
            _employeeRepository.AddNew(employee);
        }

        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee.EmployeeId);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetById(string myId)
        {
            return _employeeRepository.GetById(Convert.ToInt32(myId));
        }

        public int Register(string uname, string pwd)
        {
            return _employeeRepository.Register(uname, pwd);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }
    }
}
