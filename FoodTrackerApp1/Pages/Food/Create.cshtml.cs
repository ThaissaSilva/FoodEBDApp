namespace FoodTrackerApp.Pages.Food
{
    public class CreateModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public CreateModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.Food Food { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Foods.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
