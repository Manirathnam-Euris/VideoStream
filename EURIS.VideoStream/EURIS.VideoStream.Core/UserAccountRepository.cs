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
    public class UserAccountRepository : IUserAccount
    {
        private VideoStreamContext db;
        private DbSet<UserAccount> dbSet;

        public UserAccountRepository()
        {
            db = new VideoStreamContext();
            dbSet = db.Set<UserAccount>();
        }

        public IEnumerable<UserAccount> GetAllUserAccounts()
        {
            return dbSet.ToList();
        }

        public UserAccount GetUserAccountById(Guid UserId)
        {
            return dbSet.Find(UserId);
        }

        public void InsertUserAccount(UserAccount User)
        {
            dbSet.Add(User);
        }

        public void UpdateUserAccount(UserAccount User)
        {
            db.Entry(User).State = EntityState.Modified;
        }

        public void DeleteUserAccount(Guid UserId)
        {
            UserAccount User = dbSet.Find(UserId);
            dbSet.Remove(User);
        }

        public void SaveUserAccount()
        {
            db.SaveChanges();
        }
    }
}
