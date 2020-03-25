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
        private Subscription _subscription = new Subscription();
        private SubscriptionManager _subManager = new SubscriptionManager();

        [TestMethod]
        public void SubscriptionAddTest()
        {
            _subscription.SubscriptionId = Guid.NewGuid();
            _subscription.StartDate = DateTime.Now;
            _subscription.EndDate = DateTime.Now.AddDays(90);
            _subscription.Price = 1000;

            _subManager.AddSubscription(_subscription);
        }
    }
}
