using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class SavedMediaTest
    {
        //private SavedMedia _savedMedia = new SavedMedia();
        private SavedMediaManager _savedManager = new SavedMediaManager();
        private MediaContentManager _mediaManager = new MediaContentManager();

        [TestMethod()]
        public void AddSavedMedia_WhenCalled_CheckSavedMediaIsUpdated()
        {
            var contentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");
            var profileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            var media = _mediaManager.GetMediaContent(contentId);

            if(media != null)
            {
                var savedMedia = new SavedMedia()
                {
                    SavedMediaId = Guid.NewGuid(),
                    Name = media.Title,
                    UserProfileId = profileId,
                    ContentId = media.ContentId
                };

                _savedManager.AddSavedMedia(savedMedia);
            }
        }

        [TestMethod()]
        public void GetSavedMediaById_WhenCalled_CheckSavedMediaIsNotNull()
        {
            var savedMediaId = new Guid("80227393-71FF-4A40-8001-92B50CFC89A5");

            var savedMedia = _savedManager.GetSavedMedia(savedMediaId);

            Assert.IsNotNull(savedMedia);
        }

        [TestMethod]
        public void GetProfileSavedMedia_WhenCalled_CheckProfileSavedMediaIsNotNull()
        {
            var profileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");

            var profileSavedMedia =_savedManager.GetProfileSavedMedia(profileId);

            Assert.IsNotNull(profileSavedMedia);
        }

        [TestMethod]
        public void GetContentSavedMedia_WhenCalled_CheckContentSavedMediaIsNotNull()
        {
            var contentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");

            var savedMedia = _savedManager.GetContentSavedMedia(contentId);

            Assert.IsNotNull(savedMedia);
        }

        //[TestMethod]
        //public void UpdateSavedMediaTest()
        //{

        //    //var media = _mediaManager.GetMediaContent(new Guid("98C2A5E2-F413-4913-BB38-8BD834596713"));
        //    //_savedMedia.SavedMediaId = new Guid("80227393-71FF-4A40-8001-92B50CFC89A5");
        //    //_savedMedia.Name = media.Title;
        //    //_savedMedia.UserProfileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
        //    //_savedMedia.ContentId = media.ContentId;

        //    var contentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");
        //    var profileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
        //    var media = _mediaManager.GetMediaContent(contentId);

        //    var savedMedia = new SavedMedia()
        //    {
        //        SavedMediaId = Guid.NewGuid(),
        //        Name = media.Title,
        //        UserProfileId = profileId,
        //        ContentId = media.ContentId
        //    };

        //    _savedManager.UpdateSavedMedia(_savedMedia);
        //}

        [TestMethod]
        public void DeleteSavedMedia_WhenCalled_CheckSavedMediaIsDeleted()
        {
            var savedMediaId = new Guid("80227393-71FF-4A40-8001-92B50CFC89A5");
            _savedManager.DeleteSavedMedia(savedMediaId);
        }
    }
}
