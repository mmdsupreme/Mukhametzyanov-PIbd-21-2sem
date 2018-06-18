using System.Runtime.Serialization;

namespace SystemSecurityService.BindingModels
{
    [DataContract]
    public class StorageBindModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string StorageName { get; set; }
    }
}
