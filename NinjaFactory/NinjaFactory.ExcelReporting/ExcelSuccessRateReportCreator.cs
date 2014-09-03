namespace NinjaFactory.ExcelReporting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using System.IO;
    using System.Drawing;
    using NinjaFactory.DataBase.MySql;

    /// <summary>
    /// Creates success rate of ninjas reports as Excel files
    /// </summary>
    public class ExcelSuccessRateReportCreator
    {
        public void CreateSuccessRateReport(INinjaCatalogueModelUnitOfWork db, string filePath)
        {

            IEnumerable<SuccessRateReport> successRateReport;

            successRateReport = this.SelectSuccessRateList(db);
            this.WriteToFile(successRateReport, filePath);
        }

        private IEnumerable<SuccessRateReport> SelectSuccessRateList(INinjaCatalogueModelUnitOfWork db)
        {
            return db.Ninja_catalogue_items
                .OrderBy(item => item.SuccessRate)
                .Select(item => new SuccessRateReport()
                       {
                           NinjaCatalogueItem = item,
                       })
                .ToList<SuccessRateReport>();
        }

        private void WriteToFile(IEnumerable<SuccessRateReport> successRateReportList, string filePath)
        {
            // Create the file using the FileInfo object
            var excelFile = File.Create(filePath);

            using (var excelPackage = new ExcelPackage(excelFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Success rate report - " + DateTime.Now.ToShortDateString());

                worksheet.TabColor = Color.Blue;
                worksheet.DefaultRowHeight = 12;
                worksheet.HeaderFooter.FirstFooter.LeftAlignedText = string.Format("Generated: {0}", DateTime.Now.ToShortDateString());
                worksheet.Row(1).Height = 20;
                worksheet.Row(2).Height = 18;

                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Name of the ninja";
                worksheet.Cells[1, 3].Value = "Weapon used";
                worksheet.Cells[1, 4].Value = "Speciality";
                worksheet.Cells[1, 5].Value = "Jobs Count";
                worksheet.Cells[1, 6].Value = "Jobs Count";
                worksheet.Cells[1, 7].Value = "Kill Count";
                worksheet.Cells[1, 8].Value = "Success Rate";

                var rowIndex = 2;
                foreach (var report in successRateReportList)
                {
                    worksheet.Cells[rowIndex, 1].Value = report.NinjaCatalogueItem.Id;
                    worksheet.Cells[rowIndex, 2].Value = report.NinjaCatalogueItem.Name;
                    worksheet.Cells[rowIndex, 3].Value = report.NinjaCatalogueItem.Weapon;
                    worksheet.Cells[rowIndex, 4].Value = report.NinjaCatalogueItem.Speciality;
                    worksheet.Cells[rowIndex, 5].Value = report.NinjaCatalogueItem.JobsCount;
                    worksheet.Cells[rowIndex, 6].Value = report.NinjaCatalogueItem.SuccessfulJobsCount;
                    worksheet.Cells[rowIndex, 7].Value = report.NinjaCatalogueItem.KillCount;
                    worksheet.Cells[rowIndex, 8].Value = report.NinjaCatalogueItem.SuccessRate;

                    rowIndex++;
                }

                using (var range = worksheet.Cells[1, 1, 1, 8])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Black);
                    range.Style.Font.Color.SetColor(Color.WhiteSmoke);
                    range.Style.ShrinkToFit = true;
                }

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();
                worksheet.Column(4).AutoFit();
                worksheet.Column(5).AutoFit();
                worksheet.Column(6).AutoFit();
                worksheet.Column(7).AutoFit();
                worksheet.Column(8).AutoFit();

                // Set document properties
                excelPackage.Workbook.Properties.Title = "Success rate report";
                excelPackage.Workbook.Properties.Author = "Team Black Dragon";
                excelPackage.Workbook.Properties.Company = "Telerik Academy";

                excelPackage.Save();
            }
        }
    }
}
