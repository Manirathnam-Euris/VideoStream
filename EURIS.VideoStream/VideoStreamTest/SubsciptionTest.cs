using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    /// <summary>
    /// Summary description for SubsciptionTest
    /// </summary>
    [TestClass]
    public class SubsciptionTest
    {
        //private Subscription _subscription = new Subscription();
        private SubscriptionManager _subManager = new SubscriptionManager();

        [TestMethod]
        public void SubscriptionAddTest()
        {
            var subscription = new Subscription()
            {
                SubscriptionId = Guid.NewGuid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(90),
                Price = 1000
            };

            _subManager.AddSubscription(subscription);
        }

        [TestMethod]
        public void SubscriptionUpdate_WhenCalled_CheckUpdateIsDone()
        {
            var subscriptionId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011");
            var subscription = new Subscription()
            {
                SubscriptionId = subscriptionId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(90),
                Price = 1000
            };
            _subManager.UpdateSubscription(subscription);
        }

        [TestMethod]
        public void GetAllSubscriptions_WhenCalled_CheckSubscriptionIsNotNull()
        {
            var subscriptions = _subManager.GetAllSubscriptions();
            Assert.IsNotNull(subscriptions);
        }

        [TestMethod]
        public void SuscriptionDelete_WhenCalled_CheckSubscriptionIsDeleted()
        {
            var subscriptionId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011");
            _subManager.DeleteSubscription(subscriptionId);
        }
    }
}
