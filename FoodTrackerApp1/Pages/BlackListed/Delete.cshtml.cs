
namespace FoodTrackerApp.Pages.BlackListed
{
    public class DeleteModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DeleteModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlacklistedFood BlacklistedFood { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlacklistedFood = await _context.BlacklistedFoods.FirstOrDefaultAsync(m => m.Id == id);

            if (BlacklistedFood == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlacklistedFood = await _context.BlacklistedFoods.FindAsync(id);

            if (BlacklistedFood != null)
            {
                _context.BlacklistedFoods.Remove(BlacklistedFood);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
