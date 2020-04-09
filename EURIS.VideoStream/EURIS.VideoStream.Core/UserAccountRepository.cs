using EURIS.VideoStream.Entity;
using EURIS.VideoStream.Interfaces;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Core
{
    public class UserAccountRepository : IRepository<UserAccount>
    {
        private VideoStreamContext db;
        private DbSet<UserAccount> dbSet;

        public UserAccountRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<UserAccount>();
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return dbSet.ToList();
        }

        public UserAccount GetById(Guid UserId)
        {
            return dbSet.Find(UserId);
        }

        public void Insert(UserAccount User)
        {
            dbSet.Add(User);
        }

        public void Update(UserAccount User)
        {
            db.Entry(User).State = EntityState.Modified;
        }

        public void Delete(Guid UserId)
        {
            UserAccount User = dbSet.Find(UserId);
            dbSet.Remove(User);
        }

        public void SaveUserAccount()
        {
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }
    }
}
