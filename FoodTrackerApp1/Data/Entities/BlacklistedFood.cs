
namespace FoodTrackerApp.Data.Entities
{
    public class BlacklistedFood
    {
        [Key]
        public string UserId{ get; set; }

        public DateTime CreatedOn { get; set; }

        public BlacklistedFood()
        {
        }

        public BlacklistedFood(string userId)
        {
            UserId = userId;
        }
    }
}

