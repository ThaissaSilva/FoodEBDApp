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
        public int FoodId { get; set; }
        public SelectList Foods { get; set; }

        public List<FoodTrackerApp.Data.Entities.Food> FoodsFromDB { get; set; }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.BlacklistedFood BlackListedFood { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            FoodsFromDB = await _context.Foods.ToListAsync();

            BlackListedFood.User = await _context.Users.FirstAsync(u => u.Email == User.Identity.Name);
            BlackListedFood.Food = FoodsFromDB.FirstOrDefault(f => f.Id == FoodId);
            BlackListedFood.CreatedOn = DateTime.Now;

            _context.BlacklistedFoods.Add(BlackListedFood);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
