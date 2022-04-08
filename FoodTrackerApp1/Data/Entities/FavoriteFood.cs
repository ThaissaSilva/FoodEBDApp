namespace FoodTrackerApp.Data.Entities
{
    public class FavoriteFood
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        public Food Food { get; set; }

        public DateTime CreatedOn { get; set; }

        public FavoriteFood()
        {
        }
    }
}
