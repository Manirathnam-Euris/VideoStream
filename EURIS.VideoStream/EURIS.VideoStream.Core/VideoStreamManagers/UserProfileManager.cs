using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class UserProfileManager
    {
        private UserProfileRepository _UserProfileRep = new UserProfileRepository();
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
                var userProfiles = _UserProfileRep.GetAllUserProfiles().Where(u => u.UserAccount.UserId == userId);
                if(userProfiles == null)
                {
                    throw new Exception("User Profiles are not present with this userId:" + userId);
                }
                return userProfiles.ToList();
            }
            catch
            {
                throw new Exception("Something went wrong"); 
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
                var profileCount = _UserProfileRep.GetAllUserProfiles().Where(u => u.UserAccount.UserId == userProfile.UserAccount.UserId).Count();
                if(profileCount > 5)
                {
                    throw new Exception("Sorry max of 5 Profiles with this user is already exists");
                }
                _UserProfileRep.InsertUserProfile(userProfile);
                _UserProfileRep.SaveUserProfile();
            }
            catch
            {
                throw new Exception("Something went wrong");
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
                _UserProfileRep.UpdateUserProfile(userProfile);
                _UserProfileRep.SaveUserProfile();
            }
            catch
            {
                throw new Exception("Something went wrong");
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
                _UserProfileRep.DeleteUserProfile(profileId);
                _UserProfileRep.SaveUserProfile();
            }
            catch
            {
                throw new Exception("Something went wrong for Profile deletion");
            }
        }
    }
}
