namespace FoodTrackerApp.Pages.BlackListed
{
    public class CreateModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateModel(FoodTrackerApp.Data.TrackerDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            FoodsFromDB = await _context.Foods.ToListAsync();
            
            Foods = new SelectList(FoodsFromDB, "Id", "FoodName");

            return Page();
        }

        [BindProperty]
        public int SelectedFoodId { get; set; }
        public SelectList Foods { get; set; }

        public List<FoodTrackerApp.Data.Entities.Food> FoodsFromDB { get; set; }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.Food Food { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Food = _context.Foods.FirstOrDefault(f => f.Id == SelectedFoodId);


            if (Food.BlacklistedFoods == null)
            {
                Food.BlacklistedFoods = new List<FoodTrackerApp.Data.Entities.BlacklistedFood>();
            }

            Food.BlacklistedFoods.Add(new FoodTrackerApp.Data.Entities.BlacklistedFood(userId));

            var blacklistedFood = await _context.BlacklistedFoods.ToListAsync();
                

            _context.Foods.Update(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
