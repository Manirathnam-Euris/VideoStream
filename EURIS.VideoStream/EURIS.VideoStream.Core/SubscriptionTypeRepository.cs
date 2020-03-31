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
    public class SubscriptionTypeRepository : ISubscriptionType
    {
        private VideoStreamContext db;
        private DbSet<SubscriptionType> dbSet;

        public SubscriptionTypeRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<SubscriptionType>();
        }

        public IEnumerable<SubscriptionType> GetAllSubscripitonTypes()
        {
            return dbSet.ToList();
        }

        public SubscriptionType GetSubscriptionTypeById(Guid SubscriptionTypeId)
        {
            return dbSet.Find(SubscriptionTypeId);
        }

        public void InsertSubscripitonType(SubscriptionType SubscriptionType)
        {
            dbSet.Add(SubscriptionType);
        }

        public void UpdateSubscriptionType(SubscriptionType SubscriptionType)
        {
            db.Entry(SubscriptionType).State = EntityState.Modified;
        }

        public void DeleteSubscriptionType(Guid SubscriptionTypeId)
        {
            SubscriptionType SData = dbSet.Find(SubscriptionTypeId);
            dbSet.Remove(SData);
        }

        public void SaveSubscriptionType()
        {
            db.SaveChanges();
        }
    }
}
