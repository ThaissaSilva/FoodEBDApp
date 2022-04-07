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
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public IList<BlacklistedFood> BlacklistedFood { get;set; }

        public async Task OnGetAsync()
        {
            BlacklistedFood = await _context.BlacklistedFoods.ToListAsync();
        }
    }
}
