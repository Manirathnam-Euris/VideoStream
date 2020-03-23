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
        private UserProfile _Up = new UserProfile();
        private UserAccount _UAccount = new UserAccount();
        private UserAccountManager _Um = new UserAccountManager();
        private UserProfileManager _profile = new UserProfileManager();

        [TestMethod()]
        public void AaddUserProfileTest()
        {
            _Up.ProfileId = Guid.NewGuid();
            _Up.ProfileName = "Uprofile";
            _Up.UserAccount.UserId
            //_Up.UserAccount = _Um.GetUserAccount(new Guid("C7890CBD-66C8-4F35-89D5-FAF8BF0944C4"));
            _profile.AddUserProfile(_Up);
   
            //Assert.IsTrue(true);
        }
    }
}
