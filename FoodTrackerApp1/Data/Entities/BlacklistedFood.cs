
namespace FoodTrackerApp.Data.Entities
{
    public class BlacklistedFood
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public IdentityUser User { get; set; }

        public Food Food { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
