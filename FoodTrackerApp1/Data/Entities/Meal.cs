namespace FoodTrackerApp.Data.Entities
{
    public class Meal
    {
        [Key]
        public string UserId { get; set; }
      
        public IdentityUser User { get; set; }

        public Meals Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public List<Meal> Meals { get; set; }

        public virtual ICollection<FoodMeal> FoodMeals { get; set; }

        public Meal()
        {
        }

        public Meal(List<Meal> meals)
        {
            Meals = meals;
        }
    }


    public enum Meals
    {
        BreakFast,
        Lunch,
        Dinner,
        Snack
    }
}

