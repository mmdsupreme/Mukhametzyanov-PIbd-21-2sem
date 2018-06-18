using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SystemSecurityService.BindingModels
{
    [DataContract]
    public class SystemmBindModel
    {
        [DataMember]
        public int ID { set; get; }
        [DataMember]
        public string SystemmName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<ElementRequirementsBindModel> ElementRequirements { get; set; }
    }
}
