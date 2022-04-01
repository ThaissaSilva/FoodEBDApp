
namespace FoodTrackerApp.Pages.FoodMeal
{
    public class DetailsModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DetailsModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public FoodTrackerApp.Data.Entities.FoodMeal FoodMeal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? foodId, int? mealId)
        {
            if (foodId == null && mealId == null)
            {
                return NotFound();
            }

            FoodMeal = await _context.FoodMeals
                .Include(f => f.Food).FirstOrDefaultAsync(m => m.MealId == mealId && m.FoodID == foodId);

            if (FoodMeal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
