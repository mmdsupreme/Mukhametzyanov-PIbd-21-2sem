using System.Runtime.Serialization;

namespace SystemSecurityService.BindingModels
{
    [DataContract]
    public class ElementRequirementsBindModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int SystemmID { get; set; }
        [DataMember]
        public int ElementID { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
