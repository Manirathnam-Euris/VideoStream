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
        //private UserAccountRepository _UserAccountRep = new UserAccountRepository();
        UnitOfWork _unitOfWork = new UnitOfWork(new VideoStreamContext());
        public IEnumerable<UserAccount> GetAllUserAccounts()
        {
            //var users = _UserAccountRep.GetAllUserAccounts();
            var users = _unitOfWork.UserAccountRep.GetAllUserAccounts();
            var userList = new List<UserAccount>();

            foreach (var user in users)
            {
                userList.Add(MapUserAccount(user));
            }
            return userList;
        }

        public UserAccount GetUserAccount(Guid userId)
        {
            try
            {
                if(userId == Guid.Empty || userId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                //var userExists = _UserAccountRep.GetUserAccountById(userId);
                var userExists = _unitOfWork.UserAccountRep.GetUserAccountById(userId);
                if(userExists == null)
                {
                    throw new Exception("User not Exists with this :" + userId);
                }
                return MapUserAccount(userExists);
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
                
                //var userExists = _UserAccountRep.GetUserAccountById(user.UserId);
                var userExists = _unitOfWork.UserAccountRep.GetUserAccountById(user.UserId);
                if (userExists != null)
                {
                    throw new Exception("User Already exists");
                }
                _unitOfWork.UserAccountRep.InsertUserAccount(user);
                //_UserAccountRep.InsertUserAccount(user);
                //_UserAccountRep.SaveUserAccount();
                _unitOfWork.Save();
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
                //var userExists = _UserAccountRep.GetUserAccountById(user.UserId);
                var userExists = _unitOfWork.UserAccountRep.GetUserAccountById(user.UserId);
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

                //_UserAccountRep.UpdateUserAccount(userExists);
                //_UserAccountRep.SaveUserAccount();
                _unitOfWork.UserAccountRep.UpdateUserAccount(userExists);
                _unitOfWork.Save();
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
                //var user = _UserAccountRep.GetUserAccountById(userId);
                var user = _unitOfWork.UserAccountRep.GetUserAccountById(userId);
                if(user == null)
                {
                    throw new Exception("User not found with this Id");
                }
                //_UserAccountRep.DeleteUserAccount(user.UserId);
                //_UserAccountRep.SaveUserAccount();
                _unitOfWork.UserAccountRep.DeleteUserAccount(user.UserId);
                _unitOfWork.Save();
                return true;
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal UserAccount MapUserAccount(UserAccount user)
        {
            var _userProfileRep = new UserProfileRepository(new VideoStreamContext());

            return new UserAccount()
            {
                UserId = user.UserId,
                Name = user.Name,
                SurName = user.SurName,
                Address = user.Address,
                Email = user.Email,
                ContactNumber = user.ContactNumber,
                DateOfBirth = user.DateOfBirth,
                CreditCardNumber = user.CreditCardNumber,
                SubscriptionId = user.SubscriptionId,
                UserProfiles = _userProfileRep.GetAllUserProfiles().Where(u => u.UserId == user.UserId).ToList()
            };
        }
    }
}
