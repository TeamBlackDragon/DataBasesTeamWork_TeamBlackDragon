using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace NinjaFactory.DataBase
{
    public interface ITeamworkBlackDragonEntities
    {
        DbSet<Client> Clients { get; set; }

        DbSet<Job> Jobs { get; set; }

        DbSet<Ninja> Ninjas { get; set; }

        DbSet<Speciality> Specialities { get; set; }
    }
}