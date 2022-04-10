using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodTrackerApp.Pages.MyGeneralReport
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}
