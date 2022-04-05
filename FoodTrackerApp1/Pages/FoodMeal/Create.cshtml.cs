using System.Security.Claims;

namespace FoodTrackerApp.Pages.FoodMeal
{
    public class CreateModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public CreateModel(FoodTrackerApp.Data.TrackerDbContext context)
        {            
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FoodID"] = new SelectList(_context.Foods, "Id", "FoodName");
            ViewData["MealID"] = new SelectList(_context.Meals, "Id", "Name");

            test();

            return Page();
        }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.FoodMeal FoodMeal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
                      
            _context.FoodMeals.Add(FoodMeal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        public async Task test()
        {

            var meals = await _context.Meals.ToListAsync();

            var mealsByDate = meals.GroupBy(m => m.StartDate.Date);

            var actions = await _context.Actions.ToListAsync();


            foreach (var mealsInDate in mealsByDate)
            {
                foreach (var eachMeal in mealsInDate.ToList())
                {
                    var foodMealFromTheMeal = await _context.FoodMeals.Where(fm => fm.MealId == eachMeal.Id).ToListAsync();

                    var foods = (List<FoodTrackerApp.Data.Entities.Food>)foodMealFromTheMeal.Select(s => s.Food);

                    foreach (var a in actions)
                    {
                        //foods.Any(f => f.Actions.Contains(a));
                    }
                }
            }

        }
    }
}
