using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodTrackerApp.Pages.MyUser
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public string UserId { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _context.Users.FirstAsync(u => u.Email == User.Identity.Name);
        }
    }
}
