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
        private StreamDataRepository _StreamDataRep = new StreamDataRepository();

        public IEnumerable<StreamData> GetAllStreamDatas()
        {
            return _StreamDataRep.GetAllStreamData().ToList();
        }

        public StreamData GetStreamData(Guid streamId)
        {
            try
            {
                if(streamId == Guid.Empty || streamId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var streamExists = _StreamDataRep.GetStreamDataById(streamId);
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
                var streamDatas = _StreamDataRep.GetAllStreamData().Where(s => s.ContentId == contentId);
                if(streamDatas == null)
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
                var streamExists = _StreamDataRep.GetAllStreamData().Where(s => s.UserProfileId == profileId);
                if(streamExists == null)
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
                var streamExists = _StreamDataRep.GetStreamDataById(streamData.StreamDataId);
                if(streamExists != null)
                {
                    throw new Exception("This stream data is already present in the data Id:" + streamData.StreamDataId);
                }
                _StreamDataRep.InsertStreamData(streamData);
                _StreamDataRep.SaveStreamData();
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
                var streamExists = _StreamDataRep.GetStreamDataById(streamData.StreamDataId);
                if(streamExists == null)
                {
                    throw new Exception("Stream data is not present with this Id: " + streamData.StreamDataId);
                }
                streamExists.StreamDate = streamData.StreamDate;
                streamExists.StreamTime = streamData.StreamTime;
                streamExists.StreamLength = streamData.StreamLength;
                streamExists.StreamRate = streamData.StreamRate;
                streamExists.ContentId = streamData.ContentId;
                streamExists.UserProfileId = streamData.UserProfileId;

                _StreamDataRep.UpdateStreamData(streamExists);
                _StreamDataRep.SaveStreamData();
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
                var streamExists = _StreamDataRep.GetStreamDataById(streamId);
                if(streamExists == null)
                {
                    throw new Exception("Stream data is not present with this Id:" + streamId);
                }
                _StreamDataRep.DeleteStreamData(streamId);
                _StreamDataRep.SaveStreamData();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
