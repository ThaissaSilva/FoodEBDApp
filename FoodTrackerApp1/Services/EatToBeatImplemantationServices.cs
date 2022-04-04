namespace FoodTrackerApp.Services
{
    public class EatToBeatImplemantationServices
    {
        public User User { get; set; } 

        public FoodMeal FoodMeal { get; set; }
        
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public EatToBeatImplemantationServices(User user, FoodMeal foodMeal)
        {
            User = user;
            FoodMeal = foodMeal;
        }

        public EatToBeatImplemantationServices(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public async Task GetUserStatus(string userId)
        {
            var meals = await _context.Meals.Where(m => m.UserId == userId).ToListAsync();

            var mealsByDate = meals.GroupBy(m => m.StartDate.Date);
            
            var actions = await _context.Actions.ToListAsync();


            foreach ( var mealsInDate in mealsByDate)
            {
                foreach(var eachMeal in mealsInDate.ToList())
                {
                    var foodMealFromTheMeal = await _context.FoodMeals.Where(fm => fm.MealId == eachMeal.Id).ToListAsync();

                    var foods = (List<Food>)foodMealFromTheMeal.Select(s => s.Food);

                    foreach (var a in actions)
                    {
                        foods.Any(f => f.Actions.Contains(a));
                    }
                }
            }
        }

    }
}
