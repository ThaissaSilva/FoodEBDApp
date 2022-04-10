namespace FoodTrackerApp.Pages.GeneralReport
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public string UserId { get; set; }
       
        public string TopUsers { get; set; }
        
        public int CountUsers { get; set; }

        public int CountMeals { get; set; }

        public string TopFoods { get; set; }

        public IActionResult OnGet()
        {
            TopUsers = GetTopUsers();
            TopFoods = GetTopFoods();
            CountMeals = GetCountMeals();
            CountUsers = GetCountUsers();

            return Page();
        }

        private string GetTopUsers()
        {
            var value = 5;

            var topActive = _context.Meals.Include(m => m.User).ToList()
                .GroupBy(ta => ta.User).OrderByDescending(ta => ta.Count()).Take(value);
           
            var activeName = String.Join(" | ", topActive.Select(an => an.First().User.Email));

             return activeName;
        }

        private string GetTopFoods()
        {
            var value = 10;

            var topFood = _context.FoodMeals.GroupBy(t => t.FoodID).OrderByDescending(t => t.Count()).Take(value);

            var name = String.Join(" | ", topFood.Select(n => n.First().Food.FoodName));

             return name;
        }

        private int GetCountMeals()
        {
            var meals = _context.Meals.Count();

            return meals;
        }

        private int GetCountUsers()
        {
            var users = _context.Users.Count();

            return users;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
