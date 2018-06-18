using System.Runtime.Serialization;

namespace SystemSecurityService.BindingModels
{
    [DataContract]
    public class ElementBindModel
    {
        [DataMember]
        public int ID { set; get; }
        [DataMember]
        public string ElementName { get; set; }
    }
}
