using System.Runtime.Serialization;

namespace SystemSecurityService.ViewModel
{
    [DataContract]
    public class ExecutorViewModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string ExecutorFIO { get; set; }
    }
}
