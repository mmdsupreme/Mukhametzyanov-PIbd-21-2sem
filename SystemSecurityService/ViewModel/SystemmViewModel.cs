using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SystemSecurityService.ViewModel
{
    [DataContract]
    public class SystemmViewModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string SystemmName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<ElementRequirementsViewModel> ElementRequirements { get; set; }
    }
}
