namespace FoodTrackerApp.Pages.Food
{
    public class IndexModel : PageModel
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public IndexModel(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public IList<FoodModel> Food { get; set; }


        public async Task OnGetAsync()
        {
            var foods = await _context.Foods
                .Join(_context.ActionFoods, food => food.Id, af => af.FoodID,
                (food, af) => new
                {
                    Id = food.Id,
                    Name = food.FoodName,
                    Category = food.Category.Name,
                    Action = af.Action.Name
                }).ToListAsync();

            var foodAggrouped = foods.GroupBy(s => s.Id).Select(g => g.ToList());

            Food = foodAggrouped.Select(food => food.Select(f =>
            {
                var actionsWithComma = String.Join(", ", food.Select(a => a.Action).ToList());
                return new FoodModel(f.Id, f.Name, f.Category, actionsWithComma);

            }).First()).ToList();

        }
    }

    public class FoodModel
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string CategoryName { get; set; }
        public string Actions { get; set; }

        public FoodModel(int id, string foodName, string categoryName, string actions)
        {
            Id = id;
            FoodName = foodName;
            CategoryName = categoryName;
            Actions = actions;
        }
    }
}
