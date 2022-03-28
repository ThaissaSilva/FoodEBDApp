namespace FoodTrackerApp.Pages.ActionFood
{
    public class EditModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public EditModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.Action ActionFood { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActionFood = await _context.Actions.FirstOrDefaultAsync(m => m.Id == id);

            if (ActionFood == null)
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

            _context.Attach(ActionFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionFoodExists(ActionFood.Id))
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

        private bool ActionFoodExists(int id)
        {
            return _context.Actions.Any(e => e.Id == id);
        }
    }
}
