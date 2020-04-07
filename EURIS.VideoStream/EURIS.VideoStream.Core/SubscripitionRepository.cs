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
    public class SubscripitionRepository : ISubscription
    {
        private VideoStreamContext db;
        private DbSet<Subscription> dbSet;

        public SubscripitionRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<Subscription>();
        }
        
        public IEnumerable<Subscription> GetAllSubscripitons()
        {
            return dbSet.ToList();
        }

        public Subscription GetSubscriptionById(Guid SubscriptionId)
        {
            return dbSet.Find(SubscriptionId);
        }

        public void InsertSubscripiton(Subscription Subscription)
        {
            dbSet.Add(Subscription);
        }

        public void UpdateSubscription(Subscription Subscription)
        {
            db.Entry(Subscription).State = EntityState.Modified;
        }

        public void DeleteSubscription(Guid SubscriptionId)
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
