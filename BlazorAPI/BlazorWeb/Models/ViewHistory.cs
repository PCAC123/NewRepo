using System.Text.Json.Serialization;

namespace BlazorWeb.Models
{
    public class ViewHistory
    {
        public int ViewId { get; set; }

        // Khóa ngoại
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; } = default!;

        public int CarId { get; set; }
        [JsonIgnore]
        public Car? Car { get; set; } = default!;

        public DateTime ViewedAt { get; set; } = DateTime.Now;
    }
}
