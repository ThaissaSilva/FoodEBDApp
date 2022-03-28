
namespace FoodTrackerApp.Pages.ActionFood
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public IList<FoodTrackerApp.Data.Entities.Action> ActionFood { get;set; }

        public async Task OnGetAsync()
        {
            ActionFood = await _context.Actions.ToListAsync();
        }
    }
}
