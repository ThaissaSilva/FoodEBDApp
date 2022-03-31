
namespace FoodTrackerApp.Pages.BlackListed
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public IList<BlacklistedFood> BlacklistedFood { get;set; }

        public async Task OnGetAsync()
        {
            BlacklistedFood = await _context.BlacklistedFoods.ToListAsync();
        }
    }
}
