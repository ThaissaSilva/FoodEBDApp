namespace FoodTrackerApp.Services
{
    public class ExcelImportService : IExcelImportService
    {
        private readonly FoodTrackerApp.Data.TrackerDbContext _context;

        public ExcelImportService(FoodTrackerApp.Data.TrackerDbContext context)
        {
            _context = context;
        }

        public async Task FileImportAsync(MemoryStream memoryStream)
        {
            using (var ms = new ExcelPackage(memoryStream))
            {
                await InsertActions(ms);
                await InsertCategories(ms);
                await InsertFoods(ms);
                await InsertFoodsAction(ms);
            };
        }

        private async Task InsertActions(ExcelPackage ms)
        {
            ExcelWorksheet ws = ms.Workbook.Worksheets[0];
            var rowSize = ws.Dimension.Rows;
            var columSize = ws.Dimension.Columns;

            for (int l = 2; l <= rowSize; l++)
            {
                var cName = 2;

                var name = ws.Cells[l, cName].Value.ToString();

                var action = new Data.Entities.Action(name);

                _context.Actions.Add(action);
                await _context.SaveChangesAsync();
            }
        }

        private async Task InsertCategories(ExcelPackage ms)
        {
            ExcelWorksheet ws = ms.Workbook.Worksheets[1];
            var rowSize = ws.Dimension.Rows;
            var columSize = ws.Dimension.Columns;

            for (int l = 2; l <= rowSize; l++)
            {
                var cName = 2;

                var name = ws.Cells[l, cName].Value.ToString();

                var category = new Data.Entities.Category(name);

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
            }
        }

        private async Task InsertFoods(ExcelPackage ms)
        {
            ExcelWorksheet ws = ms.Workbook.Worksheets[2];
            var rowSize = ws.Dimension.Rows;
            var columSize = ws.Dimension.Columns;

            for (int l = 2; l <= rowSize; l++)
            {
                var cName = 2;
                var cCategory = 3;

                var name = ws.Cells[l, cName].Value.ToString();
                var categoryId = Int32.Parse(ws.Cells[l, cCategory].Value.ToString());

                var category = await _context.Categories.FirstAsync(f => f.Id == categoryId);

                var food = new Data.Entities.Food(name, category);

                _context.Foods.Add(food);
                await _context.SaveChangesAsync();
            }
        }

        private async Task InsertFoodsAction(ExcelPackage ms)
        {
            ExcelWorksheet ws = ms.Workbook.Worksheets[3];
            var rowSize = ws.Dimension.Rows;
            var columSize = ws.Dimension.Columns;

            for (int l = 2; l <= rowSize; l++)
            {
                var cFoodId = 1;
                var cActionId = 2;

                var foodId = Int32.Parse(ws.Cells[l, cFoodId].Value.ToString());
                var actionId = Int32.Parse(ws.Cells[l, cActionId].Value.ToString());

                var food = await _context.Foods.FirstAsync(f => f.Id == foodId);
                var action = await _context.Actions.FirstAsync(a => a.Id == actionId);

                var actionFood = new ActionFood();

                actionFood.Action = action;
                actionFood.Food = food;

                _context.ActionFoods.Add(actionFood);
                await _context.SaveChangesAsync();
            }
        }
    }
}
