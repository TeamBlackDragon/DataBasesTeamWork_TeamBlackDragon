﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.

namespace NinjaFactory.DataBase
{
    using System;
    using System.Data.Entity;

    public partial class TeamworkBlackDragonEntities : DbContext, ITeamworkBlackDragonDBContext
    {
        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}