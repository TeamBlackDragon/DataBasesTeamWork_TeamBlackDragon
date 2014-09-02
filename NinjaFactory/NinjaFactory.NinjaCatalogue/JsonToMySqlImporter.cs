using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NinjaFactory.DataBase.MySql;

namespace NinjaFactory.NinjaCatalogue
{
    public class JsonToMySqlImporter
    {
        public JsonToMySqlImporter(NinjaCatalogueModel mySqlContext, NinjaCatalogueJsonParser parser)
        {
            this.parser = parser;
            this.mySqlContext = mySqlContext;
        }

        public JsonToMySqlImporter(NinjaCatalogueModel mySqlContext)
        {
            this.catalogue = catalogue;
            this.mySqlContext = mySqlContext;
        }

        public int Run(NinjaCatalogueItem[] catalogue)
        {
            this.catalogue = catalogue;
            this.ClearMySqlRecords();
            this.LoadToMySql();
            return this.catalogue.Length;
        }

        public int Run(string filePath)
        {
            this.ReadJsonFile(filePath);
            this.ClearMySqlRecords();
            this.LoadToMySql();
            return this.catalogue.Length;
        }

        private readonly NinjaCatalogueModel mySqlContext;
        private readonly NinjaCatalogueJsonParser parser;
        private NinjaCatalogueItem[] catalogue;

        private void ClearMySqlRecords()
        {
            var prevNinjas = this.mySqlContext.Ninjafactorycatalogueitems.Where(n => n.IsDeleted.HasValue == true && n.IsDeleted.Value == false);
            foreach (var item in prevNinjas)
            {
                item.IsDeleted = true;
            }
        }

        private void LoadToMySql()
        {
            for (int i = 0; i < this.catalogue.Length; i++)
            {
                this.mySqlContext.Add(new Ninjafactorycatalogueitem()
                {
                    IsDeleted = false,
                    NinjaName = catalogue[i].Name,
                    KillCount = catalogue[i].KillCount,
                    Weapon = catalogue[i].Weapon,
                    Price = (double)catalogue[i].Price,
                    Speciality = catalogue[i].SpecialtyName,
                    JobsCount = catalogue[i].JobsCount,
                    SuccessfulJobsCount = catalogue[i].SuccessfulJobsCount,
                    SuccessRate = catalogue[i].SuccessRate
                });
            }
            this.mySqlContext.SaveChanges();
        }

        private void ReadJsonFile(string filePath)
        {
            this.catalogue = this.parser.Parse(filePath);
        }
    }
}