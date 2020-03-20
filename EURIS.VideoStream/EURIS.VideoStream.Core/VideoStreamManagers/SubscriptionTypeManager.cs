using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class SubscriptionTypeManager
    {
        private SubscriptionTypeRepository _SubscriptionTypeRep = new SubscriptionTypeRepository();

        public IEnumerable<SubscriptionType> GetAllSubscriptionTypes()
        {
            return _SubscriptionTypeRep.GetAllSubscripitonTypes().ToList();
        }

        public SubscriptionType GetSubscriptionType(Guid subscriptionTypeId)
        {
            try
            {
                if(subscriptionTypeId == Guid.Empty || subscriptionTypeId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var subscriptionTypeExists = _SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionTypeId);
                if(subscriptionTypeExists == null)
                {
                    throw new Exception("Subscripiton type is not found with the Id:" + subscriptionTypeId);
                }
                return subscriptionTypeExists;
            }
            catch
            {
                throw new Exception("Something went wrong while getting the subscriptions");
            }
        }

        public IEnumerable<SubscriptionType> GetSubscriptionTypes(Guid subscriptionId)
        {
            try
            {
                if(subscriptionId == Guid.Empty || subscriptionId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var subscripitionTypeExists = _SubscriptionTypeRep.GetAllSubscripitonTypes().Where(s => s.Subscripiton.SubscriptionId == subscriptionId);
                if(subscripitionTypeExists == null)
                {
                    throw new Exception("Subscription types with ths subscription Id is not present :" + subscriptionId);
                }
                return subscripitionTypeExists.ToList();
            }
            catch
            {
                throw new Exception("Something went wrong while getting subscription types");
            }
        }

        public void UpdateSubscriptionType(SubscriptionType subscriptionType)
        {
            try
            {
                var subscriptionTypeExists = _SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionType.SubscriptionTypeId);
                if(subscriptionTypeExists == null)
                {
                    throw new Exception("Subscription type is not found with this Id :" + subscriptionType.SubscriptionTypeId);
                }
                _SubscriptionTypeRep.InsertSubscripitonType(subscriptionType);
                _SubscriptionTypeRep.SaveSubscriptionType();
            }
            catch
            {
                throw new Exception("Something went wrong while updating the subscription type");
            }
        }

        public void AddSubscriptionType(SubscriptionType subscriptionType)
        {
            try
            {
                var subscriptionTypeExists = _SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionType.SubscriptionTypeId);
                if(subscriptionTypeExists != null)
                {
                    throw new Exception("This Subscripition type is already exists with Id: " + subscriptionType.SubscriptionTypeId);
                }
                _SubscriptionTypeRep.InsertSubscripitonType(subscriptionType);
                _SubscriptionTypeRep.SaveSubscriptionType();
            }
            catch
            {
                throw new Exception("Something went wrong while adding subscription type");
            }
        }

        public void DeleteSubscriptionType(Guid subscriptionTypeId)
        {
            try
            {
                if(subscriptionTypeId == Guid.Empty || subscriptionTypeId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var subscriptionTypeExists = _SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionTypeId);
                if(subscriptionTypeExists == null)
                {
                throw new Exception("Subscription type is not present with the Id:" + subscriptionTypeId);
                }
                _SubscriptionTypeRep.DeleteSubscriptionType(subscriptionTypeId);
                _SubscriptionTypeRep.SaveSubscriptionType();
            }
            catch
            {
                throw new Exception("Something went wrong while deleting the subcription type");
            }
        }

    }
}
