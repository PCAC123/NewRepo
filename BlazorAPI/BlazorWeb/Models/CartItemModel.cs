using System.Text.Json.Serialization;

namespace BlazorWeb.Models
{
    public class CartItemModel
    {
        public int CarId { get; set; }
        public int? UserId { get; set; } = null;
        public decimal Price { get; set; }

        // Khóa ngoại
        public int ModelId { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Status { get; set; } = "Available";
        public string ImageURL { get; set; } = "default.jpg";
        public DateTime ManufactureDate { get; set; }
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public CarModel? CarModel { get; set; }
        public int? Quantity { get; set; } = null;
    }
}
