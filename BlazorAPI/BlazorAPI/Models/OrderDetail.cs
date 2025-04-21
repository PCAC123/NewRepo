using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        // Khóa ngoại
        public int OrderId { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; } = default!;

        public int CarId { get; set; }
        [JsonIgnore]

        public Car? Car { get; set; } = default!;

        public decimal Price { get; set; }
    }
}
