namespace FoodTrackerApp.Pages.FavoriteFood
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

        public List<FoodTrackerApp.Data.Entities.FavoriteFood> FavoriteFood { get;set; }

        public async Task OnGetAsync()
        {
            var user = await _context.Users.FirstAsync(u => u.Email == User.Identity.Name);

            FavoriteFood = await _context.FavoriteFoods.Where(b => b.User == user).Include(b => b.Food).ToListAsync();
        }
    }
}
