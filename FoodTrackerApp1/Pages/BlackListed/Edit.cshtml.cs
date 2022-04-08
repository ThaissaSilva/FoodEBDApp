namespace FoodTrackerApp.Pages.BlackListed
{
    public class EditModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public EditModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlacklistedFood BlacklistedFood { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlacklistedFood = await _context.BlacklistedFoods.FirstOrDefaultAsync(m => m.Id == id);

            if (BlacklistedFood == null)
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

            _context.Attach(BlacklistedFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlacklistedFoodExists(BlacklistedFood.Id))
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

        private bool BlacklistedFoodExists(int id)
        {
            return _context.BlacklistedFoods.Any(e => e.Id == id);
        }
    }
}
