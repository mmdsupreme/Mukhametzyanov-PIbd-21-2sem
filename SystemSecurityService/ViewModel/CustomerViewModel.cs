﻿using System.Runtime.Serialization;

namespace SystemSecurityService.ViewModel
{
    [DataContract]
    public class CustomerViewModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
    }
}
