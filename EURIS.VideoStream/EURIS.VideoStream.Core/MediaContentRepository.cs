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
    public class MediaContentRepository : IRepository<MediaContent>
    {
        private VideoStreamContext db;
        private DbSet<MediaContent> dbSet;

        public MediaContentRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<MediaContent>();
        }

        public IEnumerable<MediaContent> GetAll()
        {
            return dbSet.ToList();
        }

        public MediaContent GetById(Guid MediaId)
        {
            return dbSet.Find(MediaId);
        }

        public void Insert(MediaContent Media)
        {
            dbSet.Add(Media);
        }

        public void Update(MediaContent Media)
        {
            db.Entry(Media).State = EntityState.Modified;
        }

        public void Delete(Guid MediaId)
        {
            MediaContent Media = dbSet.Find(MediaId);
            dbSet.Remove(Media);
        }

        public void SaveMediaContent()
        {
            db.SaveChanges();
        }
    }
}
