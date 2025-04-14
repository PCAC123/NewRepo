using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAPI.Models
{
    public class ViewHistory
    {
        [Key]
        public int ViewId { get; set; }

        // Khóa ngoại
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int CarId { get; set; }
        [JsonIgnore]
        public Car Car { get; set; } = default!;

        public DateTime ViewedAt { get; set; } = DateTime.Now;
    }
}
