namespace NinjaFactory.PDFReporting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using NinjaFactory.DataBase;

    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.Globalization;

    public class PDFIncomeReportCreator
    {
        public void CreatePDFReport(INinjaFactoryData db, string filePath)
        {
            IEnumerable<JobReport> successfullJobs;

            successfullJobs = this.SelectSuccesfullJobs(db);

            WriteToFile(successfullJobs, filePath);
        }

        private IEnumerable<JobReport> SelectSuccesfullJobs(INinjaFactoryData db)
        {
            DateTime currentDateTime = DateTime.Now.AddMonths(-1);

            return db.Jobs.All()
                .Where(job => job.EndDate.Value.Month == currentDateTime.Month)
                .Where(job => job.IsSuccessfull.Value == true)
                .Select(job => new JobReport()
                {
                    Job = job,
                    Ninja = job.Ninja,
                    Client = job.Client
                });
        }

        private void WriteToFile(IEnumerable<JobReport> selectedReport, string filePath)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 50, 50, 50);

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph("Successfully completed deals for last month: \n \n"));

            PdfPTable table = new PdfPTable(5);
            table.AddCell("Job name");
            table.AddCell("Client");
            table.AddCell("Ninja");
            table.AddCell("End date");
            table.AddCell("Income");

            CultureInfo c = CultureInfo.InvariantCulture;

            decimal incomeSum = 0;

            foreach (var entry in selectedReport)
            {
                table.AddCell(entry.Job.Name);
                table.AddCell(entry.Client.Name);
                table.AddCell(entry.Ninja.Name);
                table.AddCell(String.Format("{0:dd-MM-yyyy}", entry.Job.EndDate));
                table.AddCell(String.Format("{0:C}", entry.Job.Price));
                incomeSum += entry.Job.Price;
            }

            PdfPCell sumCell = new PdfPCell(new Phrase("Completed Jobs Total Income:"));
            sumCell.Colspan = 4;
            table.AddCell(sumCell);
            table.AddCell(String.Format("{0:C}",incomeSum));

            doc.Add(table);

            doc.Close();
        }
    }
}
