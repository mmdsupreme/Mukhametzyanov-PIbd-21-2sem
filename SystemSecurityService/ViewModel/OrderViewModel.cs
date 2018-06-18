using System.Runtime.Serialization;

namespace SystemSecurityService.ViewModel
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
        [DataMember]
        public int SystemmID { get; set; }
        [DataMember]
        public string SystemmName { get; set; }
        [DataMember]
        public int? ExecutorID { get; set; }
        [DataMember]
        public string ExecutorName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string DateImplement { get; set; }
    }
}
