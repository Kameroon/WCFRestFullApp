using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MMAWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPayMentService" in both code and config file together.
    [ServiceContract]
    public interface IPayMentService
    {
        //To Insert or POST Records
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/AddPayee/{Name}/{City}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void AddPayee(string Name, string City);

        //To Get Records from database 
        [OperationContract]
        [WebGet(
            UriTemplate = "/PayBill/{PayId}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string PayBill(string PayId);

        //To Update records
        [OperationContract]
        [WebInvoke(Method = "PUT",
            UriTemplate = "/UpdateBillPayment/{PayId}/{TransId}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void UpdateBillPayment(string PayId, string TransId);

        //To delete records
        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "/RemovePayee/{Id}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void RemovePayee(string Id);
    }
}
