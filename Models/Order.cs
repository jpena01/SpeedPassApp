using System.ComponentModel.DataAnnotations;

namespace SpeedPassApp.Models
{
    public class Order
    {
        [Key]
        public required string Order_Number { get; set; }
        public required bool Fulfilled_Status { get; set; }
    }
}
