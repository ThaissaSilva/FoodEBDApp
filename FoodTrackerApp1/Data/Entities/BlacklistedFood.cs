
namespace FoodTrackerApp.Data.Entities
{
    public class BlacklistedFood
    {
        [Key]
        public string UserId { get; set; }

        public List<Food> Foods { get; set; }

        public DateTime CreatedOn { get; set; }

        public BlacklistedFood()
        {
        }

        public BlacklistedFood(List<Food> foods)
        {
            Foods = foods;
        }
    }
}
