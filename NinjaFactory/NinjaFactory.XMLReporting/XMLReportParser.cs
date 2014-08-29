using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using NinjaFactory.DataBase;

namespace NinjaFactory.XMLReporting
{
    public class XMLReportParser
    {
        public void ParseLostNinjasReport(INinjaFactoryData db, string filePath)
        {
            XDocument lostNinjaReports = XDocument.Load(filePath);

            var lostNinjas = GetLostNinjas(lostNinjaReports, db);

            var failedMissions = GetFailedMissions(lostNinjaReports, db);

            RemoveFromDataBase(lostNinjas, failedMissions, db);
        }

        private IQueryable<Job> GetFailedMissions(XDocument lostNinjaReports, INinjaFactoryData db)
        {
            IEnumerable<int> failedMissionsIds = new List<int>();
            failedMissionsIds =
                               from ninja in lostNinjaReports.Descendants("LostNinjaReport")
                               select int.Parse(ninja.Element("JobId").Value);

            var failedMissions = db.Jobs.All().Where(j => failedMissionsIds.Contains(j.Id));
            return failedMissions;
        }

        private IQueryable<Ninja> GetLostNinjas(XDocument lostNinjaReports, INinjaFactoryData db)
        {
            IEnumerable<int> lostNinjaIds = new List<int>();
            lostNinjaIds =
                          from ninja in lostNinjaReports.Descendants("LostNinjaReport")
                          select int.Parse(ninja.Element("NinjaId").Value);
            var lostNinjas = db.Ninjas.All().Where(n => lostNinjaIds.Contains(n.Id));
            return lostNinjas;
        }

        private void RemoveFromDataBase(IQueryable<Ninja> lostNinjas, IQueryable<Job> failedMissions, INinjaFactoryData db)
        {
            foreach (Ninja nin in lostNinjas)
            {
                nin.IsDeleted = true;
            }
            foreach (Job job in failedMissions)
            {
                job.IsSuccessfull = false;
                job.EndDate = DateTime.Now;
            }
            db.SaveChanges();
        }
    }
}