
namespace FoodTrackerApp.Pages.FavoriteFood
{
    public class DetailsModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DetailsModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public FoodTrackerApp.Data.Entities.FavoriteFood FavoriteFood { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FavoriteFood = await _context.FavoriteFoods.FirstOrDefaultAsync(m => m.UserId == id);

            if (FavoriteFood == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
