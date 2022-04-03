﻿namespace FoodTrackerApp.Pages.BlackListed
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
            var foods = await _context.Foods.ToListAsync(); 
            IEnumerable<string> items = foods.Select(f => f.FoodName);
            
            ViewData["FoodID"] = new SelectList(foods, "Id", "FoodName");


            return Page();
        }
        
        [BindProperty]
        public FoodTrackerApp.Data.Entities.BlacklistedFood BlacklistedFood { get; set; }

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

            foreach (var item in SelectedFoods)
            {
                BlacklistedFood.Foods.Add(await _context.Foods.FirstAsync(f => f.Id == item));            
            }

            _context.BlacklistedFoods.Add(BlacklistedFood);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}