
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
            // Upload the file if less than 2 MB
            using (var ms = new ExcelPackage(memoryStream))
            {
                await InsertActions(ms);
                await InsertCategories(ms);
                await InsertFoods(ms);
            };


            //List & lt; CustomerModel & gt; customers = new List& lt; CustomerModel & gt; ();
            //string filePath = string.Empty;
            //if (postedFile != null)
            //{
            //    string path = Server.MapPath("~/Uploads/");
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }

            //    filePath = path + Path.GetFileName(postedFile.FileName);
            //    string extension = Path.GetExtension(postedFile.FileName);
            //    postedFile.SaveAs(filePath);

            //    //Read the contents of CSV file.
            //    string csvData = System.IO.File.ReadAllText(filePath);

            //    //Execute a loop over the rows.
            //    foreach (string row in csvData.Split('\n'))
            //    {
            //        if (!string.IsNullOrEmpty(row))
            //        {
            //            customers.Add(new CustomerModel
            //            {
            //                CustomerId = Convert.ToInt32(row.Split(',')[0]),
            //                Name = row.Split(',')[1],
            //                Country = row.Split(',')[2]
            //            });
            //        }
            //    }

        }

        private async Task InsertActions(ExcelPackage ms)
        {
            ExcelWorksheet ws = ms.Workbook.Worksheets[0];
            var rowSize = ws.Dimension.Rows;
            var columSize = ws.Dimension.Columns;

            for (int l = 2; l <= rowSize; l++)
            {
                //var cId = 1;
                var cName = 2;

                //var id = Int32.Parse(ws.Cells[l, cId].Value.ToString());
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

                var category = ws.Cells[l, cCategory].Value.ToString();

                var food = new Data.Entities.Food(name, cCategory);

                _context.Foods.Add(food);
                await _context.SaveChangesAsync();
            }

        }

        //private async Task InsertFoodAction(ExcelPackage ms)
        //{
        //    ExcelWorksheet ws = ms.Workbook.Worksheets[3];
        //    var rowSize = ws.Dimension.Rows;
        //    var columSize = ws.Dimension.Columns;

        //    for (int l = 2; l <= rowSize; l++)
        //    {
        //        var cFood = 1;

        //        var cAction = 2;

        //        var food = ws.Cells[l, cFood].Value.ToString();

        //        var action = ws.Cells[l, cAction].Value.ToString();

        //        var foddAction = new Data.Entities.FoodAction(n, cCategory);

        //        _context.FoodAction
        //        await _context.SaveChangesAsync();

        //        //falta acrescentar o Id da category, ver se deve aperecer no page ou s'o na base de dados
        //    }
        //}
    }
}
