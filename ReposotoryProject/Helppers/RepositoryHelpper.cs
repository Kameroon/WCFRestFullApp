using DataProject.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposotoryProject.Helppers
{
    public class RepositoryHelpper
    {



        public static Employee ManageResult(Employee employee)
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
    }
}
