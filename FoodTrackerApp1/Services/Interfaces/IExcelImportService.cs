namespace FoodTrackerApp.Services.Interfaces
{
    public interface IExcelImportService
    {
        public Task FileImportAsync(MemoryStream memoryStream);
    }
}


