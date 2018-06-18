namespace SystemSecurityService.ViewModel
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerFIO { get; set; }
        public int SystemmID { get; set; }
        public string SystemmName { get; set; }
        public int? ExecutorID { get; set; }
        public string ExecutorName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
        public string DateCreate { get; set; }
        public string DateImplement { get; set; }
    }
}
