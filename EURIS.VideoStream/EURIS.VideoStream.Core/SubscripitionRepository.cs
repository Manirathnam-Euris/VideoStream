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
    public class SubscripitionRepository : IRepository<Subscription>
    {
        private VideoStreamContext db;
        private DbSet<Subscription> dbSet;

        public SubscripitionRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<Subscription>();
        }
        
        public IEnumerable<Subscription> GetAll()
        {
            return dbSet.ToList();
        }

        public Subscription GetById(Guid SubscriptionId)
        {
            return dbSet.Find(SubscriptionId);
        }

        public void Insert(Subscription Subscription)
        {
            dbSet.Add(Subscription);
        }

        public void Update(Subscription Subscription)
        {
            db.Entry(Subscription).State = EntityState.Modified;
        }

        public void Delete(Guid SubscriptionId)
        {
            Subscription SData = dbSet.Find(SubscriptionId);
            dbSet.Remove(SData);
        }

        public void SaveSubscription()
        {
            db.SaveChanges();
        }
    }
}
