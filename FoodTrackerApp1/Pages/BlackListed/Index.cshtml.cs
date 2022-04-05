namespace FoodTrackerApp.Pages.BlackListed
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public BlacklistedFood BlacklistedFood { get;set; }

        public async Task OnGetAsync()
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            BlacklistedFood = await _context.BlacklistedFoods.FirstAsync(b => b.UserId == userId);

            _context.BlacklistedFoods.Remove(BlacklistedFood);
        }
    }
}
