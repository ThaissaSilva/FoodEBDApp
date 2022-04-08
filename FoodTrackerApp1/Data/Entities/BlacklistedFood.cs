
namespace FoodTrackerApp.Data.Entities
{
    public class BlacklistedFood
    {
        [Key]
        public int Id{ get; set; }

        public User User{ get; set; }

        public Food Food{ get; set; }   

        public DateTime CreatedOn { get; set; }

        public BlacklistedFood()
        {
        }    
    }
}

