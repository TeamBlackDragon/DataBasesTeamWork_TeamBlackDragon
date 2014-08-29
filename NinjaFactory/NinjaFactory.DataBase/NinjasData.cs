namespace NinjaFactory.DataBase
{
    using System;
    using System.Collections.Generic;
    using NinjaFactory.DataBase.Repositories;

    public class NinjasData : INinjaFactoryData
    {
        public NinjasData()
            : this(new TeamworkBlackDragonEntities())
        {
        }

        public NinjasData(TeamworkBlackDragonEntities context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Client> Clients
        {
            get
            {
                return this.GetRepository<Client>();
            }
        }

        public IGenericRepository<Job> Jobs
        {
            get
            {
                return this.GetRepository<Job>();
            }
        }

        public IGenericRepository<Ninja> Ninjas
        {
            get
            {
                return this.GetRepository<Ninja>();
            }
        }

        public IGenericRepository<Speciality> Specialities
        {
            get
            {
                return this.GetRepository<Speciality>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private TeamworkBlackDragonEntities context;
        private IDictionary<Type, object> repositories;

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}