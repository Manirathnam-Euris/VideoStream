using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;
using EURIS.VideoStream.Interfaces;

namespace EURIS.VideoStream.Core
{
    public class StreamDataRepository : IStreamData
    {
        private VideoStreamContext db;
        private DbSet<StreamData> dbSet;

        public StreamDataRepository()
        {
            db = new VideoStreamContext();
            dbSet = db.Set<StreamData>();
        }

        public IEnumerable<StreamData> GetAllStreamData()
        {
            return dbSet.ToList();
        }

        public StreamData GetStreamDataById(Guid StreamId)
        {
            return dbSet.Find(StreamId);
        }

        public void InsertStreamData(StreamData StreamData)
        {
            dbSet.Add(StreamData);
        }

        public void UpdateStreamData(StreamData StreamData)
        {
            db.Entry(StreamData).State = EntityState.Modified;
        }

        public void DeleteStreamData(Guid StreamId)
        {
            StreamData SData = dbSet.Find(StreamId);
            dbSet.Remove(SData);
        }

        public void SaveStreamData()
        {
            db.SaveChanges();
        }
    }
}
