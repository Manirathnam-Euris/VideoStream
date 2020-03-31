using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class UserProfileManager
    {
        UnitOfWork _unitOfWork = new UnitOfWork(new VideoStreamContext());

        public IEnumerable<UserProfile> GetAllUserProfiles()
        {
            return _unitOfWork.UserProfileRep.GetAllUserProfiles().ToList();
        }

        public IEnumerable<UserProfile> GetUserProfiles(Guid userId)
        {
            try
            {
                if(userId == Guid.Empty || userId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var userProfiles = _unitOfWork.UserProfileRep.GetAllUserProfiles().Where(u => u.UserId == userId);
                if(userProfiles == null)
                {
                    throw new Exception("User Profiles are not present with this userId:" + userId);
                }
                return userProfiles.ToList().Select(u => MapUserProfile(u)).ToList();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message); 
            }
        }

        public UserProfile GetUserProfile(Guid profileId)
        {
            try
            {
                if(profileId == Guid.Empty || profileId == null)
                {
                    throw new Exception("Provide Valid Id");
                }
                var profile = _unitOfWork.UserProfileRep.GetUserProfileById(profileId);
                if(profile == null)
                {
                    throw new Exception("No profile with the provided Id: " + profileId);
                }
                return MapUserProfile(profile);
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddUserProfile(UserProfile userProfile)
        {
            try
            {
                var profileExists = _unitOfWork.UserProfileRep.GetUserProfileById(userProfile.ProfileId);
                if (profileExists != null)
                {
                    throw new Exception("This Profile is already exists");
                }
                var profileCount = _unitOfWork.UserProfileRep.GetAllUserProfiles().Where(u => u.UserId == userProfile.UserId).Count();
                if (profileCount >= 5)
                {
                    throw new Exception("Sorry max of 5 Profiles with this user is already exists");
                }
                _unitOfWork.UserProfileRep.InsertUserProfile(userProfile);
                _unitOfWork.Save();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            try
            {
                var profileExists = _unitOfWork.UserProfileRep.GetUserProfileById(userProfile.ProfileId);
                if (profileExists == null)
                {
                    throw new Exception("This profile is not exists");
                }
                profileExists.ProfileId = userProfile.ProfileId;
                profileExists.ProfileName = userProfile.ProfileName;
                profileExists.UserId = userProfile.UserId;
                profileExists.SubscriptionTypeId = userProfile.SubscriptionTypeId;

                _unitOfWork.UserProfileRep.UpdateUserProfile(profileExists);
                _unitOfWork.Save();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUserProfile(Guid profileId)
        {
            try
            {
                if(profileId == Guid.Empty || profileId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var profileExists = _unitOfWork.UserProfileRep.GetUserProfileById(profileId);
                if (profileExists == null)
                {
                    throw new Exception("This profile is not Exists for deletion");
                }
                _unitOfWork.UserProfileRep.DeleteUserProfile(profileExists.ProfileId);
                _unitOfWork.Save();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal UserProfile MapUserProfile(UserProfile userProfile)
        {
            var modal = new UserProfile()
            {
                ProfileId = userProfile.ProfileId,
                ProfileName = userProfile.ProfileName,
                UserId = userProfile.UserId,
                SubscriptionTypeId = userProfile.SubscriptionTypeId,
                SubscriptionType = _unitOfWork.SubscriptionTypeRep.GetSubscriptionTypeById(userProfile.SubscriptionTypeId),
                UserAccount = _unitOfWork.UserAccountRep.GetUserAccountById(userProfile.UserId),
                StreamDatas = _unitOfWork.StreamRep.GetAllStreamData().Where(s => s.UserProfileId == userProfile.ProfileId).ToList(),
                Favourites = _unitOfWork.FavRep.GetAllFavourites().Where(f => f.UserProfileId == userProfile.ProfileId).ToList(),
                SavedMedias = _unitOfWork.SavedRep.GetAllSavedMedia().Where(s => s.UserProfileId == userProfile.UserId).ToList()
            };
            return modal;
        }
    }
}
