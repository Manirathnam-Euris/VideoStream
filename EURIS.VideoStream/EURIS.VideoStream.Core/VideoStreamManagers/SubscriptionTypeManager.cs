using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class SubscriptionTypeManager
    {
        //private SubscriptionTypeRepository _SubscriptionTypeRep = new SubscriptionTypeRepository();
        UnitOfWork _unitOfWork = new UnitOfWork(new VideoStreamContext());

        public IEnumerable<SubscriptionType> GetAllSubscriptionTypes()
        {
            return _unitOfWork.SubscriptionTypeRep.GetAllSubscripitonTypes().ToList();
        }

        public SubscriptionType GetSubscriptionType(Guid subscriptionTypeId)
        {
            try
            {
                if(subscriptionTypeId == Guid.Empty || subscriptionTypeId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                //var subscriptionTypeExists = _SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionTypeId);
                var subscriptionTypeExists = _unitOfWork.SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionTypeId);
                if (subscriptionTypeExists == null)
                {
                    throw new Exception("Subscripiton type is not found with the Id:" + subscriptionTypeId);
                }
                return subscriptionTypeExists;
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
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
                //var subscripitionTypeExists = _SubscriptionTypeRep.GetAllSubscripitonTypes().Where(s => s.SubscriptionId == subscriptionId);
                var subscripitionTypeExists = _unitOfWork.SubscriptionTypeRep.GetAllSubscripitonTypes().Where(s => s.SubscriptionId == subscriptionId);
                if (subscripitionTypeExists == null)
                {
                    throw new Exception("Subscription types with ths subscription Id is not present :" + subscriptionId);
                }
                return subscripitionTypeExists.ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateSubscriptionType(SubscriptionType subscriptionType)
        {
            try
            {
                //var subscriptionTypeExists = _SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionType.SubscriptionTypeId);
                var subscriptionTypeExists = _unitOfWork.SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionType.SubscriptionTypeId);
                if (subscriptionTypeExists == null)
                {
                    throw new Exception("Subscription type is not found with this Id :" + subscriptionType.SubscriptionTypeId);
                }
                subscriptionTypeExists.Name = subscriptionType.Name;
                subscriptionTypeExists.Type = subscriptionType.Type;
                subscriptionTypeExists.SubscriptionId = subscriptionType.SubscriptionId;

                //_SubscriptionTypeRep.InsertSubscripitonType(subscriptionTypeExists);
                //_SubscriptionTypeRep.SaveSubscriptionType();
                _unitOfWork.SubscriptionTypeRep.InsertSubscripitonType(subscriptionTypeExists);
                _unitOfWork.Save();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddSubscriptionType(SubscriptionType subscriptionType)
        {
            try
            {
                //var subscriptionTypeExists = _SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionType.SubscriptionTypeId);
                var subscriptionTypeExists = _unitOfWork.SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionType.SubscriptionTypeId);
                if (subscriptionTypeExists != null)
                {
                    throw new Exception("This Subscripition type is already exists with Id: " + subscriptionType.SubscriptionTypeId);
                }
                //_SubscriptionTypeRep.InsertSubscripitonType(subscriptionType);
                //_SubscriptionTypeRep.SaveSubscriptionType();
                _unitOfWork.SubscriptionTypeRep.InsertSubscripitonType(subscriptionType);
                _unitOfWork.Save();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
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
                //var subscriptionTypeExists = _SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionTypeId);
                var subscriptionTypeExists = _unitOfWork.SubscriptionTypeRep.GetSubscriptionTypeById(subscriptionTypeId);
                if (subscriptionTypeExists == null)
                {
                throw new Exception("Subscription type is not present with the Id:" + subscriptionTypeId);
                }
                //_SubscriptionTypeRep.DeleteSubscriptionType(subscriptionTypeExists.SubscriptionTypeId);
                //_SubscriptionTypeRep.SaveSubscriptionType();
                _unitOfWork.SubscriptionTypeRep.DeleteSubscriptionType(subscriptionTypeExists.SubscriptionTypeId);
                _unitOfWork.Save();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
