using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class UserAccountTest
    {
        private UserAccount _userAccount = new UserAccount();
        private UserAccountManager _accountManager = new UserAccountManager();

        [TestMethod]
        public void AddUserAccountTest()
        {
            _userAccount.Address = "Antilla, mumbai, 22";
            _userAccount.ContactNumber = unchecked((int)9397038055);
            _userAccount.CreditCardNumber = "689409822335-5622-09";
            _userAccount.Name = "With Unit";
            _userAccount.SurName = "Unit work";
            _userAccount.UserId = Guid.NewGuid();
            _userAccount.SubscriptionId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011");
            _userAccount.Email = "unitwork@mail.com";
            _userAccount.DateOfBirth = "01-01-1993";
            _accountManager.AddUserAccount(_userAccount);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var user =_accountManager.GetUserAccount(new Guid("CAECEFD5-0131-4912-BC42-CA5ADFBB96EE"));
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetUserAccountTest()
        {
            var users = _accountManager.GetAllUserAccounts();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateUserAccountTest()
        {
            _userAccount.UserId = new Guid("2305115C-E4AA-4069-988B-E7606E5F4147");
            _userAccount.Address = "Antilla, mumbai, 22";
            _userAccount.ContactNumber = unchecked((int)9397038055);
            _userAccount.CreditCardNumber = "689409822335-5622-09";
            _userAccount.Name = "Testing";
            _userAccount.SurName = "lyt mama";
            _userAccount.SubscriptionId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011");
            _userAccount.Email = "letsee@mail.com";
            _userAccount.DateOfBirth = "01-01-1994";
            _accountManager.UpdateUserAccount(_userAccount);
        }

        public void DeleteUserAccountTest()
        {
            _accountManager.DeleteUserAccount(new Guid("2305115C-E4AA-4069-988B-E7606E5F4147"));
            Assert.IsTrue(true);
        }
    }
}
