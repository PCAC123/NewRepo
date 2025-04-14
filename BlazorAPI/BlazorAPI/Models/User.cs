using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Address { get; set; } = string.Empty;

        // Quan hệ: Một User có nhiều Orders và ViewHistory
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        [JsonIgnore]
        public ICollection<ViewHistory> ViewHistories { get; set; } = new List<ViewHistory>();
    }
}
