﻿using System.Runtime.Serialization;

namespace SystemSecurityService.BindingModels
{
    [DataContract]
    public class CustomerBindModel
    {
        [DataMember]
        public int ID { set; get; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public string CustomerFIO { set; get; }
    }
}
