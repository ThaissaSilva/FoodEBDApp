namespace FoodTrackerApp.Data.Entities
{
    public class FoodMeal
    {
        [Key]
        public string UserID { get; set; }

        [Key, Column(Order = 1)]
        public int MealId { get; set; }
        [Key, Column(Order = 2)]
        public int FoodID { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Food Food { get; set; }

        public double Amount { get; set; }
        public Portion Portion { get; set; }
    }

    public enum Portion
    {
        unit = 0,
        grams = 1
    };

}

