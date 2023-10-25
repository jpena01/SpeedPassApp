using System.ComponentModel.DataAnnotations;

namespace SpeedPassApp.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Key]
        public required string Order_Number { get; set; }
        public required bool Fulfilled_Status { get; set; }
    }
}
