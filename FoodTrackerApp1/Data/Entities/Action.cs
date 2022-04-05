namespace FoodTrackerApp.Data.Entities
{
    public class Action
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Action()
        {
        }

        public Action(string name)
        {
            this.Name = name;
        }
    }
}