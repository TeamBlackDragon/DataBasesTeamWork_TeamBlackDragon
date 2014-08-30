namespace NinjaFactory.Imports
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.IO.Compression;

    public class ExcelImport
    {
        //================================================================================================
        //                                      HOW TO USE EXAMPLE
        //================================================================================================
        
        //The name of the zip file
        //string zipFileName = "Sample-Sales-Reports.zip";

        //The full path where the zip archive is stored. In our case the path that is returned from the OpenDialog
        //string zipFilePath = @"E:\DEV\DataBasesTeamWork_TeamBlackDragon\Example TeamBlackDragon\" + zipFileName;

        //This can be a constant and must be extended to match .xlsx too
        //string filePattern = "*.xls";

        //The folder where the zip will be extracted
        //string extractFolderPath = @"C:\Users\vesel_000\Desktop\ZipFile-from-C#";

        //ExtractFile(zipFileName, zipFilePath, extractFolderPath);

        //Here the files will be imported to the DB
        //ProcessExcelFiles(extractFolderPath, filePattern);

        //================================================================================================
        //                                      HOW TO USE EXAMPLE
        //================================================================================================

        private static void ExtractFile(string zipFileName, string zipSourcePath, string extractToPath)
        {
            //Check if the folder is not empty to delete everything in it

            if (Directory.GetDirectories(extractToPath).Length == 0 && Directory.GetFiles(extractToPath).Length == 0)
            {
                Console.WriteLine("Folder is empty!");
            }
            else
            {
                Console.WriteLine("Folder is not empty!");
                Directory.Delete(extractToPath + "\\" + zipFileName.Split('.')[0], true);
            }
            
            //Extract the .zip file

            ZipFile.ExtractToDirectory(zipSourcePath, extractToPath);
        }

        private static DataTable ReadExcelFile(string filePath, string sheetName)
        {
            OleDbConnection connection = new OleDbConnection();

            using (connection)
            {
                DataTable table = new DataTable();

                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";

                OleDbCommand command = new OleDbCommand();
                using (command)
                {
                    command.CommandText = "SELECT * FROM [" + sheetName + "$]";
                    command.Connection = connection;

                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    using (adapter)
                    {
                        adapter.SelectCommand = command;
                        adapter.Fill(table);
                        
                        return table;
                    }
                }
            }
        }
        
        //In this method require the db as parameter if needed
        private static void ImportExcelFilesIntoDb(string[] files)
        {
            string sheetName = "Sales";

            foreach (var filePath in files)
            {
                DataTable excelTable = ReadExcelFile(filePath, sheetName);
                
                for (int i = 2; i < excelTable.Rows.Count - 1; i++)
                {
                    var row = excelTable.Rows[i];

                    //First item => row.ItemArray[0]
                    //Second item => row.ItemArray[1]
                    //...

                    //INSERT INTO MSSQL(...) VALUES(...)
                }
            }
        }

        private static void ProcessExcelFiles(string rootDirPath, string pattern)
        {
            var files = Directory.GetFiles(rootDirPath, pattern);

            ImportExcelFilesIntoDb(files);

            var directories = Directory.GetDirectories(rootDirPath);

            foreach (var dir in directories)
            {
                var dirFiles = Directory.GetFiles(dir, pattern);

                ImportExcelFilesIntoDb(dirFiles);

                ProcessExcelFiles(dir, pattern);
            }
        }
    }
}
