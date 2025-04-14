using System.Text.Json.Serialization;  // Dùng System.Text.Json
// Hoặc dùng Newtonsoft.Json: using Newtonsoft.Json;

namespace BlazorAPI.Models
{
    public class Car
    {
        public int CarId { get; set; }
        // Khóa ngoại
        public int ModelId { get; set; }

        public decimal Price { get; set; } = 0;
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Status { get; set; } = "Available";
        public string ImageURL { get; set; } = "default.jpg";
        public DateTime ManufactureDate { get; set; }
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public CarModel? CarModel { get; set; }
    }
}
