using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MMAWcfService.Models;

namespace MMAWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        public List<Customer> GetCustomerList()
        {
            return PopulateCustomerData();
        }

        private List<Customer> PopulateCustomerData()
        {
            List<Customer> lstCustomer = new List<Customer>();
            Customer customer1 = new Customer();
            customer1.CustomerID = 1;
            customer1.FirstName = "John";
            customer1.LastName = "Meaney";
            customer1.Address = "Chicago";
            lstCustomer.Add(customer1);

            Customer customer2 = new Customer();
            customer2.CustomerID = 1;
            customer2.FirstName = "Peter";
            customer2.LastName = "Shaw";
            customer2.Address = "New York";
            lstCustomer.Add(customer2);

            return lstCustomer;
        }
    }
}
