using DataProject.Implementations;
using ReposotoryProject.Contracts;
using ReposotoryProject.Helppers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposotoryProject.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IEnumerable<Employee> _employees;

        #region -- Constructor --
        public EmployeeRepository()
        {
            PopulateEmployees();
        }
        #endregion

        #region -- Methodes --

        /// <summary>
        /// -- Add new employee  --
        /// </summary>
        /// <param name="employee"></param>
        public void AddNew(Employee employee)
        {
            var employeList = _employees.ToList();

            employeList.Add(employee);
        }

        /// <summary>
        /// -- Delete employee based on id --
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var selectedEmploye = _employees.Where(
                   empl => empl.EmployeeId == id
                ).FirstOrDefault();

            if (selectedEmploye != null)
            {
                _employees.ToList().Remove(selectedEmploye);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// -- Get all employees --
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAll()
        {          
            return _employees;
        }

        /// <summary>
        /// --  Get employee by id  --
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee</returns>
        public Employee GetById(int id)
        {
            int realId = Convert.ToInt32(id);

            var employee = _employees.Where(
                    empl => empl.EmployeeId == realId
                ).FirstOrDefault();

            return RepositoryHelpper.ManageResult(employee);
        }

        /// <summary>
        /// --  Get employee by name --
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Employee</returns>
        public Employee GetByName(string name)
        {
            var employee = _employees.Where(
                    empl => empl.EmployeName == name
                ).FirstOrDefault();

            return RepositoryHelpper.ManageResult(employee);
        }
        
        /// <summary>
        /// -- Register user --
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="pwd"></param>
        /// <returns>int</returns>
        public int Register(string uname, string pwd)
        {
            return 454542415;
        }

        /// <summary>
        /// --  --
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>bool</returns>
        public bool Update(Employee employee)
        {
            var selectedEmploye = _employees.Where(
                   empl => empl.EmployeeId == employee.EmployeeId
                ).FirstOrDefault();

            if (selectedEmploye != null)
            {
                // -- 1ere Methode --
                selectedEmploye.EmployeName = employee.EmployeName;
                selectedEmploye.EmployeEmail = employee.EmployeEmail;
                selectedEmploye.EmployeSalary = employee.EmployeSalary;

                // -- 2em Methode --
                var employeLists = _employees.ToList();
                employeLists.Remove(selectedEmploye);
                employeLists.Add(employee);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// --  Populate employeeList  --
        /// </summary>
        /// <returns>IEnumerable<Employee></returns>
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
        #endregion
    }
}
