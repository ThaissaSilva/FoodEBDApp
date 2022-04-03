namespace FoodTrackerApp.Data.Entities
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FoodName { get; set; }

        //FK
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public Food()
        {
        }

        public Food(string foodName, int category)
        {
            this.FoodName = foodName;
            this.Category = new Category(category);
            this.Actions = new HashSet<Action>();
        }

        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<FoodMeal> FoodMeals { get; set; }
    }
}
