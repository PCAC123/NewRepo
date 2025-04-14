using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAPI.Models
{
    public class CarStyle
    {
        [Key]
        public int StyleId { get; set; }
        public string StyleName { get; set; } = string.Empty;

        // Quan hệ: Một CarStyle có nhiều CarModels
        [JsonIgnore]
        public ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
    }
}
