namespace FoodTrackerApp.Pages.FavoriteFood
{
    public class EditModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public EditModel(FoodTrackerApp.Data.TrackerDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FavoriteFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteFoodExists(FavoriteFood.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FavoriteFoodExists(string id)
        {
            return _context.FavoriteFoods.Any(e => e.UserId == id);
        }
    }
}
