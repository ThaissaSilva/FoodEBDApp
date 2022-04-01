
namespace FoodTrackerApp.Pages.FoodMeal
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        
        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {           
            _context = context;
        }

        public IList<FoodTrackerApp.Data.Entities.FoodMeal> FoodMeal { get;set; }

        public async Task OnGetAsync()
        {          
            FoodMeal = await _context.FoodMeals
                .Include(f => f.Food).ToListAsync();
        }
    }
}
