namespace DataAccess.Generic
{
    using Entities.DataContext;
    using System;

    public interface IUnitOfWork: IDisposable
    {
        WebApiDbContext Context { get; }

        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public WebApiDbContext Context { get; }

        public UnitOfWork(WebApiDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}