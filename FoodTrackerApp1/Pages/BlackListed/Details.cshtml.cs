using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodTrackerApp.Data;
using FoodTrackerApp.Data.Entities;

namespace FoodTrackerApp.Pages.BlackListed
{
    public class DetailsModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public DetailsModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public BlacklistedFood BlacklistedFood { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlacklistedFood = await _context.BlacklistedFoods.FirstOrDefaultAsync(m => m.UserId == id);

            if (BlacklistedFood == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
