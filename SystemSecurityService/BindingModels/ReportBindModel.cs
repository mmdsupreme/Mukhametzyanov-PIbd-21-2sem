using System;
using System.Runtime.Serialization;

namespace SystemSecurityService.BindingModels
{
    [DataContract]
    public class ReportBindModel
    {
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public DateTime? DateFrom { get; set; }
        [DataMember]
        public DateTime? DateTo { get; set; }
    }
}
