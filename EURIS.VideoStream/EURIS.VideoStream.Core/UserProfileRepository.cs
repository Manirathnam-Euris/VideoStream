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
    public class UserProfileRepository : IRepository<UserProfile>
    {
        private VideoStreamContext db;
        private DbSet<UserProfile> dbSet;

        public UserProfileRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<UserProfile>();
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return dbSet.ToList();
        }

        public UserProfile GetById(Guid ProfileId)
        {
            return dbSet.Find(ProfileId);
        }

        public void Insert(UserProfile Uprofile)
        {
            dbSet.Add(Uprofile);
        }

        public void Update(UserProfile Userprofile)
        {
            db.Entry(Userprofile).State = EntityState.Modified;
        }

        public void Delete(Guid ProfileId)
        {
            UserProfile UProfile = dbSet.Find(ProfileId);
            dbSet.Remove(UProfile);
        }

        public void SaveUserProfile()
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
