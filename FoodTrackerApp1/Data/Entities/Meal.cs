namespace FoodTrackerApp.Data.Entities
{
    public class Meal
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public IdentityUser User { get; set; }

        public Meals Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<FoodMeal> FoodMeals { get; set; }
    }

    public enum Meals
    {
        BreakFast,
        Lunch,
        Dinner,
        Snack
    }
}

