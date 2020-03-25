using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class StreamDataTest
    {
        private StreamData _streamData = new StreamData();
        private StreamDataManager _streamDataManager = new StreamDataManager();

        [TestMethod]
        public void AddStreamDataTest()
        {
            _streamData.StreamDataId = Guid.NewGuid();
            _streamData.StreamDate = DateTime.Now;
            _streamData.StreamTime = DateTime.Now;
            _streamData.StreamLength = 100;
            _streamData.StreamRate = "1080bits";
            _streamData.UserProfileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            _streamData.ContentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");
            _streamDataManager.AddStreamData(_streamData);
        }

        [TestMethod()]
        public void GetStreamByIdTest()
        {
            _streamDataManager.GetStreamData(new Guid("76A9238F-530C-42FA-8088-03BA4809432B"));
        }

        [TestMethod()]
        public void UpdateStreamDataTest()
        {
            _streamData.StreamDataId = new Guid("CA2AF232-B909-4E19-8B4F-1BD8AA0079BA");
            _streamData.StreamDate = DateTime.Now;
            _streamData.StreamTime = DateTime.Now;
            _streamData.StreamLength = 150;
            _streamData.StreamRate = "1080bits";
            _streamData.UserProfileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            _streamData.ContentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");
            _streamDataManager.UpdateStreamData(_streamData);
        }

        [TestMethod()]
        public void DeleteStreamDataTest()
        {
            _streamDataManager.DeleteStreamData(new Guid("CA2AF232-B909-4E19-8B4F-1BD8AA0079BA"));
        }

        [TestMethod()]
        public void GetMediaStreamTest()
        {
           var mediaStream = _streamDataManager.GetMediaContentStreamData(new Guid("98C2A5E2-F413-4913-BB38-8BD834596713"));
        }

        [TestMethod]
        public void GetProfileStreamTest()
        {
           var profileStream = _streamDataManager.GetUserStreamData(new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492"));
        }

        [TestMethod()]
        public void GetAllStreamData()
        {
            _streamDataManager.GetAllStreamDatas();
        }
    }
}
