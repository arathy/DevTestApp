using System;
using DevTestApp;

namespace DevTest.DAL
{
   public class UnitOfWork : IDisposable
   {
      private DevTestApp.DevTestDBEntities context = new DevTestApp.DevTestDBEntities();
      private GenericRepository<DevTestApp.DevTest> voteRepository;

      public GenericRepository<DevTestApp.DevTest> VoteRepository
      {
         get
         {

            if (this.voteRepository == null)
            {
               this.voteRepository = new GenericRepository<DevTestApp.DevTest>(context);
            }
            return voteRepository;
         }
      }

      public void Save()
      {
         context.SaveChanges();
      }

      private bool disposed = false;

      protected virtual void Dispose(bool disposing)
      {
         if (!this.disposed)
         {
            if (disposing)
            {
               context.Dispose();
            }
         }
         this.disposed = true;
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
   }
}
