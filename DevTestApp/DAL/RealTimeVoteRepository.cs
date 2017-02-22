using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevTestApp;
using System.Data.Entity;

namespace DevTest.DAL
{
    public class RealTimeVoteRepository : IRealTimeVoteRepository, IDisposable
    {
        private DevTestDBEntities context;

        public RealTimeVoteRepository(DevTestDBEntities context)
        {
            this.context = context;
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

        public IEnumerable<DevTestApp.DevTest> GetVotes()
        {
            return context.DevTest.ToList();
        }

        public DevTestApp.DevTest GetVoteById(int voteId)
        {
            return context.DevTest.Find(voteId);
        }

        public void InsertVote(DevTestApp.DevTest vote)
        {
            context.DevTest.Add(vote);
        }

        public void DeleteVote(int voteId)
        {
            var vote = context.DevTest.Find(voteId);
            context.DevTest.Remove(vote);
        }

        public void UpdateVote(DevTestApp.DevTest vote)
        {
            context.Entry(vote).State = EntityState.Modified;
        }
    }
}
