namespace NinjaFactory.DataBase
{
    using NinjaFactory.DataBase.Repositories;

    public interface INinjaFactoryData
    {
        IGenericRepository<Client> Clients { get; }

        IGenericRepository<Job> Jobs { get; }

        IGenericRepository<Ninja> Ninjas { get; }

        IGenericRepository<Speciality> Specialities { get; }

        void SaveChanges();
    }
}