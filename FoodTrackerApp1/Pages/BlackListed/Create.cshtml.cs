namespace FoodTrackerApp.Pages.BlackListed
{
    public class CreateModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public CreateModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public int[] SelectedFoods { get; set; }

        public SelectList Foods { get; set; }
        
        public async Task<IActionResult> OnGet()
        {
            var foods = await _context.Foods.ToListAsync(); 
            IEnumerable<string> items = foods.Select(f => f.FoodName);
            
            Foods = new SelectList(foods, "Id", "FoodName");

            return Page();
        }
        
        [BindProperty]
        public FoodTrackerApp.Data.Entities.BlacklistedFood BlacklistedFood { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BlacklistedFoods.Add(BlacklistedFood);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
