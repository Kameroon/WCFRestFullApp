﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MMAWcfService.Models
{
    [DataContract]
    public class Customer : ICustomer
    {
        [DataMember]
        public int CustomerID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public String Address { get; set; }
    }
}