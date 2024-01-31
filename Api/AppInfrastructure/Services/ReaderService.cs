using ExcelDataReader;
using System.Data;

namespace AppInfrastructure.Services
{
    public class ReaderService
    {

        public void Reader()
        {
            var filePath = "D:\\Games\\ApiCsvReader\\Data.xlsx";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var streamval = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(streamval))
                {


                    var configuration = new ExcelDataSetConfiguration
                    {

                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };
                    var dataSet = reader.AsDataSet(configuration);
                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                Console.Write(item + "\t");
                            }
                        }
                        //Console.WriteLine("Rows :  " + dataTable.Rows[0]);
                        //Console.WriteLine("Columns :  " + dataTable.Columns.Count);
                    }
                    else
                    {
                        Console.WriteLine("Sheet doesn't exist");
                    }
                }
            }
        }
    }
}
    

