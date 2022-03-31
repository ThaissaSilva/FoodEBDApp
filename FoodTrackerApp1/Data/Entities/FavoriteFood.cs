namespace FoodTrackerApp.Data.Entities
{
    public class FavoriteFood
    {
        [Key]
        public string UserId { get; set; }
      
        public IdentityUser User { get; set; }

        public List<Food> Foods { get; set; }

        public DateTime CreatedOn { get; set; }

        public FavoriteFood()
        {
        }
    }
}
