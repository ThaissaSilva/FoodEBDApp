using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodTrackerApp.Data;
using FoodTrackerApp.Data.Entities;

namespace FoodTrackerApp.Pages.Meal
{
    public class DetailsModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DetailsModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public FoodTrackerApp.Data.Entities.Meal Meal { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meal = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id);

            if (Meal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
