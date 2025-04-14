namespace BlazorWeb.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        // Khóa ngoại
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;

        public int CarId { get; set; }
        public Car Car { get; set; } = default!;

        public decimal Price { get; set; }
    }
}
