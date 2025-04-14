using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAPI.Models
{
    public class CarModel
    {
        [Key]
        public int ModelId { get; set; }
        public string ModelName { get; set; } = string.Empty;

        // Khóa ngoại
        public int StyleId { get; set; }
        [JsonIgnore]
        public CarStyle? CarStyle { get; set; }

        // Quan hệ: Một CarModel có nhiều Cars
        [JsonIgnore]
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
