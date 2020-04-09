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
    public class SubscriptionTypeRepository : IRepository<SubscriptionType>
    {
        // Test comment
        private VideoStreamContext db;
        private DbSet<SubscriptionType> dbSet;

        public SubscriptionTypeRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<SubscriptionType>();
        }

        public IEnumerable<SubscriptionType> GetAll()
        {
            return dbSet.ToList();
        }

        public SubscriptionType GetById(Guid SubscriptionTypeId)
        {
            return dbSet.Find(SubscriptionTypeId);
        }

        public void Insert(SubscriptionType SubscriptionType)
        {
            dbSet.Add(SubscriptionType);
        }

        public void Update(SubscriptionType SubscriptionType)
        {
            db.Entry(SubscriptionType).State = EntityState.Modified;
        }

        public void Delete(Guid SubscriptionTypeId)
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
