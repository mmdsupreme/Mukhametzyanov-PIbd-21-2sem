﻿using System.Runtime.Serialization;

namespace SystemSecurityService.ViewModel
{
    [DataContract]
    public class ElementStorageViewModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int StorageID { get; set; }
        [DataMember]
        public int ElementID { get; set; }
        [DataMember]
        public string ElementName { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
