
namespace FoodTrackerApp.Pages.ActionFood
{
    public class DeleteModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DeleteModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.Action ActionFood { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActionFood = await _context.Actions.FirstOrDefaultAsync(m => m.Id == id);

            if (ActionFood == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActionFood = await _context.Actions.FindAsync(id);

            if (ActionFood != null)
            {
                _context.Actions.Remove(ActionFood);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
