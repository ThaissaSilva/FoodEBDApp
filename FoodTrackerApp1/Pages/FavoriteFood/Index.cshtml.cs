
namespace FoodTrackerApp.Pages.FavoriteFood
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public IList<FoodTrackerApp.Data.Entities.FavoriteFood> FavoriteFood { get;set; }

        public async Task OnGetAsync()
        {
            FavoriteFood = await _context.FavoriteFoods.ToListAsync();
        }
    }
}
