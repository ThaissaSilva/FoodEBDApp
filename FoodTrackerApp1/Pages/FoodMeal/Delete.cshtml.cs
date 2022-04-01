using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodTrackerApp.Data;
using FoodTrackerApp.Data.Entities;

namespace FoodTrackerApp.Pages.FoodMeal
{
    public class DeleteModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DeleteModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodTrackerApp.Data.Entities.FoodMeal FoodMeal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? foodId, int? mealId)
        {
            if (foodId == null && mealId == null)
            {
                return NotFound();
            }

            FoodMeal = await _context.FoodMeals
                .Include(f => f.Food).FirstOrDefaultAsync(m => m.MealId == mealId && m.FoodID == foodId);

            if (FoodMeal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodMeal = await _context.FoodMeals.FindAsync(id);

            if (FoodMeal != null)
            {
                _context.FoodMeals.Remove(FoodMeal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
