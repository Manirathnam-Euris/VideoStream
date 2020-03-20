using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class UserAccountManager
    {
        private UserAccountRepository _UserAccountRep = new UserAccountRepository();
        public IEnumerable<UserAccount> GetAllUserAccounts()
        {
            return _UserAccountRep.GetAllUserAccounts().ToList();
        }

        public UserAccount GetUserAccount(Guid userId)
        {
            try
            {
                if(userId == Guid.Empty || userId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var userExists = _UserAccountRep.GetUserAccountById(userId);
                if(userExists == null)
                {
                    throw new Exception("User not Exists with this :" + userId);
                }
                return userExists;
            }
            catch
            {
                throw new Exception("Something went wrong");
            }
        }
        public void AddUserAccount(UserAccount user)
        {
            try
            {
                var userExists = _UserAccountRep.GetUserAccountById(user.UserId);
                if(userExists != null)
                {
                    throw new Exception("User Already exists");
                }
                _UserAccountRep.InsertUserAccount(user);
                _UserAccountRep.SaveUserAccount();
            }
            catch
            {
                throw new Exception("Something went wrong");
            }
        }

        public void UpdateUserAccount(UserAccount user)
        {
            try
            {
                var userExists = _UserAccountRep.GetUserAccountById(user.UserId);
                if(userExists == null)
                {
                    throw new Exception("User not exists please create user");
                }
                _UserAccountRep.UpdateUserAccount(user);
                _UserAccountRep.SaveUserAccount();
            }
            catch
            {
                throw new Exception("Something went wrong");
            }
        }

        public bool DeleteUserAccount(Guid userId)
        {
            try
            {
                if (userId == Guid.Empty)
                {
                    throw new Exception("Provide valid Id");
                }
                var user = _UserAccountRep.GetUserAccountById(userId);
                if(user == null)
                {
                    throw new Exception("User not found with this Id");
                }
                _UserAccountRep.DeleteUserAccount(userId);
                _UserAccountRep.SaveUserAccount();
                return true;
            }
            catch
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}
