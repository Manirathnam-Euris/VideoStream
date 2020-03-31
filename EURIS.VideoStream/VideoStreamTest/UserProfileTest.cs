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
        public void AddUserProfileTest()
        {
            _userProfile.ProfileId = Guid.NewGuid();
            _userProfile.ProfileName = "Roberto";
            _userProfile.UserId = new Guid("CAECEFD5-0131-4912-BC42-CA5ADFBB96EE");
            _userProfile.SubscriptionTypeId = new Guid("CD9524FE-B8C9-48CD-9780-624657E51217");
            _profileManager.AddUserProfile(_userProfile);
   
            //Assert.IsTrue(true);
        }

        [TestMethod()]
        public void UpdateProfileTest()
        {
            _userProfile.ProfileId = new Guid("73C4475E-9DF1-4F1C-894D-8DEED43462FC");
            _userProfile.ProfileName = "Gallileo";
            _userProfile.UserId = new Guid("CAECEFD5-0131-4912-BC42-CA5ADFBB96EE");
            _userProfile.SubscriptionTypeId = new Guid("CD9524FE-B8C9-48CD-9780-624657E51217");
            _profileManager.UpdateUserProfile(_userProfile);
        }

        [TestMethod()]
        public void GetUserProfiles()
        {
           var userProfiles = _profileManager.GetUserProfiles(new Guid("2305115C-E4AA-4069-988B-E7606E5F4147"));
        }

        [TestMethod()]
        public void GetProfileTest()
        {
            var profile = _profileManager.GetUserProfile(new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492"));
        }

        [TestMethod()]
        public void DeleteProfileTest()
        {
            _profileManager.DeleteUserProfile(new Guid("E1B90689-3E0C-4955-B6EE-07EF6D8F4826"));
        }
    }
}
