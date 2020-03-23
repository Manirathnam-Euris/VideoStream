using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class UserAccountTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestUser()
        {
            UserAccountManager _User = new UserAccountManager();
            UserAccount Ua = new UserAccount();
            Ua.Address = "Antilla, mumbai, 22";
            Ua.ContactNumber = unchecked((int)9397038055);
            Ua.CreditCardNumber = "689409822335-5622-09";
            Ua.Name = "Lyt theesuko";
            Ua.SurName = "Edhokati";
            Ua.UserId = new Guid("C7890CBD-66C8-4F35-89D5-FAF8BF0944C4");
            Ua.Email = "letsee@mail.com";
            Ua.DateOfBirth = "01-01-1994";
            _User.AddUserAccount(Ua);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetUserById()
        {
            UserAccountManager _User = new UserAccountManager();
            var userId = new Guid("50529C8D-7081-43E0-BEB9-0FF9B8972966");
            _User.GetUserAccount(userId);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetUsers()
        {
            UserAccountManager _User = new UserAccountManager();
            _User.GetAllUserAccounts();
            Assert.IsTrue(true);
        }
    }
}
