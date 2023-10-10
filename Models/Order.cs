namespace SpeedPassApp.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public int ScanStatus { get; set; }
        public string QRNumber { get; set; }
    }
}
