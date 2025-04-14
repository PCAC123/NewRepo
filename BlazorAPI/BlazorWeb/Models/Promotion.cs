using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Models
{
    public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
