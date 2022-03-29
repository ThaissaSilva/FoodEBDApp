using FoodTrackerApp.Services.Interfaces;

namespace FoodTrackerApp.Services
{
    public class ExcelImportService : IExcelImportService
    {
        public void FileImport()
        {
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
    }  
}
