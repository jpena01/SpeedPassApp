using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedPassApp.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public required string OrderNumber { get; set; }
        public bool ScanStatus { get; set; }
    }
}

