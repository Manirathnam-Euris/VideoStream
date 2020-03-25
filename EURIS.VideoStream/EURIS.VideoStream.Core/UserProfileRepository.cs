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
    public class UserProfileRepository : IUserProfile
    {
        private VideoStreamContext db;
        private DbSet<UserProfile> dbSet;

        public UserProfileRepository()
        {
            db = new VideoStreamContext();
            dbSet = db.Set<UserProfile>();
        }

        public IEnumerable<UserProfile> GetAllUserProfiles()
        {
            return dbSet.ToList();
        }

        public UserProfile GetUserProfileById(Guid ProfileId)
        {
            return dbSet.Find(ProfileId);
        }

        public void InsertUserProfile(UserProfile Uprofile)
        {
            dbSet.Add(Uprofile);
        }

        public void UpdateUserProfile(UserProfile Userprofile)
        {
            db.Entry(Userprofile).State = EntityState.Modified;
        }

        public void DeleteUserProfile(Guid ProfileId)
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
