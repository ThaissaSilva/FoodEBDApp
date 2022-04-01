
using System.Security.Claims;

namespace FoodTrackerApp.Pages.FoodMeal
{
    public class CreateModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public CreateModel(FoodTrackerApp.Data.TrackerDbContext context)
        {            
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FoodID"] = new SelectList(_context.Foods, "Id", "FoodName");
            ViewData["MealID"] = new SelectList(_context.Meals, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.FoodMeal FoodMeal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
                      
            _context.FoodMeals.Add(FoodMeal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
