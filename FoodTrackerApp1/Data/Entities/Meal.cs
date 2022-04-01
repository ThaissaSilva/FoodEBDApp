namespace FoodTrackerApp.Data.Entities
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public Meal()
        {
        }
    }

    //public enum Meals
    //{
    //    BreakFast,
    //    Lunch,
    //    Dinner,
    //    Snack
    //}
}

