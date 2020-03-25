using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class SubsctiptionTypeTest
    {
        private SubscriptionType _subscriptionType = new SubscriptionType();
        private SubscriptionTypeManager _subTypeManager = new SubscriptionTypeManager();

        [TestMethod]
        public void SubscriptionTypeInsertTest()
        {
            _subscriptionType.SubscriptionTypeId = Guid.NewGuid();
            _subscriptionType.Name = "For Old";
            _subscriptionType.Type = "Old-age";
            _subscriptionType.SubscriptionId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011");
            _subTypeManager.AddSubscriptionType(_subscriptionType);
        }
    }
}
