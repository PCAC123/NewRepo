namespace BlazorWeb.Models
{
    public class CartItemModel
    {
        public int CarId { get; set; }
        public int UserId { get; set; }  // Có thể lấy từ session hoặc token khi login
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
