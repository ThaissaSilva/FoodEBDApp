namespace FoodTrackerApp.Data.Entities
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public char Gender { get; set; }
    }
}
