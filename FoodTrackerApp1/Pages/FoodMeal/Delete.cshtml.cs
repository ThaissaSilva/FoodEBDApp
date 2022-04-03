
namespace FoodTrackerApp.Pages.FoodMeal
{
    public class DeleteModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DeleteModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? foodId, int? mealId)
        {
            if (foodId == null && mealId == null)
            {
                return NotFound();
            }

            FoodMeal = await _context.FoodMeals.FirstAsync(f => f.FoodID == foodId.Value && f.MealId == mealId.Value) ;

            if (FoodMeal != null)
            {
                _context.FoodMeals.Remove(FoodMeal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
