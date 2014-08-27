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

namespace NinjaFactory.XMLReporting
{
    public class XMLReportCreator
    {
        public void CreateLostNinjasReport(TeamworkBlackDragonEntities db)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                DateTime startedBefore = DateTime.Now.AddMonths(-2);

                IEnumerable<LostNinjaReport> oldUnfinishedJobs;
                using (db)
                {
                    oldUnfinishedJobs = SelectOldUnfinishedJobs(db, startedBefore);
                    WriteToFile(oldUnfinishedJobs, filePath);
                }
            }
        }

        private IEnumerable<LostNinjaReport> SelectOldUnfinishedJobs(TeamworkBlackDragonEntities db, DateTime startedBefore)
        {
            return db.Jobs
                .Where(job => job.IsSuccessfull.HasValue == false)
                .Where(job => job.StartDate < startedBefore)
                .Select(job => new LostNinjaReport()
                       {
                           Job = job,
                           Ninja = job.Ninja,
                           Client = job.Client
                       });
        }

        private void WriteToFile(IEnumerable<LostNinjaReport> oldUnfinishedJobs, string filePath)
        {
            XElement ninjaXml = new XElement("lostNinjaReportsContainer");

            foreach (var report in oldUnfinishedJobs)
            {
                ninjaXml.Add(new XElement("LostNinjaReport",
                    new XElement("JobId", report.Job.Id),
                    new XElement("Client", report.Client.Name),
                    new XElement("Task", report.Job.Name),
                    new XElement("Price", report.Job.Price),
                    new XElement("NinjaId", report.Ninja.Id),
                    new XElement("NinjaName", report.Ninja.Name),
                    new XElement("NinjaKillingExperiance", report.Ninja.KillCount),
                    new XElement("NinjaMinimalPayment", report.Ninja.MinimalPersonalPrice)
                ));
            }

            ninjaXml.Save(filePath);
        }
    }
}