﻿
using System.Security.Claims;


namespace FoodTrackerApp.Pages.Meal
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
        public FoodTrackerApp.Data.Entities.Meal Meal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            Meal.UserId = userId;

            _context.Meals.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}