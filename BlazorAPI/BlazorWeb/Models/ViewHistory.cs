namespace BlazorWeb.Models
{
    public class ViewHistory
    {
        public int ViewId { get; set; }

        // Khóa ngoại
        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int CarId { get; set; }
        public Car Car { get; set; } = default!;

        public DateTime ViewedAt { get; set; } = DateTime.Now;
    }
}
