namespace FoodTrackerApp.Pages.ActionFood
{
    public class DetailsModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DetailsModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

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
    }
}
