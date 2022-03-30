﻿namespace FoodTrackerApp.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}
