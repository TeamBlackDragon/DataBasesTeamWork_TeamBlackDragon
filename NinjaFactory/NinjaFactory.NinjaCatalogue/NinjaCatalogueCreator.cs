namespace NinjaFactory.NinjaCatalogue
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Json;
    using NinjaFactory.DataBase;

    public class NinjaCatalogueCreator
    {
        public void CreateJson(INinjaFactoryData db, string filePath)
        {
            var ninjaItems = db.Ninjas
                .Where(n => n.Jobs.Where(j => j.IsSuccessfull.HasValue == false).Count() == 0)
                               .Select(n => new NinjaCatalogueItem()
                                      {
                                          NinjaId = n.Id,
                                          Name = n.Name,
                                          KillCount = n.KillCount,
                                          Weapon = n.WeaponOfChoice,
                                          Price = n.MinimalPersonalPrice + n.Speciality.MinimalCompanyPrice,
                                          SpecialtyName = n.Speciality.Name,
                                          JobsCount = n.Jobs.Count(),
                                          SuccessfullJobsCount = n.Jobs.Where(j => j.IsSuccessfull.HasValue == true && j.IsSuccessfull.Value == true).Count(),
                                          SuccessRate = 0
                                      })
                                      .ToList();

            foreach (var item in ninjaItems)
            {
                if (item.SuccessfullJobsCount > 0)
                {
                    item.SuccessRate = (double)item.SuccessfullJobsCount / item.JobsCount;
                }
            }
            
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(NinjaCatalogueItem[]));

            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            jsonSerializer.WriteObject(fileStream, ninjaItems.ToArray());
        }
    }
}
