using System.ComponentModel.DataAnnotations;

namespace SpeedPassApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Order_Number { get; set; }
        [Required]
        public bool Fulfilled_Status { get; set; }
    }
}
