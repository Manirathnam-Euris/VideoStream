using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class StreamDataManager
    {
        UnitOfWork _unitOfWork = new UnitOfWork(new VideoStreamContext());

        public IEnumerable<StreamData> GetAllStreamDatas()
        {
            return _unitOfWork.StreamRep.GetAll().ToList();
        }

        public StreamData GetStreamData(Guid streamId)
        {
            try
            {
                if(streamId == Guid.Empty || streamId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var streamExists = _unitOfWork.StreamRep.GetById(streamId);
                if (streamExists == null)
                {
                    throw new Exception("Stream doesnot exists with this Id:" + streamId);
                }
                return streamExists;
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<StreamData> GetMediaContentStreamData(Guid contentId)
        {
            try
            {
                if(contentId == Guid.Empty || contentId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var streamDatas = _unitOfWork.StreamRep.GetAll().Where(s => s.ContentId == contentId);
                if (streamDatas == null)
                {
                    throw new Exception("No stream data is present with this content Id:" + contentId);
                }
                return streamDatas.ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<StreamData> GetUserStreamData(Guid profileId)
        {
            try
            {
                if(profileId == Guid.Empty || profileId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var streamExists = _unitOfWork.StreamRep.GetAll().Where(s => s.UserProfileId == profileId);
                if (streamExists == null)
                {
                    throw new Exception("There is no streams with the profile Id: " + profileId);
                }
                return streamExists.ToList();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddStreamData(StreamData streamData)
        {
            try
            {
                var streamExists = _unitOfWork.StreamRep.GetById(streamData.StreamDataId);
                if (streamExists != null)
                {
                    throw new Exception("This stream data is already present in the data Id:" + streamData.StreamDataId);
                }
                _unitOfWork.StreamRep.Insert(streamData);
                _unitOfWork.Save();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStreamData(StreamData streamData)
        {
            try
            {
                var streamExists = _unitOfWork.StreamRep.GetById(streamData.StreamDataId);
                if (streamExists == null)
                {
                    throw new Exception("Stream data is not present with this Id: " + streamData.StreamDataId);
                }
                streamExists.StreamDate = streamData.StreamDate;
                streamExists.StreamTime = streamData.StreamTime;
                streamExists.StreamLength = streamData.StreamLength;
                streamExists.StreamRate = streamData.StreamRate;
                streamExists.ContentId = streamData.ContentId;
                streamExists.UserProfileId = streamData.UserProfileId;
               
                _unitOfWork.StreamRep.Update(streamExists);
                _unitOfWork.Save();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStreamData(Guid streamId)
        {
            try
            {
                if(streamId == Guid.Empty || streamId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var streamExists = _unitOfWork.StreamRep.GetById(streamId);
                if (streamExists == null)
                {
                    throw new Exception("Stream data is not present with this Id:" + streamId);
                }
                _unitOfWork.StreamRep.Delete(streamId);
                _unitOfWork.Save();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
