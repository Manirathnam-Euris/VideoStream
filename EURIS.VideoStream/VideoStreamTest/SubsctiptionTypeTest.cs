using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class SubsctiptionTypeTest
    {
        //private SubscriptionType _subscriptionType = new SubscriptionType();
        private SubscriptionTypeManager _subTypeManager = new SubscriptionTypeManager();

        [TestMethod]
        public void SubscriptionTypeAdd_WhenCalled_CheckIfAdded()
        {
            var subscripitonId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011");

            var subscriptionType = new SubscriptionType()
            {
                SubscriptionTypeId = Guid.NewGuid(),
                Name = "For Old",
                Type = "Old-age",
                SubscriptionId = subscripitonId
            };
            
            _subTypeManager.AddSubscriptionType(subscriptionType);
        }

        [TestMethod]
        public void SubscriptionTypeUpdate_WhenCalled_CheckIfUpdated()
        {
            var subscripitonId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011");
            var subscripitonTypeId = new Guid("0A8BE237-3A0A-4F85-BD9C-33502D69A2EF");
            var subscriptionType = new SubscriptionType()
            {
                SubscriptionTypeId = subscripitonTypeId,
                Name = "For Old",
                Type = "Old-age",
                SubscriptionId = subscripitonId
            };

            _subTypeManager.UpdateSubscriptionType(subscriptionType); 
        }

        [TestMethod]
        public void GetSubscripitonTypes_WhenCalled_CheckSubscriptionIsNotNull()
        {
            var subscriptions = _subTypeManager.GetAllSubscriptionTypes();

            Assert.IsNotNull(subscriptions);
        }

        [TestMethod]
        public void GetSubscriptionType_WhenCalled_CheckSubscriptionTypeIsNotNull()
        {
            var subscriptionTypeId = new Guid("0A8BE237-3A0A-4F85-BD9C-33502D69A2EF");
            var subscripitonType = _subTypeManager.GetSubscriptionType(subscriptionTypeId);
            Assert.IsNotNull(subscripitonType);
        }

        [TestMethod]
        public void GetSubscription_SubscriptionTypes_WhenCalled_CheckSubscriptionTypeIsNotNull()
        {
            var subcriptionId = new Guid("64241D09-E2B0-4D78-99E2-689073B50011");
            var subscriptionTypes = _subTypeManager.GetSubscriptionTypes(subcriptionId);
            Assert.IsNotNull(subscriptionTypes);
        }

        [TestMethod]
        public void GetAllSubscriptionTypes_WhenCalled_CheckSubscriptionTypesIsNotNull()
        {
            var subscriptionTypes = _subTypeManager.GetAllSubscriptionTypes();
            Assert.IsNotNull(subscriptionTypes);
        }
    }
}
