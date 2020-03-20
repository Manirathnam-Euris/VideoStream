using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class SubscriptionManager
    {
        private SubscripitionRepository _SubscripitionRep = new SubscripitionRepository();

        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return _SubscripitionRep.GetAllSubscripitons().ToList();
        }
        
        public Subscription GetSubscription(Guid subscriptionId)
        {
            try
            {
                if(subscriptionId == Guid.Empty || subscriptionId == null)
                {
                    throw new Exception("Provide valid Id");
                }

                var subscripitonExists = _SubscripitionRep.GetSubscriptionById(subscriptionId);
                if(subscripitonExists == null)
                {
                    throw new Exception("Subscription is not exists with this id :" + subscriptionId);
                }
                return subscripitonExists;
            }
            catch
            {
                throw new Exception("Something went wrong while getting with this Id: " + subscriptionId);
            }
        }

        public Subscription GetUserSubscription(Guid userId)
        {
            try
            {
                if (userId == Guid.Empty || userId == null)
                {
                    throw new Exception("Provide valid Id");
                }

                var subscription = _SubscripitionRep.GetAllSubscripitons().Where(s => s.UserAccount.UserId == userId).Single();
                if (subscription == null)
                {
                    throw new Exception("There is no subscriptions with this userId:" + userId);
                }
                return subscription;
            }
            catch
            {
                throw new Exception("Something went wrong while getting subscription with userId:" + userId);
            }
        }

        public void AddSubscription(Subscription subscription)
        {
            try
            {
                var subscriptionExists = _SubscripitionRep.GetSubscriptionById(subscription.SubscriptionId);
                if (subscriptionExists != null)
                {
                    throw new Exception("This subscription is already exists :" + subscription.SubscriptionId);
                }
                _SubscripitionRep.InsertSubscripiton(subscription);
                _SubscripitionRep.SaveSubscription();
            }
            catch
            {
                throw new Exception("Something went wrong while Adding subscripiton");
            }
        }

        public void UpdateSubscription(Subscription subscription)
        {
            try
            {
                var subscriptionExists = _SubscripitionRep.GetSubscriptionById(subscription.SubscriptionId);
                if(subscriptionExists == null)
                {
                    throw new Exception("This Subscripiton is not exists with this id :" + subscription.SubscriptionId);
                }
                _SubscripitionRep.UpdateSubscription(subscription);
                _SubscripitionRep.SaveSubscription();
            }
            catch
            {
                throw new Exception("Something went wrong while updating");
            }
        }

        public void DeleteSubscription(Guid subscriptionId)
        {
            try
            {
                if(subscriptionId == Guid.Empty || subscriptionId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var subscripitonExists = _SubscripitionRep.GetSubscriptionById(subscriptionId);
                if(subscripitonExists == null)
                {
                    throw new Exception("Subscription is not exists with this id:" + subscriptionId);
                }
                _SubscripitionRep.DeleteSubscription(subscriptionId);
                _SubscripitionRep.SaveSubscription();
            }
            catch
            {
                throw new Exception("Something went wrong while deleting the subscription");
            }
        }
    }
}
