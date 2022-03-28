namespace FoodTrackerApp.Data.Entities
{
    public class Meal
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public IdentityUser User { get; set; }

        public Meals Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
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

