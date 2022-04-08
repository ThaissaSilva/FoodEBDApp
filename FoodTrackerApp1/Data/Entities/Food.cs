namespace FoodTrackerApp.Data.Entities
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
             
        public string FoodName { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Food()
        {
        }

        public Food(string foodName, Category category)
        {
            this.FoodName = foodName;
            this.Category = category;
        }
    }
}