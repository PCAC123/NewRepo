namespace BlazorWeb.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        // Khóa ngoại
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }

        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Pending";

        // Quan hệ: Một Order có nhiều OrderDetails
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
