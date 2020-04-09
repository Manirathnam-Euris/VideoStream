using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class UserProfileTest
    {
        private UserProfile _userProfile = new UserProfile();
        private UserProfileManager _profileManager = new UserProfileManager();

        [TestMethod()]
        public void AddUserProfile_WhenCalled_CheckIfItIsAdded()
        {
            var profileId = Guid.NewGuid();
            var userProfile = new UserProfile()
            {
                ProfileId = profileId,
                ProfileName = "Roberto",
                UserId = new Guid("CAECEFD5-0131-4912-BC42-CA5ADFBB96EE"),
                SubscriptionTypeId = new Guid("CD9524FE-B8C9-48CD-9780-624657E51217")
            };

            _profileManager.AddUserProfile(userProfile);
   
            //Assert.IsTrue(true);
        }

        [TestMethod()]
        public void UpdateProfile_ToUpdate_CheckIfUpdate()
        {
            var profileId = new Guid("73C4475E-9DF1-4F1C-894D-8DEED43462FC");
            var userProfile = new UserProfile()
            {
                ProfileId = profileId,
                ProfileName = "Gallileo",
                UserId = new Guid("CAECEFD5-0131-4912-BC42-CA5ADFBB96EE"),
                SubscriptionTypeId = new Guid("CD9524FE-B8C9-48CD-9780-624657E51217")
            };

            _profileManager.UpdateUserProfile(userProfile);
        }

        [TestMethod()]
        public void GetUserProfiles_WhenCalled_CheckIfUsersNotNull()
        {
            var userId = new Guid("2305115C-E4AA-4069-988B-E7606E5F4147");

            var userProfiles = _profileManager.GetUserProfiles(userId);

            Assert.IsNotNull(userProfiles);
        }

        [TestMethod()]
        public void GetProfile_WhenCalled_CheckIfProfileNotNull()
        {
            var profileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            var profile = _profileManager.GetUserProfile(profileId);
            Assert.IsNotNull(profile);
        }

        [TestMethod()]
        public void DeleteProfile_WhenCalled_CheckIfProfileIsDeleted()
        {
            var profileId = new Guid("E1B90689-3E0C-4955-B6EE-07EF6D8F4826");
            _profileManager.DeleteUserProfile(profileId);
        }
    }
}
