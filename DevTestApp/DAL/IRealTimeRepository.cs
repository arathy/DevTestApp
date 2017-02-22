using System;
using System.Collections.Generic;
using DevTestApp;
namespace DevTest.DAL
{
    public interface IRealTimeVoteRepository : IDisposable
    {
        IEnumerable<DevTestApp.DevTest> GetVotes();
        DevTestApp.DevTest GetVoteById(int voteId);
        void InsertVote(DevTestApp.DevTest vote);
        void DeleteVote(int voteId);
        void UpdateVote(DevTestApp.DevTest vote);
        void Save();
    }
}
