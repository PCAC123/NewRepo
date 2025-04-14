using System.Text.Json.Serialization;

namespace BlazorWeb.Models
{
    public class CarModel
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; } = string.Empty;

        // Khóa ngoại
        public int StyleId { get; set; }

        [JsonIgnore] // Tránh vòng lặp hoặc dữ liệu thừa khi gọi API
        //public CarStyle CarStyle { get; set; } = default!;
        public CarStyle? CarStyle { get; set; }
        [JsonIgnore] // Tránh vòng lặp hoặc dữ liệu thừa khi gọi API
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
