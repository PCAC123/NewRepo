using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        // Khóa ngoại
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; } = default!;

        public int? PaymentId { get; set; }
        [JsonIgnore]
        public Payment? Payment { get; set; }
        public int? PromotionId { get; set; }
        [JsonIgnore]
        public Promotion? Promotion { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Pending";

        // Quan hệ: Một Order có nhiều OrderDetails
        
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
