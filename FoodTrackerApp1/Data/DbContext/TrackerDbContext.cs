namespace FoodTrackerApp.Data
{
    public class TrackerDbContext : IdentityDbContext
    {
        public DbSet<Entities.Action> Actions { get; set; }
        public DbSet<BlacklistedFood> BlacklistedFoods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FavoriteFood> FavoriteFoods { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodMeal> FoodMeals { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<User> Users { get; set; }

        public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FoodMeal>().HasKey(c => new { c.MealId, c.FoodID });
        }
    }
}