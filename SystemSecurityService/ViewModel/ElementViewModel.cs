using System.Runtime.Serialization;

namespace SystemSecurityService.ViewModel
{
    [DataContract]
    public class ElementViewModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ElementName { get; set; }
    }
}
