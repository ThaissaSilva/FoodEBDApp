namespace FoodTrackerApp.Pages.Meal
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public IList<FoodTrackerApp.Data.Entities.Meal> Meal { get;set; }

        public async Task OnGetAsync()
        {
            Meal = await _context.Meals.ToListAsync();
        }
    }
}
