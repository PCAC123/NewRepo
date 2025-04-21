    using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = "Pending";
        public DateTime PaidAt { get; set; } = DateTime.Now;
    }
}
