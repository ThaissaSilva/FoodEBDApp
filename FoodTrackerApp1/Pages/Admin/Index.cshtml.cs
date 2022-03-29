using FoodTrackerApp.Services.Interfaces;
using OfficeOpenXml;

namespace FoodTrackerApp.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IExcelImportService ExcelImportService { get; set; }

        public IndexModel(IExcelImportService importService)
        {
            this.ExcelImportService = importService;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.formFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                using (var ms = new ExcelPackage(memoryStream))
                {
                    ExcelWorksheet ws = ms.Workbook.Worksheets[1];
                    var count = ws.Dimension.Rows;
                };                  
            }
            //this.ExcelImportService.FileImport();
            return RedirectToPage("./Index");
        }
    }

    public class FileUpload
    {
        public IFormFile formFile { get; set; }   
    }
}
