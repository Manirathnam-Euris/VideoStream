using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class StreamDataTest
    {
        //private StreamData _streamData = new StreamData();
        private StreamDataManager _streamDataManager = new StreamDataManager();

        [TestMethod]
        public void AddStreamData_WhenCalled_CheckItIsAdded()
        {
            var profileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            var contentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");

            var streamData = new StreamData()
            {
                StreamDataId = Guid.NewGuid(),
                StreamDate = DateTime.Now,
                StreamTime = DateTime.Now,
                StreamLength = 100,
                StreamRate = "1080bits",
                UserProfileId = profileId,
                ContentId = contentId
            };
           
            _streamDataManager.AddStreamData(streamData);
        }

        [TestMethod()]
        public void GetStreamById_WhenCalled_CheckStreamDataIsNotNull()
        {
            var streamDataId = new Guid("76A9238F-530C-42FA-8088-03BA4809432B");

            var streamData = _streamDataManager.GetStreamData(streamDataId);

            Assert.IsNotNull(streamData);
        }

        [TestMethod()]
        public void UpdateStreamData_WhenCalled_CheckStreamDataIsUpdated()
        {
            var streamDataId = new Guid("CA2AF232-B909-4E19-8B4F-1BD8AA0079BA");
            var profileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            var contentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");

            var streamData = new StreamData()
            {
                StreamDataId = streamDataId,
                StreamDate = DateTime.Now,
                StreamTime = DateTime.Now,
                StreamLength = 150,
                StreamRate = "1080bits",
                UserProfileId = profileId,
                ContentId = contentId
            };

            _streamDataManager.UpdateStreamData(streamData);
        }

        [TestMethod()]
        public void DeleteStreamData_WhenCalled_CheckStreamDataIsDeleted()
        {
            var streamDataId = new Guid("CA2AF232-B909-4E19-8B4F-1BD8AA0079BA");

            _streamDataManager.DeleteStreamData(streamDataId);
        }

        [TestMethod()]
        public void GetMediaStream_WhenCalled_CheckMediaStreamIsNotNull()
        {
            var contentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");

            var mediaStream = _streamDataManager.GetMediaContentStreamData(contentId);

            Assert.IsNotNull(mediaStream);
        }

        [TestMethod]
        public void GetProfileStream_WhenCalled_CheckProfileStreamIsNotNull()
        {
            var profileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");

            var profileStream = _streamDataManager.GetUserStreamData(profileId);

            Assert.IsNotNull(profileStream);
        }

        [TestMethod()]
        public void GetAllStreamData_WhenCalled_CheckStreamDataIsNotNull()
        {
            var streamData = _streamDataManager.GetAllStreamDatas();

            Assert.IsNotNull(streamData);
        }
    }
}
