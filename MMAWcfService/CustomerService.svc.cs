using DataProject.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MMAWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        // -- https://stackoverflow.com/questions/22784831/whats-the-best-way-to-send-generic-repository-via-wcf --
        #region -- What's the best way to send generic repository via WCF? --
        public Dictionary<string, object> QuerySearchTerms { get; set; }

        public CustomerService()
        {
            QuerySearchTerms = new Dictionary<string, object>();
        }

        public string WebGetData(string queryname, string queryterms)
        {
            //initial checks such as validation and parameter checking

            try
            {
                ////deserialise the JSON array structure
                //WebQueryTasks query = ManagerHelper.SerializerManager().DeserializeObject<WebQueryTasks>(queryterms);
                //if (query == null || !query.QuerySearchTerms.Any())
                //{
                //    //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, 
                //    //    new HttpError("Unable to deserialise search terms.")));
                //}

                //object temp;
                //string webResults;
                ////detemine the type of the query
                //switch (queryname.ToLower())
                //{
                //    case WebTasksTypeConstants.GetCompanyByName:
                //        webResults = this._userService.GetQuerySearchTerm("name", query);
                //        if (!string.IsNullOrEmpty(webResults))
                //        {
                //            temp = this._companiesService.Find(webResults);
                //        }
                //        else
                //        {
                //            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError("Unable to locate query search term(s).")));
                //        }
                //        break;
                //    case WebTasksTypeConstants.GetUserByEmail:
                //        webResults = this._userService.GetQuerySearchTerm("email", query);
                //        if (!string.IsNullOrEmpty(webResults))
                //        {
                //            temp = this._userService.FindByEmail(webResults);
                //        }
                //        else
                //        {
                //            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError("Unable to locate query search term(s).")));
                //        }
                //        break;
                //    default:
                //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest,
                //            new HttpError($"Unknown query type {queryname}.")));
                //}
                //var result = ManagerHelper.SerializerManager().SerializeObject(temp);
                //return result;

                return "";
            }
            catch (Exception ex)
            {
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, 
                //    new HttpError("Exception servicing request.")));
                return null;
            }
        } 
        #endregion

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


    #region -- !!!!!!!!!!!!!!! --
    public interface IGenericRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T AddNew(T item);
        bool Delete(int id);
        bool Update(T item);
    }

    public class CustomerRepository : IGenericRepository<Customer>
    {
        public List<Customer> _customers { get; set; }
        public int counter = 0;

        public Customer AddNew(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");
            customer.CustomerID = counter++;
            _customers.Add(customer);

            return customer;
        }

        public bool Delete(int customerId)
        {
            int idx = _customers.FindIndex(b => b.CustomerID == customerId);
            if (idx == -1)
                return false;

            _customers.RemoveAll(b => b.CustomerID == customerId);

            return true;
        }

        public List<Customer> GetAll()
        {
            return _customers;   
        }

        public Customer GetById(int customerId)
        {
            return _customers.Find(b => b.CustomerID == customerId);
        }

        public bool Update(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            int idx = _customers.FindIndex(b => b.CustomerID == customer.CustomerID);
            if (idx == -1)
                return false;
            _customers.RemoveAt(idx);
            _customers.Add(customer);

            return true;
        }
    }
    #endregion
}
