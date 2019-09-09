using DataProject.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposotoryProject.Contracts
{
    public interface IEmployeeRepository : IDataRepository<Employee>
    {
        int Register(string uname, string pwd);
    }
}
