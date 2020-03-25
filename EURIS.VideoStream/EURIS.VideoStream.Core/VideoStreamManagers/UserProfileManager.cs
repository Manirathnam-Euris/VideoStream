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
        private UserProfileRepository _UserProfileRep = new UserProfileRepository();
        private SubscriptionTypeManager _subscriptionTypeManager = new SubscriptionTypeManager();
        private StreamDataManager _streamDataManager = new StreamDataManager();
        private SavedMediaManager _savedMediaManager = new SavedMediaManager();
        private FavouritesManager _favouritesManager = new FavouritesManager();
        private UserAccountManager _userAccountManager = new UserAccountManager();

        public IEnumerable<UserProfile> GetAllUserProfiles()
        {
            return _UserProfileRep.GetAllUserProfiles().ToList();
        }

        public IEnumerable<UserProfile> GetUserProfiles(Guid userId)
        {
            try
            {
                if(userId == Guid.Empty || userId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var userProfiles = _UserProfileRep.GetAllUserProfiles().Where(u => u.UserId == userId);
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
                var profile = _UserProfileRep.GetUserProfileById(profileId);
                if(profile == null)
                {
                    throw new Exception("No profile with the provided Id: " + profileId);
                }
                //profile.StreamDatas = streamDatas;
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
                var profileExists = _UserProfileRep.GetUserProfileById(userProfile.ProfileId);
                if(profileExists != null)
                {
                    throw new Exception("This Profile is already exists");
                }
                var profileCount = _UserProfileRep.GetAllUserProfiles().Where(u => u.UserId == userProfile.UserId).Count();
                if (profileCount >= 5)
                {
                    throw new Exception("Sorry max of 5 Profiles with this user is already exists");
                }
                using (var dbcontext = new VideoStreamContext())
                {
                    _UserProfileRep.InsertUserProfile(userProfile);
                    _UserProfileRep.SaveUserProfile();
                } 
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
                var profileExists = _UserProfileRep.GetUserProfileById(userProfile.ProfileId);
                if(profileExists == null)
                {
                    throw new Exception("This profile is not exists");
                }
                profileExists.ProfileId = userProfile.ProfileId;
                profileExists.ProfileName = userProfile.ProfileName;
                profileExists.UserId = userProfile.UserId;
                profileExists.SubscriptionTypeId = userProfile.SubscriptionTypeId;

                _UserProfileRep.UpdateUserProfile(profileExists);
                _UserProfileRep.SaveUserProfile();
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
                var profileExists = _UserProfileRep.GetUserProfileById(profileId);
                if(profileExists == null)
                {
                    throw new Exception("This profile is not Exists for deletion");
                }
                _UserProfileRep.DeleteUserProfile(profileExists.ProfileId);
                _UserProfileRep.SaveUserProfile();
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
                SubscriptionType = _subscriptionTypeManager.GetSubscriptionType(userProfile.SubscriptionTypeId),
                UserAccount = _userAccountManager.GetUserAccount(userProfile.UserId),
                StreamDatas = _streamDataManager.GetUserStreamData(userProfile.ProfileId).ToList(),
                Favourites = _favouritesManager.GetProfileFavourites(userProfile.ProfileId).ToList(),
                SavedMedias = _savedMediaManager.GetProfileSavedMedia(userProfile.ProfileId).ToList()
            };
            return modal;
        }
    }
}
