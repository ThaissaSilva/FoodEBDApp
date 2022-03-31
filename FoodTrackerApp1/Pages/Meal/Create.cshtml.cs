namespace FoodTrackerApp.Pages.Meal
{
    public class CreateModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public CreateModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public int[] SelectedMeals { get; set; }

        public SelectList Meals { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var meals = await _context.Meals.ToListAsync(); 
            IEnumerable<string> items = (IEnumerable<string>)meals.Select(m => m.Name);

            Meals = new SelectList((IEnumerable<string>)meals, "User", "Name");

            return Page();
        }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.Meal Meal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Meals.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
