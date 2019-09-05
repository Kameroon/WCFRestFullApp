using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MMAWcfService.Models;

namespace MMAWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        private IEnumerable<Employee> _employees;

        public EmployeeService()
        {
            PopulateEmployees();
        }

        public string GetData(string value)
        {
            int realId = Convert.ToInt32(value);

            return string.Format("You entered: {0}", realId);
        }

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetEmployeeByName(string employeeName)
        {
            var employee = _employees.Where(empl => empl.EmployeName == employeeName).FirstOrDefault();

            return ManageResult(employee);
        }

        public void Add(Employee employee)
        {
            Console.WriteLine("Add methode execute.");

            var employeList = _employees.ToList();

            employeList.Add(employee);
        }

        public void Update(Employee employee)
        {
            Console.WriteLine("Update methode execute.");

            var selectedEmploye = _employees.Where(empl => empl.EmployeeId == employee.EmployeeId).FirstOrDefault();

            if (selectedEmploye != null)
            {
                selectedEmploye.EmployeName = employee.EmployeName;
                selectedEmploye.EmployeEmail = employee.EmployeEmail;
                selectedEmploye.EmployeSalary = employee.EmployeSalary;
            }
        }

        public void Delete(Employee employee)
        {
            Console.WriteLine("Delete methode execute.");

            var selectedEmploye = _employees.Where(empl => empl.EmployeeId == employee.EmployeeId).FirstOrDefault();

            if (selectedEmploye != null)
            {
                _employees.ToList().Remove(employee);
            }
        }

        public Employee GetById(string myId)
        {
            int realId = Convert.ToInt32(myId);

            var employee = _employees.Where(empl => empl.EmployeeId == realId).FirstOrDefault();

            return ManageResult(employee);
        }

        #region --   --
        public IEnumerable<Employee> PopulateEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee(){ EmployeeId = 100,
                    EmployeName = "Employee 100",
                    EmployeEmail = "Employe100@compagny.com",
                    EmployeSalary = 3270},
                new Employee(){ EmployeeId = 101,
                    EmployeName = "Employee 101",
                    EmployeEmail = "Employe101@compagny.com",
                    EmployeSalary = 3900},
                new Employee(){ EmployeeId = 102,
                    EmployeName = "Employee 102",
                    EmployeEmail = "Employe102@compagny.com",
                    EmployeSalary = 4020},
                new Employee(){ EmployeeId = 103,
                    EmployeName = "Employee 103",
                    EmployeEmail = "Employe103@compagny.com",
                    EmployeSalary = 3750}
            };

            _employees = employees;

            return employees;
        }

        private Employee ManageResult(Employee employee)
        {
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return new Employee();
            }
        }

        public int Register(string uname, string pwd)
        {
            throw new NotImplementedException();
        }
        #endregion
    }    
}
