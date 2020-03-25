using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class SavedMediaTest
    {
        private SavedMedia _savedMedia = new SavedMedia();
        private SavedMediaManager _savedManager = new SavedMediaManager();
        private MediaContentManager _mediaManager = new MediaContentManager();

        [TestMethod()]
        public void AddSavedMediaTest()
        {
            var media = _mediaManager.GetMediaContent(new Guid("98C2A5E2-F413-4913-BB38-8BD834596713"));
            _savedMedia.SavedMediaId = Guid.NewGuid();
            _savedMedia.Name = media.Title;
            _savedMedia.UserProfileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            _savedMedia.ContentId = media.ContentId;
            _savedManager.AddSavedMedia(_savedMedia);
        }

        [TestMethod()]
        public void GetSavedMediaByIdTest()
        {
            _savedManager.GetSavedMedia(new Guid("80227393-71FF-4A40-8001-92B50CFC89A5"));
        }

        [TestMethod]
        public void GetProfileSavedMediaTest()
        {
            var savedMedia =_savedManager.GetProfileSavedMedia(new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492"));
        }

        [TestMethod]
        public void GetContentSavedMediaTest()
        {
            var savedMedia = _savedManager.GetContentSavedMedia(new Guid("98C2A5E2-F413-4913-BB38-8BD834596713"));
        }

        [TestMethod]
        public void UpdateSavedMediaTest()
        {
            var media = _mediaManager.GetMediaContent(new Guid("98C2A5E2-F413-4913-BB38-8BD834596713"));
            _savedMedia.SavedMediaId = new Guid("80227393-71FF-4A40-8001-92B50CFC89A5");
            _savedMedia.Name = media.Title;
            _savedMedia.UserProfileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            _savedMedia.ContentId = media.ContentId;
            _savedManager.UpdateSavedMedia(_savedMedia);
        }

        [TestMethod]
        public void DeleteSavedMedia()
        {
            _savedManager.DeleteSavedMedia(new Guid("80227393-71FF-4A40-8001-92B50CFC89A5"));
        }
    }
}
