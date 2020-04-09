using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class UserAccountTest
    {
        // private UserAccount _userAccount = new UserAccount();
        private UserAccountManager _accountManager = new UserAccountManager();

        [TestMethod]
        public void AddUserAccount_ToAdd_CheckIfTheUserIsAdded()
        {
            var userId = Guid.NewGuid();
            var userAccount = new UserAccount() {
               Address = "Vijayawada, poranki, India",
               ContactNumber = unchecked((int)9397038055),
               CreditCardNumber = "799409822335-6622-90",
               Name = "Saroja",
               SurName = "Yesko",
               UserId = userId,
               SubscriptionId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011"),
               Email = "yeskosaroja@mail.com",
               DateOfBirth = "01-01-1990"
            };
            
            _accountManager.AddUserAccount(userAccount);
        }

        [TestMethod]
        public void GetUserAccount_WhenCalled_CheckIfTheUserIsNotNull()
        {
            // Arrange
            var accountGuid = new Guid("CAECEFD5-0131-4912-BC42-CA5ADFBB96EE");

            // Act 
            var user =_accountManager.GetUserAccount(accountGuid);

            // Assert
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void GetAllUserAccounts_WhenCalled_CheckIfTheUsersAreNotNull()
        {
            var users = _accountManager.GetAllUserAccounts();

            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void UpdateUserAccount_ToUpdate_CheckIfItIsUpdated()
        {
            var userId = new Guid("01B6020C-382B-4D44-8DA3-7513FB785C1F");

            var userAccount = new UserAccount()
            {
                Address = "Royal palace, 94,Jaipur",
                ContactNumber = unchecked((int)9397038055),
                CreditCardNumber = "799409822335-6622-90",
                Name = "Rani Padmavat",
                SurName = "Rajput",
                UserId = userId,
                SubscriptionId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011"),
                Email = "mevadkings@mail.com",
                DateOfBirth = "01-01-1990"
            };
            
            _accountManager.UpdateUserAccount(userAccount);
        }

        [TestMethod]
        public void DeleteUserAccount_WhenCalled_CheckIsDeleted()
        {
            var isDeleted = _accountManager.DeleteUserAccount(new Guid("01B6020C-382B-4D44-8DA3-7513FB785C1F"));
            Assert.IsTrue(isDeleted);
        }
    }
}
