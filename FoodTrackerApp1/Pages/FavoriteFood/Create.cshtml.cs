namespace FoodTrackerApp.Pages.FavoriteFood
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

        public int[] SelectedFoods { get; set; }

        public SelectList Foods { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var foods = await _context.Foods.ToListAsync();  //meal 
            IEnumerable<string> items = foods.Select(f => f.FoodName);

            Foods = new SelectList(foods, "Id", "FoodName");

            return Page();
        }
                
        [BindProperty]
        public FoodTrackerApp.Data.Entities.FavoriteFood FavoriteFood { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            FavoriteFood.UserId = userId;
            FavoriteFood.CreatedOn = DateTime.Now;

            _context.FavoriteFoods.Add(FavoriteFood);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
