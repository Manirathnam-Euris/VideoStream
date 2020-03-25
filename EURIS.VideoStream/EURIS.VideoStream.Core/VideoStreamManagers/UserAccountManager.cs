using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
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
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
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
                userExists.Address = user.Address;
                userExists.ContactNumber = user.ContactNumber;
                userExists.CreditCardNumber = user.CreditCardNumber;
                userExists.DateOfBirth = user.DateOfBirth;
                userExists.Email = user.Email;
                userExists.SurName = user.SurName;
                userExists.Name = user.Name;

                _UserAccountRep.UpdateUserAccount(userExists);
                _UserAccountRep.SaveUserAccount();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
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
                _UserAccountRep.DeleteUserAccount(user.UserId);
                _UserAccountRep.SaveUserAccount();
                return true;
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
