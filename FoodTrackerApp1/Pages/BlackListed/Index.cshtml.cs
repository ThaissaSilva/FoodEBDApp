
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
        public string UserId { get; set; }

        public List<FoodTrackerApp.Data.Entities.Food> Foods { get; set; }

        public async Task OnGetAsync()
        {
            UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Foods = _context.Foods.Where(b => b.BlacklistedFoods.Any(a => a.UserId == UserId)).ToList();

        }
    }
}
