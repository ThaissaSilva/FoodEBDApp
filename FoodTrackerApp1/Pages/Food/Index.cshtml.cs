namespace FoodTrackerApp.Pages.Food
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public IList<FoodTrackerApp.Data.Entities.Food> Food { get;set; }

        public async Task OnGetAsync()
        {
            Food = await _context.Foods.ToListAsync();
        }
    }
}
