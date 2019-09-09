using DataProject.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MMAWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetAll/",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]  // Configure le service en REST
        IEnumerable<Employee> GetAll();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Add/",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare)]  // Configure le service en REST
        void Add(Employee employee);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Update/",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare)]
        void Update(Employee employee);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Delete/",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        void Delete(Employee employee);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetById/{myId}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        Employee GetById(string myId);

        [OperationContract]
        [WebInvoke(Method = "POST", 
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, 
            UriTemplate = "Registration/{uname}/{pwd}")]
        int Register(string uname, string pwd);
    }
}
