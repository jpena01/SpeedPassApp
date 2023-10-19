using System.ComponentModel.DataAnnotations;

namespace SpeedPassApp.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Key]
        public required string Order_Number { get; set; }
        public required string Customer_Name { get; set; }
        public required bool Scan_Status { get; set; }
        public required string QR_Number { get; set; }
        public required string Customer_Email { get; set; }
    }
}
