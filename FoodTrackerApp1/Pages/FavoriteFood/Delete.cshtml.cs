
namespace FoodTrackerApp.Pages.FavoriteFood
{
    public class DeleteModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DeleteModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FavoriteFood = await _context.FavoriteFoods.FindAsync(id);

            if (FavoriteFood != null)
            {
                _context.FavoriteFoods.Remove(FavoriteFood);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
