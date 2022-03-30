namespace FoodTrackerApp.Data.Entities
{
    public class Action
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Action(string name)
        {
            this.Name = name;
            this.Foods = new HashSet<Food>();
        }

        public virtual ICollection<Food> Foods { get; set; }
    }
}
