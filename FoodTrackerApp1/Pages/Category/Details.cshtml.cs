
namespace FoodTrackerApp.Pages.Category
{
    public class DetailsModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DetailsModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public FoodTrackerApp.Data.Entities.Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
