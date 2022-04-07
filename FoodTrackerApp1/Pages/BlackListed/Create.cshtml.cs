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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BlacklistedFood BlacklistedFood { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            BlacklistedFood.UserId = userId;

            BlacklistedFood.CreatedOn = DateTime.Now;
            _context.BlacklistedFoods.Add(BlacklistedFood);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
