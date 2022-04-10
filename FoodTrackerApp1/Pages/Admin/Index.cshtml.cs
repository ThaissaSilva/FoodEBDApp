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
                await this.ExcelImportService.FileImportAsync(memoryStream);
            }
            return RedirectToPage("./Index");
        }
    }
}
