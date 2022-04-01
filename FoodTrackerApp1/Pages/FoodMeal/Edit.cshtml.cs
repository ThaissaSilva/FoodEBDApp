
namespace FoodTrackerApp.Pages.FoodMeal
{
    public class EditModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public EditModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.FoodMeal FoodMeal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? foodId, int? mealId)
        {
            if ( foodId == null && mealId == null)
            {
                return NotFound();
            }

            FoodMeal = await _context.FoodMeals
                .Include(f => f.Food).FirstOrDefaultAsync(m => m.MealId == mealId && m.FoodID == foodId );

            if (FoodMeal == null)
            {
                return NotFound();
            }
           ViewData["FoodID"] = new SelectList(_context.Foods, "Id", "FoodName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FoodMeal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodMealExists(FoodMeal.MealId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FoodMealExists(int id)
        {
            return _context.FoodMeals.Any(e => e.MealId == id);
        }
    }
}
