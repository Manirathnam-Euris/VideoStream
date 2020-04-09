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
    public class StreamDataRepository : IRepository<StreamData>
    {
        private VideoStreamContext db;
        private DbSet<StreamData> dbSet;

        public StreamDataRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<StreamData>();
        }

        public IEnumerable<StreamData> GetAll()
        {
            return dbSet.ToList();
        }

        public StreamData GetById(Guid StreamId)
        {
            return dbSet.Find(StreamId);
        }

        public void Insert(StreamData StreamData)
        {
            dbSet.Add(StreamData);
        }

        public void Update(StreamData StreamData)
        {
            db.Entry(StreamData).State = EntityState.Modified;
        }

        public void Delete(Guid StreamId)
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
